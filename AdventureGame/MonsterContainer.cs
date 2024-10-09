using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

internal class MonsterContainer
{

    public List<Monster> listOfMonsters1 { get; private set; }

    public MonsterContainer()
    {
        listOfMonsters1 = new List<Monster>();
        AddMonstersToList();
    }

    public void AddMonstersToList()
    {
    // C:\Users\jakob\source\repos\C#AdventureGame\AdventureGame\bin\Debug\net8.0-windows\Images
    // Denne mappe skal til sidst flyttes ud i:
    //C: \Users\jakob\source\repos\C#AdventureGame\AdventureGame\bin\release
        Image normalGoblinImage = GetMonsterImage("goblin.png");
        Image normalOrcImage = GetMonsterImage("orc.png");
        Image normalSkeletonImage = GetMonsterImage("skeleton.png");
        Image normalGhastImage = GetMonsterImage("ghast.png");
        Image normalCorpseImage = GetMonsterImage("corpse.png");
        Image normalDemonImage = GetMonsterImage("demon.png");


        Monster normalGoblin = new("Goblin", 10, 10, 0, 1, 1, 6, 1, normalGoblinImage);
        Monster normalOrc = new("Orc", 7, 7, 0, 1, 2, 9, 0, normalOrcImage);
        Monster normalSkeleton = new("Skeleton", 8, 8, 0, 0, 3, 7, 0, normalSkeletonImage);
        Monster normalGhast = new("Ghast", 7, 7, 0, 0, 4, 8, 1, normalGhastImage);
        Monster normalCorpse = new("Corpse", 8, 4, 0, 0, 1, 5, 0, normalCorpseImage);
        Monster normalDemon = new("Demon", 10, 10, 0, 0, 3, 10, 2, normalDemonImage);

        listOfMonsters1.Add(normalGoblin);
        listOfMonsters1.Add(normalOrc);
        listOfMonsters1.Add(normalSkeleton);
        listOfMonsters1.Add(normalGhast);
        listOfMonsters1.Add(normalCorpse);
        listOfMonsters1.Add(normalDemon);
    }

    private Image GetMonsterImage(string resourceName)
    {
        try
        {
            var assembly = AppDomain.CurrentDomain.BaseDirectory;
            var resourcePath = Path.Combine(assembly, "Images", resourceName);// $"AdventureGame.Images.{resourceName}";

            return Image.FromFile(resourcePath);
        }
        catch (FileNotFoundException ex)
        {
            MessageBox.Show("Image file not found.");
            return null;
        }
    }
    
}
