using Dependencies.Dungeon;
using Dependencies.Player;
using Dependencies.Monster;
// SETUP GAME LOGIC
AsciiArt art = new();

Console.Clear();
Console.Write("What is your name, brave hero? ");
string name = Console.ReadLine()!;
int confirm = 0;
Console.Write("Are you sure that is correct?  (Y for 1, N for 2) ");
while (!TryGetChoice(out confirm, 1, 2) || confirm != 1)
{
    Console.Write("Tell us your real name then: ");
    name = Console.ReadLine()!;
    Console.Write("Are you sure that is correct? (Y for 1, N for 2) ");
}
GameLoop:
IRoom[] rooms = GenerateRooms(10);
bool isAlive = true;
Challenges challenges = new();
Console.WriteLine($"Very well then, we pray for your safe return {name}");

Player CurrentPlayer = new(name, 10, 10, 10, .9f);
CurrentPlayer.Inventory.Pouch.Enqueue(new HealthPotion());
CurrentPlayer.Inventory.Pouch.Enqueue(new HealthPotion());
var TombOfAnihilation = new DungeonLayout(rooms);
var ChallengeNode = TombOfAnihilation.Layout.ToArray();
// Main Loop
while (true)
{
    Console.Clear();
    if (TombOfAnihilation.Layout[CurrentPlayer.Location].Enemy is not null && TombOfAnihilation.Layout[CurrentPlayer.Location].Enemy!.Hp > 0)
        if (!Battle(ref CurrentPlayer, TombOfAnihilation.Layout[CurrentPlayer.Location].Enemy!)) {
            isAlive = false;
            break;
        };
    if (CurrentPlayer.Location == rooms.Count()+2)
        break;
    Console.WriteLine($"({CurrentPlayer.Name}) HP <{CurrentPlayer.Health}>  Equipment <{(CurrentPlayer.Weapon == null ? "None" : CurrentPlayer.Weapon.Name)}>");
    Console.Write($"{TombOfAnihilation.Layout[CurrentPlayer.Location].Display()}\n{(TombOfAnihilation.Layout[CurrentPlayer.Location].Enemy is null || TombOfAnihilation.Layout[CurrentPlayer.Location].Enemy!.Hp > 0 ? GetFrame(TombOfAnihilation.Layout[CurrentPlayer.Location].Type) : art.MonsterRoom)}\nWhat would you like to do?\n 1) Explore\n 2) Search the room\n 3) Use Item\n 4) Equip Items\n");
    if (TombOfAnihilation.Layout[CurrentPlayer.Location].Treasure != null) {

    }
    TryGetChoice(out int input, 1, 2, 3, 4);
    UiHandler(input);
}

int playAgain = 0;
do Console.Write(isAlive ? "Congrats! You escaped the dungeon!\nWould you like to play again?\n 1) Yes\n 2) No\n": "You have Died! Would you like to try again?\n1) Yes\n 2) No\n");
while (!TryGetChoice(out playAgain, 1, 2));
if (playAgain == 1) goto GameLoop; // Restart the game from the beginning of the file

// Helper Functions
void UiHandler(int input)
{
    switch (input)
    {
        case 1:
            TombOfAnihilation.Traverse(ref CurrentPlayer.Location);
            break;
        case 2:
            var item = TombOfAnihilation.Layout[CurrentPlayer.Location].Treasure;
            if (item is not null) {
                Console.WriteLine($"You found {item.Name}!");
                CurrentPlayer.Inventory.Add(item);
                TombOfAnihilation.Layout[CurrentPlayer.Location].Treasure = null;
            }
            else
                Console.WriteLine("You found nothing!");
            Console.ReadKey(true);
            break;
        case 3:
            Console.Clear();
            Console.WriteLine(CurrentPlayer.Inventory.Display());
            int[] options = [1, 2, 3, 4, 5];
            int choice;
            if (CurrentPlayer.Inventory.Pouch.Count > 0) {
                while (!TryGetChoice(out choice, options[0..CurrentPlayer.Inventory.Pouch.Count]));
                CurrentPlayer.Inventory.UseItem(ref CurrentPlayer, CurrentPlayer.Inventory.GetAt(choice)!.Name);
            }
            else {
                Console.WriteLine("Your inventory is empty!");
            }
            Console.ReadKey(true);
            break;
        case 4:
            Console.Clear();
            Console.WriteLine(CurrentPlayer.Inventory.Display());
            int[] equipOptions = [1, 2, 3, 4, 5];
            int itemChoice;
            if (CurrentPlayer.Inventory.Pouch.Count() > 0) {
                while (!TryGetChoice(out itemChoice, equipOptions[0..CurrentPlayer.Inventory.Pouch.Count]));
                CurrentPlayer.Inventory.EquipItem(ref CurrentPlayer, CurrentPlayer.Inventory.GetAt(itemChoice)!.Name);
            }
            else {
                Console.WriteLine("Your inventory is empty!");
            }
            Console.ReadKey(true);
            break;
        default:
            break;
    }
}

