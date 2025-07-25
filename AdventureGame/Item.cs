﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AdventureGame;

public class Item
{

    public string Name { get; set; }
    public ItemType Type { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int DodgeChance { get; set; }
    public int Strength { get; set; }
    public int Armor { get; set; }
    public int SkillLevel { get; set; }
    public int Lifesteal { get; set; }
    public int FireDamage { get; set; }
    public int PoisonDamage { get; set; }
    public int Regeneration { get; set; }
    public int StrengthRequirement { get; set; }
    public int LevelRequirement { get; set; }
    public int CritChance { get; set; }
    public int CritDamage { get; set; }
    public static int CostToUpgrade { get; set; } = 40;
    public bool IsItemUpgraded { get; set; }
    public bool IsItemReforged { get; set; }
    public static int SmithUpgradeMultiplication = 1;

    // Weapon item types
    public Item(string name, ItemType type, int damage, int strength, int fireDamage, int poisonDamage,
        int skillLevel, int lifesteal, int critDamage, int strengthRequirement, int levelRequirement)
    {
        Name = name;
        Type = type;
        Damage = damage;
        Strength = strength;
        FireDamage = fireDamage;
        PoisonDamage = poisonDamage;
        SkillLevel = skillLevel;
        Lifesteal = lifesteal;
        CritDamage = critDamage;
        StrengthRequirement = strengthRequirement;
        LevelRequirement = levelRequirement;
    }

    // Constructor for armor type items
    public Item(string name, ItemType type, int health, int regeneration, int critChance, int strength, int dodgeChance, int armor, int skillLevel, int lifesteal, int critDamage, int strengthRequirement, int levelRequirement)
    {
        Name = name;
        Type = type;
        Health = health;
        Regeneration = regeneration;
        CritChance = critChance;
        Strength = strength;
        DodgeChance = dodgeChance;
        Armor = armor;
        SkillLevel = skillLevel;
        Lifesteal = lifesteal;
        CritDamage = critDamage;
        StrengthRequirement = strengthRequirement;
        LevelRequirement = levelRequirement;
    }

    // Constructor for mystical type items
    public Item(string name, ItemType type)
    {
        Name = name;
        Type = type;
    }

    // Constructor for ImprovedRandomItem type items
    public Item(ItemType itemType)
    {
        Type = itemType;
    }

    public override string ToString()
    {
        var stats = new Dictionary<string, int>
    {
        { "Damage", Damage },
        { "Health", Health },
        { "Lifesteal", Lifesteal },
        { "Crit chance", CritChance },
        { "Crit damage", CritDamage },
        { "Armor", Armor },
        { "Dodge", DodgeChance },
        { "Strength", Strength },
        { "Regen", Regeneration },
        { "Skilllevel", SkillLevel },
        { "Str req", StrengthRequirement },
        { "Level req", LevelRequirement }  
    };
        // Only include stats greater than 0
        return string.Join("\n", stats.Where(stat => stat.Value > 0).Select(stat => $"{stat.Key}: {stat.Value}"));
    }

    public Item CloneItem()
    {
        return (Item)this.MemberwiseClone();
    }

    public void UpgradeItem()
    {
        if (IsItemUpgraded || Type == ItemType.Amulet)
        {
            return;
        }
        Random random = new Random();
        Name = "Upg. " + Name;
        Item.CostToUpgrade += 25;
        LevelRequirement += 1;
        IsItemUpgraded = true;
        switch (Type)
        {
            case ItemType.WeaponRightHand:
                // Randomly upgrade a stat for weapons
                int weaponUpgradeChoice = random.Next(1, 5); // 1 to 5 for four stats
                switch (weaponUpgradeChoice)
                {
                    case 1: // Damage
                        Damage += random.Next(1, 3) + SmithUpgradeMultiplication - 1;
                        break;
                    case 2: // Strength
                        Strength += random.Next(1, 4) * SmithUpgradeMultiplication; // Increase Strength by 1 to 3
                        break;
                    case 3: // Lifesteal
                        Lifesteal += random.Next(1, 10) * SmithUpgradeMultiplication; // Increase Lifesteal by 1 to 9
                        break;
                    case 4: // Crit Damage
                        CritDamage += random.Next(3, 16) * SmithUpgradeMultiplication;
                        break;
                }
                break;

            case ItemType.Armor:
                // Randomly upgrade a stat for armor
                int armorUpgradeChoice = random.Next(1, 3); // 1 to 3 for two stats
                switch (armorUpgradeChoice)
                {
                    case 1: // Health
                        Health += random.Next(5, 51) * SmithUpgradeMultiplication + SmithUpgradeMultiplication; // Increase Health by 5 to 50
                        break;
                    case 2: // Armor
                        Armor += random.Next(1, 3) * SmithUpgradeMultiplication; // Increase Armor by 1 to 2
                        break;
                        // Add more cases if needed
                }
                break;

            case ItemType.Boots:
                // Randomly upgrade a stat for boots
                int bootsUpgradeChoice = random.Next(1, 3); // 1 to 3 for three stats
                switch (bootsUpgradeChoice)
                {
                    case 1: // Health
                        Health += random.Next(1, 25) * SmithUpgradeMultiplication + SmithUpgradeMultiplication; // Increase Health by 1 to 13
                        break;
                    case 2: // Dodge Chance
                        DodgeChance += random.Next(1, 6) * SmithUpgradeMultiplication; // Increase Dodge Chance by 1 to 5
                        break;
                        // Add more cases if needed
                }
                break;

            case ItemType.Gloves:
                // Randomly upgrade a stat for gloves
                int glovesUpgradeChoice = random.Next(1, 5); // 1 to 5 for four stats
                switch (glovesUpgradeChoice)
                {
                    case 1: // Armor
                        Armor += random.Next(1, 3) * SmithUpgradeMultiplication; 
                        break;
                    case 2: // Strength
                        Strength += random.Next(1, 3) * SmithUpgradeMultiplication;
                        break;
                    case 3:
                        Regeneration += random.Next(1, 8) * SmithUpgradeMultiplication * SmithUpgradeMultiplication;
                        break;
                    case 4:
                        CritDamage += random.Next(3, 20) + SmithUpgradeMultiplication + SmithUpgradeMultiplication + SmithUpgradeMultiplication;
                        break;
                        // Add more cases if needed
                }
                break;

            case ItemType.Leggings:
                int leggingsUpgradeChoice = random.Next(1, 5); // 1 to 5 for three stats
                switch (leggingsUpgradeChoice)
                {
                    case 1:
                        DodgeChance += random.Next(2, 7) * SmithUpgradeMultiplication;
                        break;
                    case 2:
                        Strength += random.Next(1, 4) * SmithUpgradeMultiplication;
                        break;
                    case 3:
                        CritChance += random.Next(1, 11) * SmithUpgradeMultiplication;
                        break;
                    case 4:
                        Health += random.Next(1, 46) * SmithUpgradeMultiplication;
                        break;
                        // Add more cases if needed
                }
                break;

            case ItemType.Helmet:
                // Randomly upgrade a stat for armor
                int HelmetUpgradeChoice = random.Next(1, 5); // 1 to 5 for three stats
                switch (HelmetUpgradeChoice)
                {
                    case 1:
                        Armor += random.Next(1, 2) * SmithUpgradeMultiplication;
                        break;
                    case 2:
                        Strength += random.Next(1, 3) * SmithUpgradeMultiplication;
                        break;
                    case 3:
                        Health += random.Next(1, 35) * SmithUpgradeMultiplication;
                        break;
                    case 4:
                        Regeneration += random.Next(1, 15) * SmithUpgradeMultiplication * SmithUpgradeMultiplication;
                        break;
                }
                break;

            case ItemType.Belt:
                int beltUpgradeChoice = random.Next(1, 4); // 1 to 4 for three stats
                switch (beltUpgradeChoice)
                {
                    case 1:
                        Armor += random.Next(1, 3) * SmithUpgradeMultiplication; // Increase Health by 1 to 2
                        break;
                    case 2:
                        Health += random.Next(1, 23) * SmithUpgradeMultiplication + SmithUpgradeMultiplication;
                        break;
                    case 3:
                        CritDamage += random.Next(3, 15) + SmithUpgradeMultiplication + SmithUpgradeMultiplication + SmithUpgradeMultiplication;
                        break;
                }
                break;

            default:
                // Handle unspecified ItemTypes here
                Lifesteal += random.Next(1, 10) + SmithUpgradeMultiplication + SmithUpgradeMultiplication;
                break;
        }
    }

}

public enum ItemType
{
    WeaponLeftHand,
    WeaponRightHand,
    Armor,
    Boots,
    Helmet,
    //Ring,
    Amulet,
    //Bracers,
    Leggings,
    Shoulders,
    Gloves,
    Belt
}

