namespace Dependencies;

public class Dungeon
{
    // Stores the dungeon layout in the form of a graph using the adjacency matrix and dictionary method
    public Dictionary<IRoom, int> Layout { get; } = new();
    public ushort[,] Hallways { get; set; }
    public Dungeon(params IRoom[] rooms) {
        for (int i = 0; i < rooms.Length; i++) Layout[rooms[i]] = i;
        Hallways = new ushort[rooms.Length,rooms.Length];
    }

    private void CreateHallways() {
        
    }
}
