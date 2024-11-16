namespace Dependencies.Dungeon;

public class Trap(int Id, TrapType TrapType) : IRoom
{
    public int Id { get; set; } = Id;
    public Monster.IMonster? Enemy { get; set; }
    public TrapType TrapType { get; set; } = TrapType;
    public string Description { get; set; } = "You enter the room and hear a sickening click as a ";

    public string Display() => Description + TrapType + "triggers!";
}