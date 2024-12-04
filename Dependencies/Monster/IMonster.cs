namespace Dependencies.Monster;

public interface IMonster {
    public int Hp { get; set; }
    public string Name { get; set; }
    public float Accuracy { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public string Description { get; }
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