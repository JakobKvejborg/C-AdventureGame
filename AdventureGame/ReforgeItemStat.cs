using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class ReforgeItemStat
{

    public static int PriceToReforgeFrog { get; set; } = 100;
    public static double ReforgeModifier { get; set; } = 0.00;
    public static double LilyReforgeModifer { get; set; } = 0.00;

    public int ReforgeStat(int statValue)
    {
        Random rand = new Random();
        double randomMultiplier = rand.NextDouble() * (1.50 - 0.90) + 0.90 + ReforgeModifier + LilyReforgeModifer; // Random value between 0.90 and 1.30
        //double randomMultiplier = rand.NextDouble() * (10 - 5) + 5; // for testing
        int newStatValue = (int)(statValue * randomMultiplier);  // Multiply stat by random value
        return newStatValue;
    }

    public void ReforgeItemProperty(Item item, string statName)
    {
        var property = item.GetType().GetProperty(statName);

        if (property != null && property.CanWrite)
        {
            object currentValue = property.GetValue(item);
            if (currentValue is int statValue)
            {
                int newStatValue = ReforgeStat(statValue);
                property.SetValue(item, newStatValue);
                item.IsItemReforged = true; // Each item can only be reforged once
            }
        }
    }
}