using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AdventureGame.Tests;

[TestFixture] // This attribute indicates that this class contains NUnit tests
public class ImprovedRandomItemTest
{
    private ImprovedRandomItem _randomItem;

    [SetUp]
    public void SetUp()
    {
        // Initialize the test object before each test method.
        _randomItem = new ImprovedRandomItem(ItemType.WeaponRightHand);
    }

    [TestCase(ItemType.WeaponRightHand, ImprovedItemQuality.Godly, "Godly Weapon")]
    [TestCase(ItemType.WeaponRightHand, ImprovedItemQuality.Damaged, "Damaged Weapon")]
    [TestCase(ItemType.WeaponRightHand, ImprovedItemQuality.Epic, "Epic Weapon of Power")]  // Example of Epic with suffix (adjust as needed)
    [TestCase(ItemType.WeaponLeftHand, ImprovedItemQuality.Unique, "Unique Hook of Power")]  // Adjust with correct suffix
    [TestCase(ItemType.Armor, ImprovedItemQuality.Normal, "Armor of Health")]  // Example of normal Armor with suffix (adjust as needed)
    public void TestGenerateRandomName(ItemType itemType, ImprovedItemQuality quality, string expectedName)
    {
        // Act: Generate the random name
        var randomName = _randomItem.GenerateRandomName(itemType, quality);

        // Assert: Check if the generated name matches the expected name structure
        // This is just a basic test to check if it follows a pattern, for more sophisticated validation you can adjust as needed.
        Assert.That(randomName, Does.StartWith(quality.ToString())); // Ensure it starts with the quality e.g., "Damaged"
        Assert.That(randomName, Does.Contain(itemType.ToString())); // Ensure it contains the item type e.g., "Weapon"
    }



[Test]
    public void TestItemQualityDistribution()
    {
        Console.WriteLine("Running Quality Distribution Test...");

        // Simulate generating a large number of items and track the quality distribution
        Dictionary<ImprovedItemQuality, int> qualityCounts = new();
        foreach (ImprovedItemQuality quality in Enum.GetValues(typeof(ImprovedItemQuality)))
        {
            qualityCounts[quality] = 0;
        }

        const int simulationCount = 100000;
        for (int i = 0; i < simulationCount; i++)
        {
            var item = new ImprovedRandomItem(ItemType.WeaponRightHand);
            qualityCounts[item.Quality]++; // Track the quality frequency
        }

        Console.WriteLine("Quality Distribution Results:");
        foreach (var (quality, count) in qualityCounts)
        {
            Console.WriteLine($"{quality}: {(count / (double)simulationCount) * 100:F2}%");
        }
    }

    [Test]
    public void TestItemNameGeneration()
    {
        Console.WriteLine("\nRunning Item Name Generation Test...");

        foreach (ImprovedItemQuality quality in Enum.GetValues(typeof(ImprovedItemQuality)))
        {
            var item = new ImprovedRandomItem(ItemType.WeaponRightHand)
            {
                Quality = quality
            };
            string name = item.Name;
            Console.WriteLine($"Generated Name for Quality '{quality}': {name}");
        }
    }

    [Test]
    public void TestStatAssignment()
    {
        Console.WriteLine("\nRunning Stat Assignment Test...");

        var testItemTypes = new List<ItemType>
        {
            ItemType.WeaponRightHand,
            ItemType.WeaponLeftHand,
            ItemType.Armor,
            ItemType.Boots,
            ItemType.Gloves,
            ItemType.Helmet,
            ItemType.Leggings,
            ItemType.Belt,
            ItemType.Shoulders,
            ItemType.Amulet
        };

        foreach (var itemType in testItemTypes)
        {
            Console.WriteLine($"\nTesting Item Type: {itemType}");
            foreach (ImprovedItemQuality quality in Enum.GetValues(typeof(ImprovedItemQuality)))
            {
                var item = new ImprovedRandomItem(itemType)
                {
                    Quality = quality
                };

                Console.WriteLine($"Quality: {quality}, Name: {item.Name}");
                Console.WriteLine($"Stats -> Damage: {item.Damage}, CritChance: {item.CritChance}, Strength: {item.Strength}, " +
                                  $"Health: {item.Health}, Armor: {item.Armor}, LevelRequirement: {item.LevelRequirement}");
            }
        }
    }

}
