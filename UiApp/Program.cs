using Dependencies.Dungeon;
using Dependencies.Player;
using Dependencies.Monster;
using UiApp;

// SETUP GAME LOGIC
var TombOfAnihilation = new DungeonLayout(new Empty(2),new Treasure(3, "Sword"), new Trap(4, TrapType.Flame), new Trap(4, TrapType.Flame),new Treasure(3, "Sword"), new Trap(4, TrapType.Flame),new Treasure(3, "Sword"));

Console.Clear();

TombOfAnihilation.dbg();
Player CurrentPlayer = new(10,10,10);

while (true)
{
    Console.WriteLine(CurrentPlayer.Location - 1);
    TombOfAnihilation.Traverse(ref CurrentPlayer.Location);
}

//using (Game game = new Game(800, 600, "Realm of Data Structures"))
//{
//    game.Run();
//}