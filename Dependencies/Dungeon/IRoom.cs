namespace Dependencies;

public interface IRoom
{
    public int Id { get; set; }
    public IMonster? Enemy { get; set; }
    public string Description { get; set; }
    public string Display();
}