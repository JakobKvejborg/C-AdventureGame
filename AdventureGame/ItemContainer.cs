﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class ItemContainer
{
    public List<Item> items1;
    public List<Item> items2;

    public ItemContainer() 
    {
        items1 = new List<Item>();
        items2 = new List<Item>();
        AddItemsToList();
    }

    public void AddItemsToList()
    {
        // WEAPONS string name, int damage, int strength, int fireDamage, int poisonDamage, int skillLevel, int strengthRequirement, int levelRequirement
        Item item1a = new Item("Normal Axe", ItemType.WeaponRightHand, 1, 0, 0, 0, 0, 0, 0, 2);
        Item item2a = new Item("OP TEST ITEM", ItemType.WeaponRightHand, 11, 0, 0, 0, 0, 0, 0, 2);

        // ARMORS string name, int dodgeChance, int armor, int skillLevel, int strengthRequirement, int levelRequirement
        Item item1b = new Item("Rusty Armor", ItemType.Armor, 1, 0, 2, 0, 2, 0);

        // List of items 1
        items1.Add(item1a);
        items1.Add(item2a);
        //items1.Add(null);
        //items1.Add(null);
        //items1.Add(null);
        //items1.Add(null);
        //items1.Add(null);

        // List of items 2
        items2.Add(item1b);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);
        items2.Add(null);


    }

}