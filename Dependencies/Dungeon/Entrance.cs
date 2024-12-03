namespace Dependencies.Dungeon;

public class Entrance : IRoom
{
    public int Id { get; set; } = 1;
    public Monster.IMonster? Enemy { get; set; }
    public string Description { get; set; } = "You feel the light of the entrance on your back as you steel yourself to traverse the dark depths before you.";
    public bool ContainsPlayer { get; set; } = false;
    public RoomType Type { get; } = RoomType.Door;
    public string Display() => Description;
}