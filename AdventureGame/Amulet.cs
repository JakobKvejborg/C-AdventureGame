using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class Amulet : Item
{
    private static Random _random = new Random();
    public string Tier { get; private set; }

    public Amulet(string name = "Mystic Amulet", string tier = "Normal") : base(name, ItemType.Amulet)
    {
        Tier = tier;
        AssignStatsBasedOnTier();
    }
    private void AssignStatsBasedOnTier()
    {
        switch (Tier)
        {
            case "Normal":
                Strength = _random.Next(0, 2);           // Strength boost between 0 and 4
                DodgeChance = _random.Next(0, 3);
                CritChance = _random.Next(0, 5);
                Regeneration = _random.Next(0, 5);
                LevelRequirement = _random.Next(4, 9);   // Level 4-8
                break;

            case "Magic":
                Strength = _random.Next(0, 3);       
                DodgeChance = _random.Next(1, 4);
                CritChance = _random.Next(5, 8);
                Regeneration = _random.Next(2, 6);
                LevelRequirement = _random.Next(4, 13); 
                break;

            case "Rare":
                Strength = _random.Next(2, 5);          
                DodgeChance = _random.Next(3, 6);
                CritChance = _random.Next(3, 8);
                Regeneration = _random.Next(4, 8);
                Lifesteal = _random.Next(0, 8);
                LevelRequirement = _random.Next(9, 17);  // Level 9-13
                break;

            case "Epic":
                Strength = _random.Next(3, 9);      
                DodgeChance = _random.Next(3, 8);
                CritChance = _random.Next(4, 11);
                Regeneration = _random.Next(5, 30);
                Lifesteal = _random.Next(0, 15);
                LevelRequirement = _random.Next(15, 23); // Level 15-20
                break;

            case "Legendary":
                Strength = _random.Next(5, 15);         // Strength boost between 15 and 20
                DodgeChance = _random.Next(4, 14);
                CritChance = _random.Next(8, 15);
                Lifesteal = _random.Next(0, 20);
                Regeneration = _random.Next(5, 50);
                LevelRequirement = _random.Next(22, 35);
                break;

            default:
                throw new ArgumentException("Invalid tier provided.");
        }
    }
}

