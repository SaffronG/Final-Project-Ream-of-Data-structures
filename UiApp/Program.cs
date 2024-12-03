using Dependencies.Dungeon;
using Dependencies.Player;
using Dependencies.Monster;
using UiApp;
using System.ComponentModel;
// SETUP GAME LOGIC

IRoom[] rooms = [
    new Empty(2),
    new Treasure(3, "Sword"),
    new Trap(4, TrapType.Flame),
    new Trap(4, TrapType.Flame),
    new Treasure(3, "Sword"),
    new Trap(4, TrapType.Flame),
    new Treasure(3, "Sword")
    ];

GameLoop:
Console.Clear();
Console.Write("What is your name, brave hero? ");
string name = Console.ReadLine()!;
int confirm = 0;
Console.WriteLine("Are you sure that is correct?  (Y for 1, N for 2)");
while (!TryGetChoice(out confirm, 1, 2) || confirm != 1)
{
    Console.Write("Tell us your real name then: ");
    name = Console.ReadLine()!;
    Console.WriteLine("Are you sure that is correct? (Y for 1, N for 2)");
}
Console.Write("Would you like to enable Auto Play mode (This will choose the easiest path automatically)? (Y for 1, N for 2)");
while (!TryGetChoice(out confirm, 1, 2)) Console.Write("Invalid input, try again! ");
bool autoPlay = confirm == 1;
Console.WriteLine($"Very well then, we pray for your safe return {name}");

Player CurrentPlayer = new(name, 10, 10, 10);
var TombOfAnihilation = new DungeonLayout(rooms);
var ChallengeNode = TombOfAnihilation.Layout.ToArray();
// Main Loop
while (true)
{
    Console.Clear();
    Console.Write($"{TombOfAnihilation.Layout[CurrentPlayer.Location].Display()}\nWhat would you like to do?\n 1) Explore\n 2) Search the room\n 3) Use Item\n 4) Equip Weapons\n");
    TryGetChoice(out int input, 1, 2, 3, 4);
    UiHandler(input);
    if (CurrentPlayer.Location == 9)
        break;
}

int playAgain = 0;
do Console.Write("Congrats! You escaped the dungeon!\nWould you like to play again?\n 1) Yes\n 2) No\n");
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
            Random random = new();
            Items item = (Items)random.Next(3);
            Console.WriteLine($"You found {item}!");
            if (item != Items.Nothing) CurrentPlayer.Inventory.Add(Inventory.ToItem(item)!);
            Console.ReadKey(true);
            break;
        case 3:
            Console.Clear();
            Console.WriteLine(CurrentPlayer.Inventory.Display());
            Console.ReadKey(true);
            break;
        case 4:
            Console.WriteLine("Equip Weapon");
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