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
    public int FireDamage { get; set; }
    public int PoisonDamage { get; set; }
    public int SkillLevel { get; set; }
    public int StrengthRequirement { get; set; }
    public int Lifesteal { get; set; }
    public int LevelRequirement { get; set; }

    public Item(string name, ItemType type, int damage, int strength, int fireDamage, int poisonDamage, 
        int skillLevel, int strengthRequirement, int lifesteal, int levelRequirement)
    {
        Name = name;
        Type = type;
        Damage = damage;   
        Strength = strength;
        FireDamage = fireDamage;
        PoisonDamage = poisonDamage;
        SkillLevel = skillLevel;
        StrengthRequirement = strengthRequirement;
        Lifesteal = lifesteal;
        LevelRequirement = levelRequirement;
    }

    // Constructor for armor type items
    public Item(string name, ItemType type, int health, int dodgeChance, int armor, int skillLevel, int strengthRequirement, int levelRequirement)
    {
        Name = name;
        Type = type;
        Health = health;
        DodgeChance = dodgeChance;
        Armor = armor;
        SkillLevel = skillLevel;
        StrengthRequirement = strengthRequirement;
        LevelRequirement = levelRequirement;
    }

    public override string ToString()
    {
        return
               $"Damage: {Damage}\n" +
               $"Health: {Health}\n" +
               $"Lifesteal: {Lifesteal}\n" +
               $"Armor: {Armor}\n" +
               $"Dodge: {DodgeChance}%\n" +
               $"Strength: {Strength}\n" +
               $"Level req: {LevelRequirement}\n";
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
