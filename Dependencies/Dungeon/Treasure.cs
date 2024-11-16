namespace Dependencies.Dungeon;

public class Treasure(int Id, string Reward) : IRoom
{
    public int Id { get; set; } = Id;
    public Monster.IMonster? Enemy { get; set; }
    public string Reward { get; set; } = Reward;
    public string Description { get; set; } = "The room is bare save for a small brown chest in the center of the room, you open it and find a";

    public string Display() => Description + Reward;
}