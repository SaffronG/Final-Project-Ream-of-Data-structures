using System.Runtime.InteropServices;

namespace Dependencies.Dungeon;

public class DungeonLayout
{
    // Stores the dungeon layout in the form of a graph using the adjacency matrix and dictionary method
    public Dictionary<IRoom, int> Layout { get; } = [];
    public ushort[,] Hallways { get; set; }
    public DungeonLayout(params IRoom[] rooms) {
        Layout[new Entrance()] = 1;
        for (int i = 2; i < rooms.Length+2; i++) Layout[rooms[i-2]] = i;
        Layout[new Exit(Layout.Count+1)] = Layout.Count+1;
        Hallways = new ushort[rooms.Length+2,rooms.Length+2];
        CreateHallways();
    }

    private void CreateHallways() {
        Stack<int> visited = new();
        visited.Push(1);
        var rand = new Random();
        while (visited.Count < Layout.Count-1) {
            int randIndex = rand.Next(2,Layout.Count);
            if (visited.Contains(randIndex)) continue;
            else {
                var lastRoom = visited.Pop();
                Hallways[lastRoom-1, randIndex] = 1;
                Hallways[randIndex, lastRoom-1] = 1;
                visited.Push(lastRoom);
                visited.Push(randIndex);
            }
        }
    }

    public void DBGHallways() {
        for (int i = 1; i < Hallways.GetLength(0)+1; i++) {
            for (int j = 1; j < Hallways.GetLength(1)+1; j++) {
                if (j % Hallways.GetLength(0) + 1 == 1)
                    Console.WriteLine(Hallways[j-1,i-1]);
                else
                    Console.Write(Hallways[j-1,i-1]);
            }
        }
    }
}