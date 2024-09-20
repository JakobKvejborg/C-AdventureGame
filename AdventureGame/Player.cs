using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

internal class Player
{

    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int Damage { get; set; }
    public int Strength { get; set; }
    public int Lifesteal {  get; set; }
    public int Armor { get; set; }
    public int DodgeChance { get; set; }
    public int GoldInPocket { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }

    public Player(string name, int maxHealth, int currentHealth, int damage, int strength, int lifesteal, 
        int armor, int dodgeChance, int goldInPocket, int experience, int level)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
        Damage = damage;
        Strength = strength;
        Lifesteal = lifesteal;
        Armor = armor;
        DodgeChance = dodgeChance;
        GoldInPocket = goldInPocket;
        Experience = experience;
        Level = level;
    }

    public void LevelUp()
    {
        MainWindow.labelExperience.Text = $"Experience: {Experience.ToString()}/{10 * (Level + Level)}";

        if (Experience >= 10 * (Level + Level))
        {
            Level++;
            Experience = 0;
        }
    }

    
}
