namespace Dependencies;

public class GelatinousCube : IMonster
{
    public int Hp { get; set; }
    public float Accuracy { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public string Description { get; }

    public GelatinousCube() {
        Description = "a large green ball of gelatin filled with skeletons, armor pieces, and some pieces of flesh still disolving";
        Accuracy = 0.25f;
        MinDamage = 10;
        MaxDamage = 20;
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