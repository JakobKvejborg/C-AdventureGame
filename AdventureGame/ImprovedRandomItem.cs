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
   
    // Prefixes for very good items
    private static readonly List<string> PrefixesUniqueItems = new() { "Fabled", "Mythic", "Elder", "Heroic", "Grand", "Warlord's", "Knight's", "Unique", "Cunning" };
    private static readonly List<string> PrefixesEpicItems = new() { "Ancient", "Cursed", "Enchanted", "Epic", "Golden", "Silver", "Hero's" };
    private static readonly List<string> PrefixesLegendaryItems = new() { "Legendary", "Immortal", "Timeless" };
    // Suffixes for all items
    private static readonly List<string> SuffixesNormalItems = new() { "of Health", "of Stamina", "of Iron", "of Bronze", "of Leather", "of Defense", "of Protection", "of Stone", "of Steel" };
    private static readonly List<string> SuffixesMagic = new() { "of Magic", "of Mysticism", "of Arcana", "of Sorcery", "of Enchantment", "of Mana", "of Illusion", "of Mystic", "of Hexes", "of Confusion" };
    private static readonly List<string> SuffixesStrong = new() { "of Fury", "of Skill", "of Flames", "of Frost", "of Storms", "of the Stars", "of Oracle", "of Strength" };
    private static readonly List<string> SuffixesRareItems = new() { "of Champions", "of Valor", "of Fortitude", "of Precision", "of Berserk", "of Titans", "of Might", "of Blood" };
    private static readonly List<string> SuffixesUnique = new() { "of Gold", "of Power", "of Glory", "of Wisdom" };
    private static readonly List<string> SuffixesEpicItems = new() { "of Shadows", "of Light", "of the Void", "of Eternity", "of Oblivion" };
    private static readonly List<string> SuffixesLegendary = new() { "of Dragons", "of Angels", "of Chaos", "of Demons", "of Doom" };
    private static readonly List<string> SuffixesGodly = new() { "of God" };

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
        (ImprovedItemQuality.Damaged, 24),    // the number represents % chance droprate
        (ImprovedItemQuality.Normal, 51),
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
        // Normal items doesn't have prefixes(names)
        string prefix = Quality switch
        {
            ImprovedItemQuality.Damaged => "Damaged",
            ImprovedItemQuality.Unique => PrefixesUniqueItems[_random.Next(PrefixesUniqueItems.Count)],
            ImprovedItemQuality.Epic => PrefixesEpicItems[_random.Next(PrefixesEpicItems.Count)],
            ImprovedItemQuality.Legendary => PrefixesLegendaryItems[_random.Next(PrefixesLegendaryItems.Count)],
            _ => string.Empty
        };

        string baseName = itemType.ToString();
        if (baseName == "WeaponRightHand") { baseName = "Weapon"; }
        if (baseName == "WeaponLeftHand") { baseName = "Hook"; }

        string suffix = quality switch
        {
            ImprovedItemQuality.Damaged => string.Empty,
            ImprovedItemQuality.Normal => SuffixesNormalItems[_random.Next(SuffixesNormalItems.Count)],
            ImprovedItemQuality.Magic => SuffixesMagic[_random.Next(SuffixesMagic.Count)],
            ImprovedItemQuality.Strong => SuffixesStrong[_random.Next(SuffixesStrong.Count)],
            ImprovedItemQuality.Rare => SuffixesRareItems[_random.Next(SuffixesRareItems.Count)],
            ImprovedItemQuality.Unique => SuffixesUnique[_random.Next(SuffixesUnique.Count)],
            ImprovedItemQuality.Epic => SuffixesEpicItems[_random.Next(SuffixesEpicItems.Count)],
            ImprovedItemQuality.Legendary => SuffixesLegendary[_random.Next(SuffixesLegendary.Count)],
           ImprovedItemQuality.Godly => SuffixesGodly[_random.Next(SuffixesGodly.Count)],
        };

        return $"{prefix} {baseName} {suffix}".Replace("  ", " ").Trim();
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
            ImprovedItemQuality.Legendary => 5,
            ImprovedItemQuality.Godly => 6,
            _ => 1.0 // fallback on 1, in case something goes wrong and the item doesn't have a quality assigned to it
        };

        switch (itemType)
        {
            case ItemType.WeaponRightHand:
                int min = (int)((multiplier + 0.25) * 2.5); 
                int max = (int)((multiplier + 0.25) * 4);
                Damage = _random.Next(min, max);
                CritChance = (int)(_random.Next(0, 5) * multiplier);
                Strength = (int)(_random.Next(1, 3) * multiplier);
                StrengthRequirement = (int)((_random.Next(1, 6) * multiplier) + multiplier + multiplier - 2);
                LevelRequirement = (int)(_random.Next(3, 9) + multiplier + multiplier + multiplier + multiplier - 3);
                break;

            case ItemType.Armor:
                Strength = (int)(_random.Next(0, 3) + multiplier - 1);
                Health = (int)((_random.Next(2, 32) + multiplier) * (multiplier + multiplier) + multiplier);
                Armor = (int)(_random.Next(1, 2) * multiplier);
                StrengthRequirement = (int)((_random.Next(0, 6) * multiplier) + multiplier - 1);
                LevelRequirement = (int)(_random.Next(1, 4) + multiplier + multiplier + multiplier + multiplier + multiplier - 3);
                break;

            case ItemType.Gloves:
                var critDamageValues = new[] { 0, 3, 8 }; // Predefined possible values for CritDamage
                CritDamage = (int)Math.Round(critDamageValues[_random.Next(critDamageValues.Length)] * multiplier);
                Strength = (int)(_random.Next(0, 3) + multiplier);
                CritChance = (int)(_random.Next(1, 9) + multiplier);
                Armor = (int)((_random.Next(0, 4) + multiplier - 1) + multiplier - 1);
                StrengthRequirement = (int)((_random.Next(0, 6) * multiplier) + multiplier + multiplier - 1);
                LevelRequirement = (int)((_random.Next(1, 5) * multiplier) + multiplier + multiplier + multiplier - 3);
                break;

            case ItemType.Boots:
                DodgeChance = (int)(_random.Next(0, 7) + multiplier);
                Armor = (int)(_random.Next(0, 3) + multiplier + multiplier - 2);
                Health = (int)(_random.Next(1, 21) * (multiplier) + multiplier);
                StrengthRequirement = (int)((_random.Next(1, 6) * multiplier) + multiplier + multiplier + multiplier - 2);
                LevelRequirement = (int)((_random.Next(1, 5) * multiplier + multiplier - 2) + multiplier + multiplier + multiplier - 1);
                break;

            case ItemType.Belt:
                Armor = (int)_random.Next(0, 3);
                Strength = (int)(_random.Next(0, 2) * multiplier);
                Regeneration = (int)(_random.Next(1, 4) * multiplier);
                Lifesteal = (int)(_random.Next(0, 9) * multiplier);
                StrengthRequirement = (int)((_random.Next(0, 6) * multiplier) + multiplier + multiplier - 1);
                LevelRequirement = (int)(_random.Next(1, 6) + multiplier + multiplier - 1);
                break;

            case ItemType.Leggings:
                Armor = (int)(_random.Next(0, 3) + multiplier + multiplier - 2 + (multiplier / 3));
                Strength = (int)(_random.Next(0, 3) * multiplier + multiplier - 1);
                Regeneration = (int)(_random.Next(0, 3) * multiplier + multiplier - 1);
                Health = (int)((_random.Next(0, 49) * multiplier) + multiplier - 1);
                StrengthRequirement = (int)(_random.Next(1, 6) * multiplier);
                LevelRequirement = (int)(_random.Next(1, 6) + multiplier + multiplier);
                break;

            case ItemType.Helmet:
                var healthValues = new[] { 0, 0, 20, 70 }; // Predefined possible values for Health
                Health = healthValues[_random.Next(healthValues.Length)];
                Armor = (int)(_random.Next(0, 4) + multiplier - 1);
                Strength = (int)(_random.Next(0, 3) + multiplier);
                Regeneration = (int)(_random.Next(0, 4) * multiplier);
                CritDamage = (int)(_random.Next(0, 10) + (multiplier - 1) * multiplier);
                StrengthRequirement = (int)(_random.Next(1, 6) * multiplier);
                LevelRequirement = (int)(_random.Next(3, 10) + multiplier + multiplier - 2);
                break;

            case ItemType.WeaponLeftHand:
                Damage = (int)(_random.Next(0, 5));
                Strength = (int)(_random.Next(0, 2) * multiplier);
                Regeneration = (int)(_random.Next(0, 4) * multiplier * multiplier);
                Lifesteal = (int)(_random.Next(0, 5) * multiplier);
                CritDamage = (int)(_random.Next(0, 9) + (multiplier - 1) * multiplier - 1);
                StrengthRequirement = (int)(_random.Next(1, 4) * multiplier);
                LevelRequirement = (int)(_random.Next(4, 16) + multiplier + multiplier - 1);
                break;

            case ItemType.Shoulders:
                Regeneration = (int)(_random.Next(0, 2) * multiplier * multiplier + (multiplier / 3));
                Health = (int)(_random.Next(0, 46) * multiplier);
                Armor = (int)(_random.Next(0, 3) + multiplier - 1);
                StrengthRequirement = (int)(_random.Next(0, 4) + multiplier + multiplier + multiplier -1);
                LevelRequirement = (int)(_random.Next(2, 8) + multiplier + multiplier + multiplier - 1);
                break;

            case ItemType.Amulet:
                Regeneration = (int)(_random.Next(0, 6) * multiplier * multiplier);
                Health = (int)(_random.Next(0, 16) * (multiplier + multiplier));
                CritChance = (int)(_random.Next(0, 3) * multiplier);
                DodgeChance = (int)(_random.Next(1, 6) + multiplier - 1);
                LevelRequirement = (int)(_random.Next(10, 16) + multiplier + multiplier + multiplier - 2);
                break;

            default:
                break;
        }
    }

}
