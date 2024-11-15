namespace Dependencies;

public class Zombie : IMonster
{
    public int Hp { get; set; }
    public float Accuracy { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public string Description { get; }

    public Zombie() {
        Description = "a disheveled form of a human that smells of rotting flesh and has white hollowed eyes";
        Accuracy = .45f;
        MinDamage = 5;
        MaxDamage = 15;
    }
    public int DealDamage() {
        var rand = new Random();
        var DieRoll = rand.Next(1,100);

        if (Accuracy * 100 <= DieRoll) {
            Console.WriteLine("The attack hit!");
            return rand.Next(MinDamage, MaxDamage+1);
        }
        else {
            Console.WriteLine("The attack missed!");
            return 0;
        }
    }
    public string Display() => Description;
}