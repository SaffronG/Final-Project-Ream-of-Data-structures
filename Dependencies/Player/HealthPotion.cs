using Dependencies.Monster;

namespace Dependencies.Player;

public class HealthPotion : IItem
{
    public string Name { get; set; } = "Health Potion";
    public string Description { get; set; } = "The thick, red liquid runs down your throat with an intense bitterness, but you feel your wounds closing up. \n This is a healing potion!";
    public int Strength { get; set; } = 0;

    public void Effect(Player player)
    {
        player.Health = player.Health + (int) (player.Health * .5);
        Console.WriteLine($"You regained {player.Health * .5} HP!");
    }
}
