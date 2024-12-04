using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

namespace Dependencies.Player;

public class Player(string Name, int Strength, int Intelligence, int Dexterity, float Accuracy, IItem? Weapon = null, int CurrentRoom = 1, int Health = 30, ushort Location = 1) {
    public string Name { get; set; } = Name;
    public int Strength { get; set; } = Strength;
    public int Intelligence { get; set; } = Intelligence;
    public int Dexterity { get; set; } = Dexterity;
    public int CurrentRoom { get; set; } = CurrentRoom;
    public float Accuracy { get; set; } = Accuracy;
    public int Health { get; set; } = Health;
    public ushort Location = Location;
    public IItem? Weapon { get; set; } = Weapon;
    public Inventory Inventory = new();
    public int DealDamage() {
        int Damage;
        float attackAccuracy = Accuracy;
        if (Weapon is null)
            Damage = 10;
        else {
            Damage = Weapon.Strength;
            attackAccuracy += Weapon.Strength/.5f;
        }
        
                var rand = new Random();
        var DieRoll = rand.Next(1,100);

        if (Accuracy * 100 >= DieRoll) {
            Console.WriteLine("The attack hit!");
            return rand.Next(5, Damage+1);
        }
        else {
            Console.WriteLine("The attack missed!");
            return 0;
        }
    }
}