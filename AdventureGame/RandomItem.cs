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
    Legendary
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
            ItemQuality.Legendary => 5,
            _ => 1 // Normal quality has a multiplier of 1
        };

        switch (itemType)
        {
            case ItemType.Armor:
                Strength = _random.Next(0, 2 * multiplier);
                Health = _random.Next(0, 14 * multiplier);
                Armor = _random.Next(1, 2 * multiplier);
                LevelRequirement = _random.Next(1, 3 * multiplier);
                break;

            case ItemType.Gloves:
                Strength = _random.Next(0, 3 * multiplier);
                CritChance = _random.Next(1, 9 * multiplier);
                Armor = _random.Next(0, 3 * multiplier);
                LevelRequirement = _random.Next(1, 4 * multiplier);
                break;

            case ItemType.Boots:
                DodgeChance = _random.Next(0, 9 * multiplier);
                Armor = _random.Next(1, 3 * multiplier);
                LevelRequirement = _random.Next(1, 5 * multiplier);
                break;

            case ItemType.Belt:
                Strength = _random.Next(0, 2 * multiplier);
                Regeneration = _random.Next(1, 3 * multiplier);
                Lifesteal = _random.Next(0, 9 * multiplier);
                StrengthRequirement = _random.Next(1, 6 * multiplier);
                LevelRequirement = _random.Next(1, 6 * multiplier);
                break;

            case ItemType.WeaponRightHand:
                Damage = _random.Next(0, 3 * multiplier);
                CritChance = _random.Next(0, 7 * multiplier);
                Strength = _random.Next(1, 3 * multiplier);
                LevelRequirement = _random.Next(1, 5 * multiplier);
                break;

            case ItemType.Leggings:
                Armor = _random.Next(0, 3 * multiplier);
                Strength = _random.Next(0, 3 * multiplier);
                Regeneration = _random.Next(0, 3 * multiplier);
                Health = _random.Next(0, 10 * multiplier);
                StrengthRequirement = _random.Next(1, 6 * multiplier);
                LevelRequirement = _random.Next(1, 5 * multiplier);
                break;
            case ItemType.Helmet:
                Armor = _random.Next(0, 3 * multiplier);
                Strength = _random.Next(0, 3 * multiplier);
                Regeneration = _random.Next(0, 3 * multiplier);
                StrengthRequirement = _random.Next(1, 6 * multiplier);
                LevelRequirement = _random.Next(1, 7 * multiplier);
                break;

            case ItemType.WeaponLeftHand:
                Strength = _random.Next(0, 2 * multiplier);
                Regeneration = _random.Next(0, 3 * multiplier * multiplier);
                Lifesteal = _random.Next(0, 5 * multiplier);
                StrengthRequirement = _random.Next(1, 2 * multiplier);
                LevelRequirement = _random.Next(1, 8 * multiplier);
                break;

            case ItemType.Shoulders:
                Regeneration = _random.Next(0, 2 * multiplier * multiplier);
                Health = _random.Next(0, 12 * multiplier);
                Armor = _random.Next(1, 3 * multiplier);
                break;

            default:
                break;
        }
    }

}
