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
    public List<Monster> listOfMonstersAct4West { get; private set; }
    public List<Monster> ListOfDragonsAct4East { get; private set; }
    public List<Monster> ListOfDragonEggAct4North { get; private set; }

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
        listOfMonstersAct4West = new List<Monster>();
        ListOfDragonsAct4East = new List<Monster>();
        ListOfDragonEggAct4North = new List<Monster>();
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
        Image lostImage = GetMonsterImage("lost.png");
        Image lizardImage = GetMonsterImage("lizard.png");

        Image snowDemonImage = GetMonsterImage("snowdemon.png");
        Image snowAntlerImage = GetMonsterImage("snowantler.png");
        Image snowCrazedImage = GetMonsterImage("snowcrazed.png");
        Image snowHorrorImage = GetMonsterImage("snowhorror.png");
        Image snowMooseImage = GetMonsterImage("snowmoose.png");
        Image snowAngelImage = GetMonsterImage("snowangel.png");
        Image snowGoblinImage = GetMonsterImage("goldgoblin.png");
        Image act2BossImage = GetMonsterImage("bossact2.png");

        Image seaHorrorImage = GetMonsterImage("seahorror.png");
        Image seaTerrorImage = GetMonsterImage("seaterror.png");
        Image seaGhostImage = GetMonsterImage("seaghost.png");
        Image seaMonsterImage = GetMonsterImage("seamonster.png");
        Image octopusImage = GetMonsterImage("octopus.png");

        Image burningSkeletonImage = GetMonsterImage("burningskeleton.png");
        Image fireKnightImage = GetMonsterImage("fireknight.png");
        Image magmaHorrorImage = GetMonsterImage("magmahorror.png");
        Image magmaFrogImage = GetMonsterImage("magmafrog.png");
        Image forgottenPrinceImage = GetMonsterImage("forgottenprince.png");
        Image burningLizardImage = GetMonsterImage("burninglizard.png");
        Image dragonKingImage = GetMonsterImage("dragonking.png");
        Image casterDragonImage = GetMonsterImage("casterdragon.png");
        Image silverDragonImage = GetMonsterImage("silverdragon.png");
        Image dragonHydraImage = GetMonsterImage("dragonhydra.png");
        Image dragonNestWatcherImage = GetMonsterImage("dragonnestwatcher.png");
        Image dragonEggWatcherImage = GetMonsterImage("dragoneggwatcher.png");

        // List of normal monsters NORMAL - NOPREFIX - SNOW - NIGHTMARE - ELITE - HORROR - HELLISH - CORRUPTED
        Monster normalGoblin = new("Goblin", 10, 10, 0, 1, 3, 7, 2, normalGoblinImage);
        Monster normalOrc = new("Orc", 7, 7, 0, 0, 3, 9, 0, normalOrcImage);
        Monster normalSkeleton = new("Skeleton", 8, 8, 1, 0, 1, 8, 0, normalSkeletonImage);
        Monster normalGhast = new("Ghast", 7, 7, 1, 0, 4, 8, 1, normalGhastImage);
        Monster normalCorpse = new("Corpse", 8, 4, 1, 0, 2, 5, 0, normalCorpseImage);
        Monster normalDemon = new("Demon", 10, 10, 1, 0, 2, 10, 2, normalDemonImage);
        Monster normalGhost = new("Ghost", 8, 8, 0, 0, 3, 10, 1, normalGhostImage);

        // List of noprefix monsters
        Monster golem = new("Golem", 23, 23, 2, 0, 4, 15, 0, golemImage);
        Monster knight = new("Knight", 19, 19, 1, 0, 7, 17, 2, knightImage);
        Monster horror = new("Horror", 20, 20, 3, 0, 4, 13, 0, horrorImage);
        Monster starved = new("Starved", 17, 17, 1, 0, 7, 19, 0, starvedImage);
        Monster bat = new("Bat", 20, 20, 4, 0, 2, 12, 0, batImage);
        Monster woodHorror = new("Wood Horror", 16, 16, 0, 0, 8, 22, 3, woodHorrorImage);
        Monster deadTroll = new("Dead Troll", 16, 16, 3, 0, 5, 20, 2, deadTrollImage);
        Monster lost = new("Lost", 21, 21, 4, 0, 0, 2, 4, lostImage);
        Monster lizard = new("Lizard", 30, 30, 1, 0, 6, 30, 0, lizardImage);

        // Special enemies
        Monster act1Boss = new("Aldrus Thornfell", 90, 90, 5, 0, 7, 40, 5, act1BossImage); // Act1 boss
        Monster hungryBeast = new("Hungry Beast", 40, 40, 3, 0, 10, 30, 0, hungryBeastImage);
        Monster act2Boss = new("Wintermaw", 270, 270, 8, 0, 21, 50, 0, act2BossImage);
        Monster act3Boss = new("The Devouring Abyss", 400, 400, 15, 0, 30, 100, 30, null);

        // Act 2 Snow Monsters
        Monster snowGoldGoblin = new("Gold Goblin", 30, 30, 6, 0, 10, 0, 9, snowGoblinImage);
        Monster snowDemon = new("Snow Demon", 29, 29, 9, 0, 5, 22, 0, snowDemonImage);
        Monster snowAntler = new("Snow Antler", 27, 27, 8, 0, 5, 18, 2, snowAntlerImage);
        Monster snowCrazed = new("Snow Crazed", 24, 24, 7, 0, 5, 15, 1, snowCrazedImage);
        Monster snowHorror = new("Snow Horror", 40, 40, 6, 0, 6, 25, 4, snowHorrorImage);
        Monster snowMoose = new("Snow Moose", 35, 35, 10, 0, 3, 20, 3, snowMooseImage);
        Monster snowAngel = new("Snow Angel", 41, 41, 5, 0, 9, 21, 0, snowAngelImage);

        // Act 3 Sea Monsters
        Monster seaHorror = new("Sea Horror", 140, 140, 13, 0, 15, 40, 12, seaHorrorImage);
        Monster seaTerror = new("Sea Terror", 150, 150, 10, 0, 20, 50, 0, seaTerrorImage);
        Monster seaGhost = new("Ghost of the Sea", 160, 160, 3, 0, 31, 30, 17, seaGhostImage);
        Monster seaMonster = new("Monster of the Sea", 115, 115, 24, 0, 3, 38, 20, seaMonsterImage);
        Monster octopus = new("Octopus", 120, 120, 25, 0, 0, 50, 0, octopusImage);

        // Act 4 Monsters west
        Monster burningSkeleton = new("Burning Skeleton", 210, 200, 33, 0, 0, 70, 30, burningSkeletonImage);
        Monster burningLizard = new("Burning Lizard", 220, 200, 20, 0, 0, 70, 30, burningLizardImage);
        Monster magmaFrog = new("Magma Frog", 190, 190, 10, 0, 0, 88, 30, magmaFrogImage);
        Monster magmaHorror = new("Magma Horror", 180, 180, 57, 0, 0, 20, 30, magmaHorrorImage);
        Monster forgottenPrince = new("Forgotten Prince", 195, 195, 22, 0, 0, 77, 30, forgottenPrinceImage);
        Monster fireKnight = new("Fire Knight", 180, 180, 33, 0, 0, 66, 30, fireKnightImage);

        // Act 4 Dragons east
        Monster casterDragon = new("Dragon Mage", 230, 230, 33, 0, 0, 90, 44, casterDragonImage);
        Monster dragonKing = new("Dragon King", 300, 300, 21, 0, 10, 100, 30, dragonKingImage);
        Monster dragonHydra = new("Dragon Hydra", 266, 266, 28, 0, 4, 79, 0, dragonHydraImage);
        Monster silverDragon = new("Silver Dragon", 250, 250, 40, 0, 0, 20, 60, silverDragonImage);

        // Act 4 Dragon Nest Egg North
        Monster dragonNestWatcher = new("Nest-Watcher Dragon", 310, 310, 15, 0, 50, 60, 0, dragonNestWatcherImage);
        Monster dragonEggWatcher = new("Egg-Watcher Dragon", 310, 310, 15, 0, 50, 60, 0, dragonEggWatcherImage);

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
        listOfMonsters2.Add(lost);
        listOfMonsters2.Add(lizard);

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
        listOfSnowMonsters1.Add(snowAngel);

        // Act 3 list of sea monsters
        listOfMonstersAct3.Add(seaHorror);
        listOfMonstersAct3.Add(seaGhost);
        listOfMonstersAct3.Add(seaTerror);
        listOfMonstersAct3.Add(seaMonster);
        listOfMonstersAct3.Add(octopus);

        // Act 4 list west
        listOfMonstersAct4West.Add(burningSkeleton);
        listOfMonstersAct4West.Add(burningLizard);
        listOfMonstersAct4West.Add(magmaFrog);
        listOfMonstersAct4West.Add(magmaHorror);
        listOfMonstersAct4West.Add(forgottenPrince);
        listOfMonstersAct4West.Add(fireKnight);

        // Act 4 list east Dragons
        ListOfDragonsAct4East.Add(casterDragon);
        ListOfDragonsAct4East.Add(dragonKing);
        ListOfDragonsAct4East.Add(silverDragon);
        ListOfDragonsAct4East.Add(dragonHydra);

        // Act 4 Dragon Eggs North
        ListOfDragonEggAct4North.Add(dragonNestWatcher);
        ListOfDragonEggAct4North.Add(dragonNestWatcher);
        ListOfDragonEggAct4North.Add(dragonNestWatcher);
        ListOfDragonEggAct4North.Add(dragonEggWatcher); 
       

    }

    private Image GetMonsterImage(string resourceName)
    {
        try
        {
            var assembly = AppDomain.CurrentDomain.BaseDirectory;
            var resourcePath = Path.Combine(assembly, "Images", resourceName); // $"AdventureGame.Images.{resourceName}";

            return Image.FromFile(resourcePath);
        }
        catch (FileNotFoundException ex)
        {
            MessageBox.Show("Image file not found.");
            return null;
        }
    }

}
