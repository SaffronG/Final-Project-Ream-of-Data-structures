﻿using Dependencies.Dungeon;

var tombOfAnihilation = new DungeonLayout(new Empty(2), new Treasure(3, "Sword"), new Trap(4, TrapType.Flame));

Console.WriteLine("-----");

tombOfAnihilation.DBGHallways();