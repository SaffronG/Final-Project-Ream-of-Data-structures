using Dependencies.Player;

namespace Dependencies.Dungeon;

public interface IRoom
{
    public int Id { get; set; }
    public Monster.IMonster? Enemy { get; set; }
    public string Description { get; set; }
    public RoomType Type { get; }
    public abstract string Display();
    public bool ContainsPlayer { get; set; }
    public IItem? Treasure { get; set; }
}