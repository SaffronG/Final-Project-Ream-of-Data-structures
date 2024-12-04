namespace Dependencies.Dungeon;

public class DungeonLayout
{
    // Stores the dungeon layout in the form of a graph using the adjacency matrix and dictionary method
    public Dictionary<int, IRoom> Layout { get; } = [];
    public ushort[,] Hallways { get; set; }

    public DungeonLayout(params IRoom[] rooms) {
        Layout[1] = new Entrance();
        for (int i = 2; i < rooms.Length+2; i++) Layout[i] = rooms[i-2];
        Layout[Layout.Count+1] = new Exit(Layout.Count+1);
        Hallways = new ushort[rooms.Length+2,rooms.Length+2];
        CreateHallways();
    }

    private void CreateHallways() {
        Stack<int> visited = new();
        visited.Push(1);
        var rand = new Random();
        // Randomly create hallways between rooms until each room has two hallways
        while (visited.Count < (Layout.Count * 1.5) - 1) {
            int randIndex = rand.Next(2,Layout.Count);
            var lastRoom = visited.Pop();
            Hallways[lastRoom-1, randIndex] = 1;
            Hallways[randIndex, lastRoom-1] = 1;
            visited.Push(lastRoom);
            visited.Push(randIndex);
            if (visited.Count == Layout.Count * 2 -1)
            {
                Hallways[lastRoom - 1, Layout[Layout.Count-1].Id] = 1;
                Hallways[Layout[Layout.Count-1].Id, lastRoom - 1] = 1;
            }
        }
    }

    public void Traverse(ref ushort playerLocation)
    {
        List<ushort> availablePaths = [];
        for (ushort i = 0; i < (ushort) Hallways.GetLength(0); i++)
            if (Hallways[playerLocation-1, i] != 0)
                availablePaths.Add((ushort) (i+1));
        while(!TryTraverse(availablePaths, playerLocation, out playerLocation))
            Console.WriteLine("That is not a valid room choice!");
    }
    public void AutoTraverse(ref ushort playerLocation, ref Challenges challenges)
    {
        challenges.Insert(playerLocation, challenges.Head);
        List<ushort> availablePaths = [];
        for (ushort i = 0; i < (ushort) Hallways.GetLength(0); i++)
            if (Hallways[playerLocation-1, i] != 0)
                availablePaths.Add((ushort) (i+1));
        playerLocation = (ushort) challenges.FindNext(playerLocation, availablePaths);
    }

    private static bool TryTraverse(List<ushort> paths, ushort playerLocation, out ushort selection)
    {
        Console.Write($"You are in room {playerLocation} and it connects to room:");
        foreach (var path in paths) Console.Write($" {path},");
        Console.WriteLine("");
        Console.Write("Where would you like to go? ");
        try {
            ushort input = ushort.Parse(Console.ReadLine()!);
            if (paths.Contains(input))
            {
                selection = input;
                return true;
            }
        }
        catch {
            selection = 0;
            return false;
        }
        selection = 0;
        return false;
    }

    public void Dbg() {
        for (int i = 1; i < Hallways.GetLength(0)+1; i++) {
            for (int j = 1; j < Hallways.GetLength(1)+1; j++) {
                if (j % Hallways.GetLength(0) + 1 == 1)
                    Console.WriteLine(Hallways[j-1,i-1] + "\n");
                else
                    Console.Write(Hallways[j-1,i-1] + " ");
            }
        }
    }
}