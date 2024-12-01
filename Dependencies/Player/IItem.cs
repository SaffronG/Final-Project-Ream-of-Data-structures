namespace Dependencies.Player;

public interface IItem {
    string Name { get; set; }
    string Description { get; set; }
    public abstract void Effect();
}