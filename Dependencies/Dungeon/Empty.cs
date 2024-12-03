namespace Dependencies.Dungeon;

public class Empty(int Id) : IRoom
{
    public int Id { get; set; } = Id;
    public Monster.IMonster? Enemy { get; set; }
    public string Description { get; set; } = "The room empty, the only thing keeping you company is a long-aged skeleton in the corner of the room";
    public bool ContainsPlayer { get; set; } = false;
    public RoomType Type { get; } = RoomType.Empty;
    public string Display() => Description;
}