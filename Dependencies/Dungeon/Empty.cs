using Dependencies.Player;

namespace Dependencies.Dungeon;

public class Empty(int Id, IItem? Treasure = null) : IRoom
{
    public int Id { get; set; } = Id;
    public Monster.IMonster? Enemy { get; set; }
    public string Description { get; set; } = "The room empty, the only thing keeping you company is a long-aged skeleton in the corner of the room";
    public bool ContainsPlayer { get; set; } = false;
    public RoomType Type { get; } = RoomType.Empty;
    public IItem? Treasure { get; set; } = Treasure;
    public string Display() => Description;
}