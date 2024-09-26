using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

internal class Item
{

    private string Name { get; }
    private int Damage { get; }
    private int DodgeChance { get; }
    private int Strength { get; }
    private int Armor { get; }
    private int FireDamage { get; }
    private int PoisonDamage { get; }
    private int SkillLevel { get; }
    private int StrengthRequirement { get; }
    private int LevelRequirement { get; }

    public Item(string name, int damage, int strength, int fireDamage, int poisonDamage, 
        int skillLevel, int strengthRequirement, int levelRequirement)
    {
        Name = name;
        Damage = damage;   
        Strength = strength;
        FireDamage = fireDamage;
        PoisonDamage = poisonDamage;
        SkillLevel = skillLevel;
        StrengthRequirement = strengthRequirement;
        LevelRequirement = levelRequirement;
    }

    // Constructor for armor type items
    public Item(string name, int dodgeChance, int armor, int skillLevel, int strengthRequirement, int levelRequirement)
    {
        Name = name;
        DodgeChance = dodgeChance;
        Armor = armor;
        SkillLevel = skillLevel;
        StrengthRequirement = strengthRequirement;
        LevelRequirement = levelRequirement;
    }

    public override string ToString()
    {
        return Name;
    }

}
