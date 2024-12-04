using System.Collections;
using System.Text;

namespace Dependencies.Player;

public class Inventory(int Max = 5) {
    public Queue<IItem> Pouch = new();
    public int Max = Max;
    public bool Add(IItem item) {
        if (Pouch.Count >= Max) {
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
    public IItem? GetAt(int index) {
        int i = 1;
        foreach (var item in Pouch) {
            if (i == index) return item;
        }
        return null;
    }
    public bool UseItem(ref Player player, string item) {
        Queue<IItem> tempPouch = new();
        bool exists = false;
        foreach (var storedItem in Pouch) {
            if (storedItem.Name == item && !exists) {
                exists = true;
                storedItem.Effect(player);
            }
            else tempPouch.Enqueue(storedItem);
        }
        Pouch = tempPouch;
        return exists;
    }
    public string Display() {
        StringBuilder inventoryContents = new();
        int count = 0;
        foreach (var item in Pouch) {
            count++;
            inventoryContents.Append($" {count}) {item.Name}: {item.Description}\n\n");
        }
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