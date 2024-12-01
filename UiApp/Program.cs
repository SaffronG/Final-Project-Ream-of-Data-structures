using Dependencies.Dungeon;
using UiApp;

// SETUP GAME LOGIC
var TombOfAnihilation = new DungeonLayout(new Empty(2),new Treasure(3, "Sword"), new Trap(4, TrapType.Flame), new Trap(4, TrapType.Flame),new Treasure(3, "Sword"), new Trap(4, TrapType.Flame),new Treasure(3, "Sword"));

Console.Clear();

TombOfAnihilation.dbg();

//using (Game game = new Game(800, 600, "Realm of Data Structures"))
//{
//    game.Run();
//}