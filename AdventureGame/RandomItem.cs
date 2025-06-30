using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;
public enum ItemQuality
{
    Normal,
    Magic,
    Rare,
    Epic,
    Legendary,
    Godly
}
public class RandomItem : Item
{
    private static Random _random = new Random();
    public ItemQuality Quality { get; private set; }

    public RandomItem(string name, ItemType itemType, ItemQuality quality = ItemQuality.Normal) : base(name, itemType)
    {
        AssignStatsBasedOnTypeAndQuality(itemType, quality);
        Quality = quality;
    }

    private void AssignStatsBasedOnTypeAndQuality(ItemType itemType, ItemQuality quality)
    {
        int multiplier = quality switch
        {
            ItemQuality.Magic => 2,
            ItemQuality.Rare => 3,
            ItemQuality.Epic => 4,
            ItemQuality.Legendary => 5,
            ItemQuality.Godly => 6,
            _ => 1 // Normal quality has a multiplier of 1
        };

        switch (itemType)
        {
            case ItemType.Armor:
                Strength = _random.Next(0, 2 * multiplier);
                Health = _random.Next(2, 19) * multiplier;
                Armor = _random.Next(1, 2 + multiplier);
                LevelRequirement = _random.Next(1, 5) + multiplier + multiplier + multiplier + multiplier - 4;
                break;

            case ItemType.Gloves:
                var critDamageValues = new[] { 0, 3, 6 }; // Predefined possible values for CritDamage
                CritDamage = critDamageValues[_random.Next(critDamageValues.Length)] * multiplier;
                Strength = _random.Next(0, 3 * multiplier);
                CritChance = _random.Next(1, 9 + multiplier);
                Armor = _random.Next(0, 3 + multiplier - 1);
                StrengthRequirement = _random.Next(2, 6 * multiplier);
                LevelRequirement = _random.Next(1, 4) * multiplier;
                break;

            case ItemType.Boots:
                DodgeChance = _random.Next(0, 5 + multiplier + multiplier);
                Armor = _random.Next(0, 3) + multiplier - 1;
                Health = _random.Next(1, 11 + multiplier + multiplier - 1) * multiplier;
                LevelRequirement = (_random.Next(3, 7) * multiplier) + multiplier + multiplier + multiplier - 4;
                break;

            case ItemType.Belt:
                Armor = _random.Next(0, 2 + multiplier - 1);
                Strength = _random.Next(0, 2 * multiplier);
                Regeneration = _random.Next(1, 3 * multiplier);
                Lifesteal = _random.Next(0, 9 * multiplier);
                StrengthRequirement = _random.Next(1, 6) * multiplier;
                LevelRequirement = (_random.Next(1, 6) * multiplier) + multiplier - 1;
                break;

            case ItemType.WeaponRightHand:
                int min = (int)((multiplier + 0.25) * 2);
                int max = (int)((multiplier + 0.25) * 4);
                Damage = _random.Next(min, max);
                Damage = (int)(_random.Next((int)multiplier / 2 + 1, 7) * (multiplier + 0.25));
                CritChance = _random.Next(0, 4 + multiplier - 1);
                Strength = _random.Next(1, 3 * multiplier);
                LevelRequirement = (_random.Next(1, 5) * multiplier) + multiplier - 1;
                break;

            case ItemType.Leggings:
                var lifestealValues = new[] { 0, 3, 6 }; // Predefined possible values for Lifesteal
                Lifesteal = lifestealValues[_random.Next(lifestealValues.Length)] * multiplier;
                Armor = _random.Next(0, 3 + multiplier + multiplier - 2);
                Strength = _random.Next(0, 3 * multiplier);
                Regeneration = _random.Next(0, 3 * multiplier);
                Health = _random.Next(0, 10 * (multiplier + multiplier));
                StrengthRequirement = _random.Next(1, 6 * multiplier + multiplier - 1);
                LevelRequirement = (_random.Next(1, 5) * multiplier) + multiplier - 1;
                break;

            case ItemType.Helmet:
                Armor = _random.Next(0, 3 + multiplier - 1);
                Strength = _random.Next(0, 3 * multiplier);
                Regeneration = _random.Next(0, 3 * multiplier);
                CritDamage = _random.Next(0, 8 * multiplier);
                StrengthRequirement = _random.Next(1, 6 * multiplier);
                LevelRequirement = (_random.Next(1, 8) * multiplier) + multiplier + multiplier - 2;
                break;

            case ItemType.WeaponLeftHand:
                Damage = multiplier switch
                {
                    2 => 0,
                    3 => 1,
                    4 => 3,
                    5 => 5,
                    6 => 6,
                    _ => 0 // Default case, in case multiplier is out of expected range
                };
                Strength = _random.Next(0, 2 * multiplier);
                Regeneration = _random.Next(0, 3 * multiplier * multiplier);
                Lifesteal = _random.Next(0, 5 * multiplier);
                StrengthRequirement = _random.Next(1, 2 * multiplier);
                CritDamage = _random.Next(0, 10 * multiplier);
                LevelRequirement = _random.Next(4, 12) + multiplier + multiplier;
                break;

            case ItemType.Shoulders:
                Regeneration = _random.Next(0, 2 * multiplier * multiplier);
                Health = _random.Next(0, 14 * (multiplier + multiplier));
                Armor = _random.Next(1, 2 + multiplier - 1) + multiplier - 1;
                StrengthRequirement = _random.Next(3, 6 * multiplier);
                LevelRequirement = _random.Next(1, 8 * multiplier) + multiplier + multiplier - 2;
                break;

            default:
                break;
        }
    }

}