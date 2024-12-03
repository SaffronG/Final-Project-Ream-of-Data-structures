using System.Collections;
using System.Text;

namespace Dependencies.Player;

public class Inventory(int Max = 5) {
    public Queue<IItem> Pouch = new();
    public int Max = Max;
    public bool Add(IItem item) {
        if (Pouch.Count + 1 >= Max) {
            Console.WriteLine("Oldest item was removed");
            Pouch.Dequeue();
        }
        Pouch.Enqueue(item);
        Console.WriteLine($"{item.Name} was added");
        return true;
    }
    public string Capacity() => $"Your pouch has a total capacity of {Max} and has {Max-Pouch.Count} slot(s) remaining.";
    public bool Contains(string item) {
        foreach (var storedItem in Pouch) if (storedItem.Name == item) return true;
        return false;
    }
    public bool UseItem(string item) {
        Queue<IItem> tempPouch = new();
        bool exists = false;
        foreach (var storedItem in Pouch) {
            if (storedItem.Name == item) exists = true;
            else tempPouch.Enqueue(storedItem);
        }
        Pouch = tempPouch;
        return exists;
    }
    public string Display() {
        StringBuilder inventoryContents = new();
        foreach (var item in Pouch)
            inventoryContents.Append($"{item.Name}: {item.Description}\n");
        return inventoryContents.ToString();
    }

    public static IItem? ToItem(Items item) {
        return item switch
        {
            Items.HealthPotion => new HealthPotion(),
            Items.MagicSword => new MagicSword(),
            _ => null,
        };
    }
}