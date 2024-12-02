namespace Dependencies.Player;

public class Player(int Strength, int Intelligence, int Dexterity, int CurrentRoom = 1, int Health = 20, ushort Location = 1) {
    public int Strength { get; set; } = Strength;
    public int Intelligence { get; set; } = Intelligence;
    public int Dexterity { get; set; } = Dexterity;
    public int CurrentRoom { get; set; } = CurrentRoom;
    public int Health { get; set; } = Health;
    public ushort Location = Location;
    public Inventory Inventory = new();
}