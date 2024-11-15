namespace Dependencies;

public interface Room
{
    public int Id { get; set; }

}

public enum RoomType {
    EMPTY,
    TREASURE,
    LAIR,
    TRAP,
    SPRING,
    BOSS
}