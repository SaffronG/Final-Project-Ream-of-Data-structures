using System.Globalization;

namespace Dependencies.Dungeon;

public class DungeonLayout
{
    // Stores the dungeon layout in the form of a graph using the adjacency matrix and dictionary method
    public Dictionary<IRoom, int> Layout { get; } = [];
    public ushort[,] Hallways { get; set; }
    public DungeonLayout(params IRoom[] rooms) {
        Layout[new Entrance()] = 1;
        for (int i = 2; i < rooms.Length; i++) Layout[rooms[i]] = i;
        Layout[new Exit(Layout.Count+1)] = Layout.Count+1;
        Hallways = new ushort[rooms.Length,rooms.Length];
        CreateHallways();
    }

    private void CreateHallways() {
        Stack<int> visited = new();
        visited.Push(1);
        var rand = new Random();
        while (visited.Count < Layout.Count) {
            int randIndex = rand.Next(2,Layout.Count);
            if (visited.Contains(randIndex)) continue;
            Hallways[visited.Last(), randIndex] = 1;
            visited.Push(randIndex);
        }
    }

    public void DBGHallways() {
        for (int i = 0; i < Hallways.GetLength(0); i++) {
            for (int j = 0; j < Hallways.GetLength(1); j++) {
                if (j % Hallways.GetLength(1) == 1)
                    Console.WriteLine(Hallways[i,j]);
                else
                    Console.Write(Hallways[i,j]);
            }
        }
    }
}