bool TryGetChoice(out int choice, params int[] choices)
{
    try
    {
        int input = int.Parse(Console.ReadLine()!);
        if (choices.Contains(input))
        {
            choice = input;
            return true;
        }
    }
    catch
    {
        Console.WriteLine("That is not a valid input!");
    }
    choice = 0;
    return false;
}

string GetFrame(RoomType type) =>
    type switch {
        RoomType.Empty => art.EmptyHallway,
        RoomType.Door => art.DoorRoom,
        RoomType.Trap => art.TrapRoom,
        RoomType.Treasure => art.ChestRoom,
        _ => "ERROR: Room not found!"
    };

bool Battle(ref Player player, IMonster? monster) {
    bool flee = false;
    for (int i = 0; i < int.MaxValue; i++) {
        Console.Clear();
        Console.WriteLine($"{player.Name}: {player.Health}\n{monster!.Name}: {monster!.Hp}\n{(i%2==0?player.Name:monster.Name)}'s turn:\n");
        if (i%2 == 0) {
            // PLAYER
            Console.Write($"What would you like to do?\n 1) Attack\n 2) Use Item\n 3) Flee\n");
            TryGetChoice(out int choice, 1, 2, 3);
            switch (choice) {
                case 1:
                    int damageDealt = player.DealDamage();
                    monster!.Hp -= damageDealt;
                    Console.WriteLine($"You dealt {damageDealt} damage!");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
                case 2:
                    Console.Clear();
                    Console.WriteLine(CurrentPlayer.Inventory.Display());
                    int[] options = [1, 2, 3, 4, 5];
                    int itemChoice;
                    if (CurrentPlayer.Inventory.Pouch.Count() > 0) {
                        while (!TryGetChoice(out itemChoice, options[0..CurrentPlayer.Inventory.Pouch.Count]));
                        CurrentPlayer.Inventory.UseItem(ref CurrentPlayer, CurrentPlayer.Inventory.GetAt(itemChoice)!.Name);
                    }
                    else {
                        Console.WriteLine("Your inventory is empty!");
                    }
                    Console.ReadKey(true);
                    continue;
                case 3:
                    // flee
                    flee = true;
                    Console.WriteLine($"You flee, but the {monster!.Name} makes one final strike at you!\n");
                    player.Health -= monster!.DealDamage();
                    TombOfAnihilation.Traverse(ref CurrentPlayer.Location);
                    Console.WriteLine($"\n{player.Name}: {player.Health}\n{monster!.Name}: {monster!.Hp}\n");
                    Console.ReadKey(true);
                    Console.Clear();
                    break;
                default:
                    continue;
            }
        }
        else {
            // MONSTER
            player.Health -= monster!.DealDamage();
            Console.ReadKey(true);
        }
        if (player.Health <= 0) {
            return false;
        }
        if (monster!.Hp <= 0) {
            monster = null!;
            return true;
        }
        if (flee) {
            return true;
        }
    }
    return false;
}

IRoom[] GenerateRooms(int quantity) {
    List<IRoom> rooms = [];
    List<IMonster> monsters = [new GelatinousCube(), new Zombie(), new Dragon()];
    List<IItem> items = [new HealthPotion(), new MagicSword()];
    float MonsterChance = .372f; // Added by Matt
    Random rand = new();
    List<IRoom> options = [new Empty(2), new TreasureRoom(3, "Sword", new MagicSword()), new Trap(4, TrapType.Flame) { Enemy = new GelatinousCube() }, new Trap(4, TrapType.Boulder), new TreasureRoom(3, "Sword", new MagicSword()), new Trap(4, TrapType.Snake) { Enemy = new Zombie() }, new Empty(2)];
    for (int i = 1; i <= quantity; i++) {
        IRoom room = options[rand.Next(0,options.Count)];
        if (rand.Next(0,100) < MonsterChance*100)
            room.Enemy = monsters[rand.Next(0,1)];
        if (room.Type == RoomType.Treasure)
            room.Treasure = items[rand.Next(0,1)];
        rooms.Add(room);
    }
    return [.. rooms];
}