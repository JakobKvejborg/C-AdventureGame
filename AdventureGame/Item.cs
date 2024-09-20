using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame
{
    internal class Item
    {

        private String Name { get; }
        private int Damage { get; }
        private int DodgeChance { get; }
        private int Strength { get; }
        private int Armor { get; }
        private int FireDamage { get; }
        private int PoisonDamage { get; }
        private int SkillLevel { get; }
        private int StrengthRequirement { get; }
        private int LevelRequirement { get; }

        public Item(String name, int damage, int strength, int fireDamage, int poisonDamage, int skillLevel, int strengthRequirement, int levelRequirement)
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

        public Item(String name, int dodgeChance, int armor, int skillLevel, int strengthRequirement, int levelRequirement)
        {
            Name = name;
            DodgeChance = dodgeChance;
            Armor = armor;
            SkillLevel = skillLevel;
            StrengthRequirement = strengthRequirement;
            LevelRequirement = levelRequirement;
        }

    }
}
