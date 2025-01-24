using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;
public enum ImprovedItemQuality
{
    Damaged,
    Normal,
    Magic,
    Strong,
    Rare,
    Unique,
    Epic,
    Legendary,
    Godly
}

public class ImprovedRandomItem : Item
{
    private static Random _random = new Random();
    private static readonly List<string> SuffixesNormalItems = new() { "of Health", "of Stamina", "of Strength", "of Iron", "of Bronze", "of Leather", "of Defense", "of Protection", "of Stone", "of Power", "of Skill", "of Steel" };
    private static readonly List<string> SuffixesMagicStrong = new() { "of Magic", "of Mysticism", "of Arcana", "of Sorcery", "of Enchantment", "of Mana", "of Illusion", "of Mystic", "of Fury", "of Flames", "of Frost", "of Storms", "of Stars", "of Oracle", "of Hexes" };
    private static readonly List<string> SuffixesRareItems = new() { "of Champions", "of Valor", "of Fortitude", "of Precision", "of Berserk", "of Titans", "of Sentinel", "of Might" };
    private static readonly List<string> PrefixesEpicUniqueLegendary = new() { "Ancient", "Cursed", "Enchanted", "Fabled", "Mystic", "Worn", "Epic", "Golden", "Strong", "Mythical", "Knight's" };
    private static readonly List<string> SuffixesEpicUniqueLegendary = new() { "of Power", "of Glory", "of Shadows", "of Light", "of the Dragon", "of Doom", "of Angels", "of Gold", "of God", "of Chaos" };

    public ImprovedItemQuality Quality { get; set; }

    public ImprovedRandomItem(ItemType itemType) : base(itemType) // explicitly telling the compiler to call the Item(ItemType itemType) constructor from the base class
    {
        Quality = GenerateRandomQuality(); // Assign Quality first
        AssignStatsBasedOnTypeAndQuality(itemType, Quality); // Now use the initialized Quality
        Name = GenerateRandomName(itemType, Quality);
    }

    // This method determines the droprate % of the item quality
    private ImprovedItemQuality GenerateRandomQuality()
    {
        // Define probabilities explicitly for each quality
        var probabilities = new List<(ImprovedItemQuality Quality, double Chance)>
    {
        (ImprovedItemQuality.Damaged, 25),    // the number represents % chance droprate
        (ImprovedItemQuality.Normal, 50),
        (ImprovedItemQuality.Magic, 8),
        (ImprovedItemQuality.Strong, 6),
        (ImprovedItemQuality.Rare, 5),
        (ImprovedItemQuality.Unique, 4),
        (ImprovedItemQuality.Epic, 1.4),
        (ImprovedItemQuality.Legendary, 0.5),
        (ImprovedItemQuality.Godly, 0.1),
    };

        double roll = _random.NextDouble() * 100;

        // Loop through the probabilities to find the matching quality
        double cumulative = 0;
        foreach (var (quality, chance) in probabilities)
        {
            cumulative += chance;
            if (roll < cumulative)
                return quality;
        }
        return ImprovedItemQuality.Normal; // fallback in case something goes wrong
    }

    public string GenerateRandomName(ItemType itemType, ImprovedItemQuality quality)
    {
        // Normal items doesn't have prefixes
        string prefix = Quality switch
        {
            ImprovedItemQuality.Damaged => "Damaged",
            ImprovedItemQuality.Epic => PrefixesEpicUniqueLegendary[_random.Next(PrefixesEpicUniqueLegendary.Count)],
            ImprovedItemQuality.Unique => PrefixesEpicUniqueLegendary[_random.Next(PrefixesEpicUniqueLegendary.Count)],
            ImprovedItemQuality.Legendary => "Legendary",
            ImprovedItemQuality.Godly => "Hero's",
            _ => string.Empty
        };

        string baseName = itemType.ToString();
        if (baseName == "WeaponRightHand") { baseName = "Weapon"; }
        if (baseName == "WeaponLeftHand") { baseName = "Hook"; }

        string suffix = quality switch
        {
            ImprovedItemQuality.Damaged => string.Empty,
            ImprovedItemQuality.Normal => SuffixesNormalItems[_random.Next(SuffixesNormalItems.Count)],
            ImprovedItemQuality.Rare => SuffixesRareItems[_random.Next(SuffixesRareItems.Count)],
            ImprovedItemQuality.Magic or ImprovedItemQuality.Strong => SuffixesMagicStrong[_random.Next(SuffixesMagicStrong.Count)],
            ImprovedItemQuality.Epic or ImprovedItemQuality.Unique or ImprovedItemQuality.Legendary => SuffixesEpicUniqueLegendary[_random.Next(SuffixesEpicUniqueLegendary.Count)],
            ImprovedItemQuality.Godly => "of God",
        };

        return $"{prefix} {baseName} {suffix}".Trim();
    }

