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
    public List<Monster> listOfMonsters2 { get; private set; }
    public List<Monster> listOfMonstersBossAct1 { get; private set; }
    public List<Monster> listOfSnowMonsters1 { get; private set; }
    public List<Monster> listOfMonstersSnowGoldGoblin { get; private set; }

    public MonsterContainer()
    {
        listOfMonsters1 = new List<Monster>();
        listOfMonsters2 = new List<Monster>();
        listOfMonstersBossAct1 = new List<Monster>();
        listOfSnowMonsters1 = new List<Monster>();
        listOfMonstersSnowGoldGoblin = new List<Monster>();
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
        Image normalGhostImage = GetMonsterImage("ghost.png");

        Image golemImage = GetMonsterImage("golem.png");
        Image knightImage = GetMonsterImage("knight.png");
        Image horrorImage = GetMonsterImage("horror.png");
        Image starvedImage = GetMonsterImage("starved.png");
        Image batImage = GetMonsterImage("bat.png");
        Image woodHorrorImage = GetMonsterImage("woodhorror.png");
        Image act1BossImage = GetMonsterImage("bossact1.png");

        Image snowDemonImage = GetMonsterImage("snowdemon.png");
        Image snowAntlerImage = GetMonsterImage("snowantler.png");
        Image snowCrazedImage = GetMonsterImage("snowcrazed.png");
        Image snowHorrorImage = GetMonsterImage("snowhorror.png");
        Image snowMooseImage = GetMonsterImage("snowmoose.png");
        Image snowGoblinImage = GetMonsterImage("goldgoblin.png");

        // List of normal monsters NORMAL - NOPREFIX - SNOW - NIGHTMARE - ELITE - HORROR - HELLISH - CORRUPTED
        Monster normalGoblin = new("Goblin", 10, 10, 0, 1, 1, 6, 1, normalGoblinImage);
        Monster normalOrc = new("Orc", 7, 7, 0, 1, 2, 9, 0, normalOrcImage);
        Monster normalSkeleton = new("Skeleton", 8, 8, 1, 0, 0, 7, 0, normalSkeletonImage);
        Monster normalGhast = new("Ghast", 7, 7, 0, 0, 4, 8, 1, normalGhastImage);
        Monster normalCorpse = new("Corpse", 8, 4, 0, 0, 1, 5, 0, normalCorpseImage);
        Monster normalDemon = new("Demon", 10, 10, 0, 0, 3, 10, 2, normalDemonImage);
        Monster normalGhost = new("Ghost", 8, 8, 0, 0, 3, 11, 0, normalGhostImage);

        // List of noprefix monsters
        Monster golem = new("Golem", 16, 16, 2, 0, 1, 15, 0, golemImage);
        Monster knight = new("Knight", 15, 15, 1, 0, 6, 17, 2, knightImage);
        Monster horror = new("Horror", 19, 19, 3, 0, 1, 13, 0, horrorImage);
        Monster starved = new("Starved", 13, 13, 1, 0, 6, 19, 0, starvedImage);
        Monster bat = new("Bat", 16, 16, 4, 0, 0, 12, 0, batImage);
        Monster woodHorror = new("Wood Horror", 15, 15, 0, 0, 8, 22, 3, woodHorrorImage);

        // Special enemies
        Monster act1boss = new("Aldrus Thornfell", 80, 80, 5, 0, 5, 40, 5, act1BossImage); // Act1 boss
        Monster snowGoldGoblin = new("Gold Goblin", 30, 30, 5, 0, 4, 0, 9, snowGoblinImage);


        // Act 2 Snow Monsters
        Monster snowDemon = new("Snow Demon", 29, 29, 8, 0, 0, 22, 0, snowDemonImage);
        Monster snowAntler = new("Snow Antler", 25, 24, 7, 0, 0, 18, 2, snowAntlerImage);
        Monster snowCrazed = new("Snow Crazed", 22, 22, 6, 0, 0, 15, 1, snowCrazedImage);
        Monster snowHorror = new("Snow Horror", 30, 30, 9, 0, 0, 25, 4, snowHorrorImage);
        Monster snowMoose = new("Snow Moose", 35, 20, 10, 0, 0, 20, 3, snowMooseImage);

        // List of Monsters 1
        listOfMonsters1.Add(normalGoblin);
        listOfMonsters1.Add(normalOrc);
        listOfMonsters1.Add(normalSkeleton);
        listOfMonsters1.Add(normalGhast);
        listOfMonsters1.Add(normalCorpse);
        listOfMonsters1.Add(normalDemon);
        listOfMonsters1.Add(normalGhost);

        // List of Monsters 2
        listOfMonsters2.Add(normalGhost);
        listOfMonsters2.Add(normalGhast);
        listOfMonsters2.Add(golem);
        listOfMonsters2.Add(knight);
        listOfMonsters2.Add(horror);
        listOfMonsters2.Add(starved);
        listOfMonsters2.Add(bat);
        listOfMonsters2.Add(woodHorror);

        // Special enemies
        listOfMonstersBossAct1.Add(act1boss);
        listOfMonstersSnowGoldGoblin.Add(snowGoldGoblin);

        // Act 2 list of snow monsters
        listOfSnowMonsters1.Add(snowDemon);

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
