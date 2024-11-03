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
    public List<Item> items3;
    public List<Item> items4;

    public List<Item> weakAmulets;

    public ItemContainer()
    {
        noItems = new List<Item>();
        items1 = new List<Item>();
        items2 = new List<Item>();
        items3 = new List<Item>();
        items4 = new List<Item>();
        weakAmulets = new List<Item>();
        AddItemsToList();
    }

    public void AddItemsToList()
    {
        // WEAPONS string name, type, int damage, int strength, int fireDamage, int poisonDamage, int skillLevel, int strengthRequirement, int levelRequirement
        Item item1a = new("Normal Axe", ItemType.WeaponRightHand, 1, 0, 0, 0, 0, 0, 2, 2);
        Item item2a = new("Sword", ItemType.WeaponRightHand, 2, 0, 0, 0, 0, 0, 3, 3);
        Item item3a = new("Blood Spear", ItemType.WeaponRightHand, 2, 0, 0, 0, 0, 5, 8, 1);
        Item item4a = new("Pike", ItemType.WeaponRightHand, 3, 0, 0, 0, 0, 0, 5, 6);
        Item item5a = new("Small Knife", ItemType.WeaponRightHand, 2, 3, 0, 0, 0, 0, 0, 2);
        Item item6a = new("Spear", ItemType.WeaponRightHand, 3, 0, 0, 0, 0, 0, 5, 1);

        Item item7a = new("Scythe", ItemType.WeaponRightHand, 4, 3, 0, 0, 0, 2, 5, 4);
        Item item8a = new("Hammer", ItemType.WeaponRightHand, 5, 0, 0, 0, 0, 0, 8, 6);

        // ARMORS string name, type, health, regen, CritChance, strength, int dodgeChance, int armor, int skillLevel, int strengthRequirement, int levelRequirement
        Item item1b = new("Rusty Armor", ItemType.Armor, 1, 0, 0, 0, 0, 1, 0, 2, 1);
        Item item2b = new("Cloak", ItemType.Armor, 0, 0, 0, 0, 5, 2, 0, 2, 3);
        Item item3b = new("Rags", ItemType.Armor, 5, 0, 0, 0, 0, 0, 0, 0, 2);
        Item item4b = new("Boots", ItemType.Boots, 0, 0, 0, 0, 0, 1, 0, 0, 2);
        Item item5b = new("Sandals", ItemType.Boots, 0, 0, 0, 0, 8, 0, 0, 0, 2);
        Item item6b = new("Gloves", ItemType.Gloves, 0, 0, 0, 2, 0, 1, 0, 0, 4);
        Item item7b = new("Leather Gloves", ItemType.Gloves, 11, 0, 0, 0, 0, 1, 0, 0, 5);
        Item item8b = new("Health Boots", ItemType.Boots, 0, 2, 0, 0, 0, 0, 0, 3, 3);
        Item item9b = new("Rusty Boots", ItemType.Boots, 5, 1, 3, 2, 1, 0, 0, 3, 3);

        Item item10b = new("Bronze Boots", ItemType.Boots, 0, 2, 0, 6, 6, 3, 0, 7, 2);
        Item item11b = new("Swift Boots", ItemType.Boots, 10, 0, 10, 0, 7, 3, 0, 7, 1);
        Item item12b = new("Plate", ItemType.Armor, 0, 0, 5, 3, 0, 3, 0, 5, 3);
        Item item13b = new("Bronze Plate", ItemType.Armor, 20, 0, 2, 3, 2, 3, 0, 5, 6);
        Item item14b = new("Rusty Plate", ItemType.Armor, 0, 1, 2, 3, 2, 4, 0, 9, 6);
        Item item15b = new("Bronze Gloves", ItemType.Gloves, 0, 0, 8, 5, 0, 2, 0, 5, 6);

        // AMULET
        Amulet amulet1 = new Amulet("Mystic Amulet");
        Amulet amulet2 = new Amulet("Magic Amulet");
        Amulet amulet3 = new Amulet("Millennium Amulet");

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
        items1.Add(null);

        // List of items 2
        items2.Add(item1b);
        items2.Add(item2b);
        items2.Add(item3b);
        items2.Add(item4b);
        items2.Add(item5b);
        items2.Add(item7b);
        items2.Add(item8b);
        items2.Add(item9b);
        items2.Add(item1a);
        items2.Add(item3a);
        items2.Add(item4a);
        items2.Add(item5a);
        items2.Add(item6a);
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
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);

        // List of items 3
        items3.Add(item6a);
        items3.Add(item7a);
        items3.Add(item8a);
        items3.Add(item2b);
        items3.Add(item10b);
        items3.Add(item11b);
        items3.Add(item12b);
        items3.Add(item13b);
        items3.Add(item14b);
        items3.Add(item15b);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);
        items3.Add(null);

        // List of special items
        weakAmulets.Add(amulet1);
        weakAmulets.Add(amulet2);
        weakAmulets.Add(amulet3);
        weakAmulets.Add(null);
        weakAmulets.Add(null);
        weakAmulets.Add(null);

    }

}