    private void AssignStatsBasedOnTypeAndQuality(ItemType itemType, ImprovedItemQuality quality)
    {
        double multiplier = quality switch
        {
            ImprovedItemQuality.Damaged => 0.5,
            ImprovedItemQuality.Normal => 1.0,
            ImprovedItemQuality.Magic => 1.8,
            ImprovedItemQuality.Strong => 2.0,
            ImprovedItemQuality.Rare => 2.6,
            ImprovedItemQuality.Unique => 3.0,
            ImprovedItemQuality.Epic => 4.5,
            ImprovedItemQuality.Legendary => 7,
            ImprovedItemQuality.Godly => 8,
            _ => 1.0
        };

        switch (itemType)
        {
            case ItemType.WeaponRightHand:
                Damage = (int)(_random.Next(1, 3) * multiplier);
                CritChance = (int)(_random.Next(0, 5) * multiplier);
                Strength = (int)(_random.Next(1, 3) * multiplier);
                StrengthRequirement = (int)((_random.Next(0, 6) * multiplier) + multiplier - 1);
                LevelRequirement = (int)(_random.Next(2, 9) + multiplier + multiplier - 1);
                break;

            case ItemType.Armor:
                Strength = (int)(_random.Next(0, 5) * multiplier);
                Health = (int)(_random.Next(2, 19) * (multiplier * multiplier));
                Armor = (int)(_random.Next(1, 2) * multiplier);
                StrengthRequirement = (int)((_random.Next(0, 6) * multiplier) + multiplier - 1);
                LevelRequirement = (int)(_random.Next(1, 3) + multiplier + multiplier + multiplier - 2);
                break;

            case ItemType.Gloves:
                Strength = (int)(_random.Next(0, 3) * multiplier);
                CritChance = (int)(_random.Next(1, 9) * multiplier);
                Armor = (int)(_random.Next(0, 3) * multiplier);
                StrengthRequirement = (int)((_random.Next(0, 6) * multiplier) + multiplier - 1);
                LevelRequirement = (int)(_random.Next(1, 4) + multiplier + multiplier - 1);
                break;

            case ItemType.Boots:
                DodgeChance = (int)(_random.Next(0, 9) + multiplier);
                Armor = (int)(_random.Next(0, 3) * multiplier + multiplier - 1);
                Health = (int)(_random.Next(1, 15) * (multiplier + multiplier) + multiplier);
                StrengthRequirement = (int)((_random.Next(0, 6) * multiplier) + multiplier - 1);
                LevelRequirement = (int)(_random.Next(1, 5) * multiplier + multiplier - 2);
                break;

            case ItemType.Belt:
                Strength = (int)(_random.Next(0, 2) * multiplier);
                Regeneration = (int)(_random.Next(1, 3) * multiplier);
                Lifesteal = (int)(_random.Next(0, 9) * multiplier);
                StrengthRequirement = (int)((_random.Next(0, 6) * multiplier) + multiplier - 1);
                LevelRequirement = (int)(_random.Next(1, 6) + multiplier + multiplier - 1);
                break;

            case ItemType.Leggings:
                Armor = (int)(_random.Next(0, 3) * multiplier);
                Strength = (int)(_random.Next(0, 3) * multiplier + multiplier - 1);
                Regeneration = (int)(_random.Next(0, 3) * multiplier + multiplier - 1);
                Health = (int)(_random.Next(0, 35) * (multiplier * multiplier + multiplier - 1));
                StrengthRequirement = (int)(_random.Next(1, 6) * multiplier);
                LevelRequirement = (int)(_random.Next(1, 5) + multiplier + multiplier);
                break;

            case ItemType.Helmet:
                Armor = (int)(_random.Next(0, 4) * multiplier);
                Strength = (int)(_random.Next(0, 3) * multiplier);
                Regeneration = (int)(_random.Next(0, 3) * multiplier);
                CritDamage = (int)(_random.Next(0, 1) + (multiplier - 1) * multiplier);
                StrengthRequirement = (int)(_random.Next(1, 6) * multiplier);
                LevelRequirement = (int)(_random.Next(1, 7) + multiplier + multiplier);
                break;

            case ItemType.WeaponLeftHand:
                Strength = (int)(_random.Next(0, 2) * multiplier);
                Regeneration = (int)(_random.Next(0, 4) * multiplier * multiplier);
                Lifesteal = (int)(_random.Next(0, 5) * multiplier);
                CritDamage = (int)(_random.Next(0, 1) + (multiplier - 1) * multiplier);
                StrengthRequirement = (int)(_random.Next(1, 2) * multiplier);
                LevelRequirement = (int)(_random.Next(4, 16) + multiplier + multiplier - 1);
                break;

            case ItemType.Shoulders:
                Regeneration = (int)(_random.Next(0, 2) * multiplier * multiplier);
                Health = (int)(_random.Next(0, 26) * (multiplier + multiplier));
                Armor = (int)(_random.Next(1, 3) * multiplier);
                LevelRequirement = (int)(_random.Next(2, 8) + multiplier + multiplier);
                break;

            case ItemType.Amulet:
                Regeneration = (int)(_random.Next(0, 6) * multiplier * multiplier);
                Health = (int)(_random.Next(0, 11) * (multiplier + multiplier));
                CritChance = (int)(_random.Next(1, 3) * multiplier);
                DodgeChance = (int)(_random.Next(1, 3) + multiplier);
                LevelRequirement = (int)(_random.Next(10, 16) + multiplier + multiplier + multiplier - 2);
                break;

            default:
                break;
        }
    }

}
