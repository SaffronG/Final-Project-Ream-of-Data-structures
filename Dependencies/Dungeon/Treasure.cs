using Dependencies.Player;

namespace Dependencies.Dungeon;

public class TreasureRoom(int Id, string Reward, IItem? Treasure = null) : IRoom
{
    public int Id { get; set; } = Id;
    public Monster.IMonster? Enemy { get; set; }
    public string Reward { get; set; } = Reward;
    public string Description { get; set; } = "The room is bare save for a small brown chest in the center of the room, you open it and find a";
    public RoomType Type { get; } = RoomType.Treasure;
    public bool ContainsPlayer { get; set; } = false;
    public IItem? Treasure { get; set; } = Treasure;
    public string Display() => Description + Reward;
}