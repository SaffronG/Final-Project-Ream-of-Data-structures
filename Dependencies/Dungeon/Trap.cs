using Dependencies.Player;

namespace Dependencies.Dungeon;

public class Trap(int Id, TrapType? TrapType, IItem? Treasure = null) : IRoom
{
    public int Id { get; set; } = Id;
    public Monster.IMonster? Enemy { get; set; }
    public TrapType? TrapType { get; set; } = TrapType;
    public string Description { get; set; } = "You enter the room and hear a sickening click as a ";
    public RoomType Type { get; } = RoomType.Trap;
    public bool ContainsPlayer { get; set; } = false;
    public IItem? Treasure { get; set; } = Treasure;
    public string Display() => Description + TrapType + " trap triggers!";
}