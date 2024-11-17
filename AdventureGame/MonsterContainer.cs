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
    public List<Monster> listOfMonstersAct1Quest1 { get; private set; }
    public List<Monster> listOfMonstersBossAct2 { get; private set; }
    public List<Monster> listOfMonstersAct3 { get; private set; }
    public List<Monster> listOfMonstersBossAct3 { get; private set; }

    public MonsterContainer()
    {
        listOfMonsters1 = new List<Monster>();
        listOfMonsters2 = new List<Monster>();
        listOfMonstersBossAct1 = new List<Monster>();
        listOfSnowMonsters1 = new List<Monster>();
        listOfMonstersSnowGoldGoblin = new List<Monster>();
        listOfMonstersBossAct2 = new List<Monster>();
        listOfMonstersAct3 = new List<Monster>();
        listOfMonstersBossAct3 = new List<Monster>();
        listOfMonstersAct1Quest1 = new List<Monster>();
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
        Image deadTrollImage = GetMonsterImage("deadtroll.png");
        Image act1BossImage = GetMonsterImage("bossact1.png");
        Image hungryBeastImage = GetMonsterImage("hungrybeast.png");

        Image snowDemonImage = GetMonsterImage("snowdemon.png");
        Image snowAntlerImage = GetMonsterImage("snowantler.png");
        Image snowCrazedImage = GetMonsterImage("snowcrazed.png");
        Image snowHorrorImage = GetMonsterImage("snowhorror.png");
        Image snowMooseImage = GetMonsterImage("snowmoose.png");
        Image snowGoblinImage = GetMonsterImage("goldgoblin.png");
        Image act2BossImage = GetMonsterImage("bossact2.png");

        Image seaHorrorImage = GetMonsterImage("seahorror.png");
        Image seaTerrorImage = GetMonsterImage("seaterror.png");
        Image seaGhostImage = GetMonsterImage("seaghost.png");
        Image seaMonsterImage = GetMonsterImage("seamonster.png");

        // List of normal monsters NORMAL - NOPREFIX - SNOW - NIGHTMARE - ELITE - HORROR - HELLISH - CORRUPTED
        Monster normalGoblin = new("Goblin", 10, 10, 0, 1, 1, 6, 1, normalGoblinImage);
        Monster normalOrc = new("Orc", 7, 7, 0, 1, 2, 9, 0, normalOrcImage);
        Monster normalSkeleton = new("Skeleton", 8, 8, 1, 0, 0, 7, 0, normalSkeletonImage);
        Monster normalGhast = new("Ghast", 7, 7, 0, 0, 4, 8, 1, normalGhastImage);
        Monster normalCorpse = new("Corpse", 8, 4, 0, 0, 1, 5, 0, normalCorpseImage);
        Monster normalDemon = new("Demon", 10, 10, 0, 0, 3, 10, 2, normalDemonImage);
        Monster normalGhost = new("Ghost", 8, 8, 0, 0, 3, 11, 0, normalGhostImage);

        // List of noprefix monsters
        Monster golem = new("Golem", 21, 21, 2, 0, 2, 15, 0, golemImage);
        Monster knight = new("Knight", 17, 17, 1, 0, 6, 17, 2, knightImage);
        Monster horror = new("Horror", 18, 18, 3, 0, 2, 13, 0, horrorImage);
        Monster starved = new("Starved", 15, 15, 1, 0, 6, 19, 0, starvedImage);
        Monster bat = new("Bat", 18, 18, 4, 0, 1, 12, 0, batImage);
        Monster woodHorror = new("Wood Horror", 15, 15, 0, 0, 8, 22, 3, woodHorrorImage);
        Monster deadTroll = new("Dead Troll", 14, 14, 3, 0, 2, 20, 2, deadTrollImage);

        // Special enemies
        Monster act1Boss = new("Aldrus Thornfell", 80, 80, 5, 0, 7, 40, 5, act1BossImage); // Act1 boss
        Monster hungryBeast = new("Hungry Beast", 35, 35, 3, 0, 7, 30, 0, hungryBeastImage);
        Monster snowGoldGoblin = new("Gold Goblin", 30, 30, 6, 0, 7, 0, 9, snowGoblinImage);
        Monster act2Boss = new("Wintermaw", 200, 200, 10, 0, 20, 50, 0, act2BossImage);
        Monster act3Boss = new("The Devouring Abyss", 400, 400, 19, 0, 30, 100, 30, null);

        // Act 2 Snow Monsters
        Monster snowDemon = new("Snow Demon", 29, 29, 9, 0, 3, 22, 0, snowDemonImage);
        Monster snowAntler = new("Snow Antler", 27, 27, 8, 0, 3, 18, 2, snowAntlerImage);
        Monster snowCrazed = new("Snow Crazed", 24, 24, 7, 0, 3, 15, 1, snowCrazedImage);
        Monster snowHorror = new("Snow Horror", 40, 40, 6, 0, 5, 25, 4, snowHorrorImage);
        Monster snowMoose = new("Snow Moose", 35, 35, 10, 0, 3, 20, 3, snowMooseImage);

        // Act 3 Sea Monsters
        Monster seaHorror = new("Sea Horror", 130, 130, 13, 0, 15, 40, 12, seaHorrorImage);
        Monster seaTerror = new("Sea Terror", 120, 120, 10, 0, 19, 50, 0, seaTerrorImage);
        Monster seaGhost = new("Ghost of the Sea", 100, 100, 0, 0, 25, 30, 17, seaGhostImage);
        Monster seaMonster = new("Monster of the Sea", 115, 115, 27, 0, 0, 38, 20, seaMonsterImage);

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
        listOfMonsters2.Add(deadTroll);

        // Special enemies
        listOfMonstersBossAct1.Add(act1Boss);
        listOfMonstersSnowGoldGoblin.Add(snowGoldGoblin);
        listOfMonstersBossAct2.Add(act2Boss);
        listOfMonstersBossAct3.Add(act3Boss);
        listOfMonstersAct1Quest1.Add(hungryBeast);


        // Act 2 list of snow monsters
        listOfSnowMonsters1.Add(snowDemon);
        listOfSnowMonsters1.Add(snowAntler);
        listOfSnowMonsters1.Add(snowCrazed);
        listOfSnowMonsters1.Add(snowMoose);
        listOfSnowMonsters1.Add(snowHorror);

        // Act 3 list of sea monsters
        listOfMonstersAct3.Add(seaHorror);
        listOfMonstersAct3.Add(seaGhost);
        listOfMonstersAct3.Add(seaTerror);
        listOfMonstersAct3.Add(seaMonster);

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
