namespace Dependencies.Player;

public interface IItem {
    string Name { get; set; }
    string Description { get; set; }
    public int Strength { get; set; }
    public abstract void Effect(Player player);
}