using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class Amulet : Item
{
    private static Random _random = new Random();

    public Amulet(string name = "Mystic Amulet") : base(name, ItemType.Amulet)
    {
        // Randomize attributes for the amulet
        Strength = _random.Next(0, 5);        // Strength boost between 0 and 4
        DodgeChance = _random.Next(0, 6);      
        CritChance = _random.Next(0, 5);     
        Regeneration = _random.Next(0, 2);

        // Set level requirements randomly
        LevelRequirement = _random.Next(4, 9);
    }

}
