namespace Dependencies.Player;

public class Inventory(int Max = 5) {
    public Queue<IItem> Pouch = new();
    public int Max = Max;
    public void Add(IItem item) {
        if (Pouch.Count >= Max) {
            Console.WriteLine("Oldest item was removed");
            Pouch.Dequeue();
        }
        Pouch.Enqueue(item);
        Console.WriteLine("Item was added");
    }
    public string Capacity() => $"Your pouch has a total capacity of {Max} and has {Max-Pouch.Count} slot(s) remaining.";
}