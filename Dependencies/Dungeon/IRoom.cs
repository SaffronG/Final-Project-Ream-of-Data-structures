namespace Dependencies.Dungeon;

public interface IRoom
{
    public int Id { get; set; }
    public Monster.IMonster? Enemy { get; set; }
    public string Description { get; set; }
    public abstract string Display();
}