using System.Reflection.Metadata.Ecma335;

namespace Dependencies.Player;

public class Player(string Name, int Strength, int Intelligence, int Dexterity, float Accuracy, int CurrentRoom = 1, int Health = 20, ushort Location = 1) {
    string Name { get; set; } = Name;
    public int Strength { get; set; } = Strength;
    public int Intelligence { get; set; } = Intelligence;
    public int Dexterity { get; set; } = Dexterity;
    public int CurrentRoom { get; set; } = CurrentRoom;
    public float Accuracy { get; set; } = Accuracy;
    public int Health { get; set; } = Health;
    public ushort Location = Location;
    public Inventory Inventory = new();
    public bool UseItem(string item) => Inventory.UseItem(item);
    
}