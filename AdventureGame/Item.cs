using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public static int CostToUpgrade { get; set; } = 50;
    public bool IsItemUpgraded { get; set; } = false;
    // Weapon item types
    public Item(string name, ItemType type, int damage, int strength, int fireDamage, int poisonDamage,
        int skillLevel, int lifesteal, int strengthRequirement, int levelRequirement)
    {
        Name = name;
        Type = type;
        Damage = damage;
        Strength = strength;
        FireDamage = fireDamage;
        PoisonDamage = poisonDamage;
        SkillLevel = skillLevel;
        Lifesteal = lifesteal;
        StrengthRequirement = strengthRequirement;
        LevelRequirement = levelRequirement;
    }

    // Constructor for armor type items
    public Item(string name, ItemType type, int health, int regeneration, int critChance, int strength, int dodgeChance, int armor, int skillLevel, int strengthRequirement, int levelRequirement)
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
        StrengthRequirement = strengthRequirement;
        LevelRequirement = levelRequirement;
    }

    // Constructor for mystical type items
    public Item(string name, ItemType type)
    {
        Name = name;
        Type = type;
    }

    public override string ToString()
    {
        var stats = new Dictionary<string, int>
    {
        { "Damage", Damage },
        { "Health", Health },
        { "Lifesteal", Lifesteal },
        { "Crit chance", CritChance },
        { "Armor", Armor },
        { "Dodge", DodgeChance },
        { "Strength", Strength },
        { "Regeneration", Regeneration },
        { "Skilllevel", SkillLevel },
        { "Strength req", StrengthRequirement },
        { "Level req", LevelRequirement }
    };
        // Only include stats greater than 0
        return string.Join("\n", stats.Where(stat => stat.Value > 0).Select(stat => $"{stat.Key}: {stat.Value}"));
    }

    public Item CloneItem() // TODO create a category for each item type
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
        Name = "Upgraded " + Name;
        LevelRequirement += 1;
        IsItemUpgraded = true;
        switch (Type)
        {
            case ItemType.WeaponRightHand:
                // Randomly upgrade a stat for weapons
                int weaponUpgradeChoice = random.Next(1, 4); // 1 to 4 for three stats
                switch (weaponUpgradeChoice)
                {
                    case 1: // Damage
                        Damage += random.Next(1, 3); // Increase Damage by 1 to 2
                        break;
                    case 2: // Strength
                        Strength += random.Next(1, 6); // Increase Strength by 1 to 5
                        break;
                    case 3: // Lifesteal
                        Lifesteal += random.Next(4, 16); // Increase Lifesteal by 1 or 4
                        break;
                }
                break;

            case ItemType.Armor:
                // Randomly upgrade a stat for armor
                int armorUpgradeChoice = random.Next(1, 3); // 1 to 3 for two stats
                switch (armorUpgradeChoice)
                {
                    case 1: // Health
                        Health += random.Next(5, 24); // Increase Health by 5 to 23
                        break;
                    case 2: // Armor
                        Armor += random.Next(1, 6); // Increase Armor by 1 to 5
                        break;
                        // Add more cases if needed
                }
                break;

            case ItemType.Boots:
                // Randomly upgrade a stat for armor
                int bootsUpgradeChoice = random.Next(1, 3); // 1 to 3 for three stats
                switch (bootsUpgradeChoice)
                {
                    case 1: // Health
                        Health += random.Next(1, 14); // Increase Health by 1 to 13
                        break;
                    case 2: // Dodge Chance
                        DodgeChance += random.Next(1, 6); // Increase Dodge Chance by 1 to 5
                        break;
                        // Add more cases if needed
                }
                break;
            case ItemType.Gloves:
                // Randomly upgrade a stat for armor
                int GlovesUpgradeChoice = random.Next(1, 4); // 1 to 4 for three stats
                switch (GlovesUpgradeChoice)
                {
                    case 1: // Armor
                        Armor += random.Next(1, 4); // Increase Health by 1 to 3
                        break;
                    case 2: // Strength
                        Strength += random.Next(1, 8); // Increase Strength by 1 to 5
                        break;
                    case 3:
                        Regeneration += random.Next(1, 4); // increase regen by 1 to 3
                        break;
                        // Add more cases if needed
                }
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
    Ring,
    Amulet,
    Bracers,
    Leggings,
    Shoulders,
    Gloves,
    Belt
    // Add more as needed
}

