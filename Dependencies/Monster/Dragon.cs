namespace Dependencies.Monster;

public class Dragon : IMonster
{
    public int Hp { get; set; }
    public String Name { get; set; } = "Dragon";
    public float Accuracy { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public string Description { get; }

    public Dragon() {
        Description = "a large scaly beast with massive wings that barely scrape the tops of the walls. The massive red, beast lumbers over with flame licking from its lips.";
        Accuracy = .75f;
        MinDamage = 10;
        MaxDamage = 20;
        Hp = 60;
    }
    public int DealDamage() {
        var rand = new Random();
        var DieRoll = rand.Next(1,100);

        if (Accuracy * 100 >= DieRoll) {
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