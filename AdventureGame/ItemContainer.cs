using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class ItemContainer
{
    public List<Item> noItems;
    public List<Item> items1;
    public List<Item> items2;

    public ItemContainer() 
    {
        noItems = new List<Item>();
        items1 = new List<Item>();
        items2 = new List<Item>();
        AddItemsToList();
    }

    public void AddItemsToList()
    {
        // WEAPONS string name, int damage, int strength, int fireDamage, int poisonDamage, int skillLevel, int strengthRequirement, int levelRequirement
        Item item1a = new("Normal Axe", ItemType.WeaponRightHand, 1, 0, 0, 0, 0, 0, 2, 2);
        Item item2a = new("Sword", ItemType.WeaponRightHand, 2, 0, 0, 0, 0, 0, 3, 3);

        // ARMORS string name, type, health, regen, CritChance, strength, int dodgeChance, int armor, int skillLevel, int strengthRequirement, int levelRequirement
        Item item1b = new("Rusty Armor", ItemType.Armor, 1, 0, 0, 0, 0, 1, 0, 2, 1);
        Item item2b = new("Cloak", ItemType.Armor, 0, 0, 0, 0, 5, 2, 0, 2, 3);
        Item item3b = new("Rags", ItemType.Armor, 5, 0, 0, 0, 0, 0, 0, 0, 2);
        Item item4b = new("Boots", ItemType.Boots, 0, 0, 0, 0, 0, 1, 0, 0, 2);
        Item item5b = new("Sandals", ItemType.Boots, 0, 0, 0, 0, 8, 0, 0, 0, 2);
        Item item6b = new("Gloves", ItemType.Gloves, 0, 0, 0, 2, 0, 1, 0, 0, 4);
        Item item7b = new("Leather Gloves", ItemType.Gloves, 11, 0, 0, 0, 0, 1, 0, 0, 5);
        Item item8b = new("Health Boots", ItemType.Boots, 0, 2, 0, 0, 0, 0, 0, 3, 3);
        Item item9b = new("Rusty Boots", ItemType.Boots, 5, 2, 5, 3, 1, 0, 0, 3, 3);

        // List of items 1
        noItems.Add(null);
        items1.Add(item1a);
        items1.Add(item2a);
        items1.Add(item1b);
        items1.Add(item6b);
        items1.Add(null);
        items1.Add(null);
        items1.Add(null);
        items1.Add(null);
        items1.Add(null);
        items1.Add(null);
        items1.Add(null);
        items1.Add(null);
        items1.Add(null);
        items1.Add(null);
        items1.Add(null);
        items1.Add(null);

        // List of items 2
        items2.Add(item1b);
        items2.Add(item1a);
        items2.Add(item2b);
        items2.Add(item3b);
        items2.Add(item4b);
        items2.Add(item5b);
        items2.Add(item7b);
        items2.Add(item8b);
        items2.Add(item9b);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);


    }

}