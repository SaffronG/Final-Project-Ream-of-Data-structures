using Dependencies.Player;

namespace Dependencies.Dungeon;

public class Exit(int Id) : IRoom
{
    public int Id { get; set; } = Id;
    public Monster.IMonster? Enemy { get; set; }
    public string Description { get; set; } = "The staleness of the air breaks away and slowly takes on the slight scent of grass, you see a light at the end of the tunnel, you have reached the end!";
    public bool ContainsPlayer { get; set; } = false;
    public RoomType Type { get; } = RoomType.Door;
    public IItem? Treasure { get; set; } = null;
    public string Display() => Description;
}