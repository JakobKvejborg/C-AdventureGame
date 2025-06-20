namespace AdventureGame;

internal class MonsterContainer
{

    public List<Monster> ListOfMonsters1 { get; private set; }
    public List<Monster> ListOfMonsters2 { get; private set; }
    public List<Monster> ListOfMonstersBossAct1 { get; private set; }
    public List<Monster> ListOfSnowMonsters1 { get; private set; }
    public List<Monster> ListOfMonstersSnowGoldGoblin { get; private set; }
    public List<Monster> ListOfMonstersAct1Quest1 { get; private set; }
    public List<Monster> ListOfMonstersBossAct2 { get; private set; }
    public List<Monster> ListOfMonstersAct3 { get; private set; }
    public List<Monster> ListOfMonstersBossAct3 { get; private set; }
    public List<Monster> ListOfMonstersAct4West { get; private set; }
    public List<Monster> ListOfDragonsAct4East { get; private set; }
    public List<Monster> ListOfDragonEggAct4North { get; private set; }
    public List<Monster> ListOfAct5Monsters { get; private set; }
    public List<Monster> ListOfMonstersBossAct5 { get; private set; }
    public List<Monster> ListOfOptionalBossAct2 { get; private set; }
    public List<Monster> ListOfOptionalBossAct5 { get; private set; }

    public MonsterContainer()
    {
        ListOfMonsters1 = new List<Monster>();
        ListOfMonsters2 = new List<Monster>();
        ListOfMonstersBossAct1 = new List<Monster>();
        ListOfSnowMonsters1 = new List<Monster>();
        ListOfMonstersSnowGoldGoblin = new List<Monster>();
        ListOfMonstersBossAct2 = new List<Monster>();
        ListOfMonstersAct3 = new List<Monster>();
        ListOfMonstersBossAct3 = new List<Monster>();
        ListOfMonstersAct4West = new List<Monster>();
        ListOfDragonsAct4East = new List<Monster>();
        ListOfDragonEggAct4North = new List<Monster>();
        ListOfMonstersAct1Quest1 = new List<Monster>();
        ListOfAct5Monsters = new List<Monster>();
        ListOfMonstersBossAct5 = new List<Monster>();
        ListOfOptionalBossAct2 = new List<Monster>();
        ListOfOptionalBossAct5 = new List<Monster>();
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
        Image normalWatchersImage = GetMonsterImage("watchers.png");
        Image normalWeakBanditImage = GetMonsterImage("weakbandit.png");

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
        Image lostPirateImage = GetMonsterImage("lostpirate.png");

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
        Image goldenDragonImage = GetMonsterImage("goldendragon.png");

        Image shadowImage = GetMonsterImage("shadow.png");
        Image jesterImage = GetMonsterImage("jester.png");
        Image falseLightEntityImage = GetMonsterImage("entityoffalselight.png");
        Image blackAngelImage = GetMonsterImage("blackangel.png");
        Image priestImage = GetMonsterImage("priest.png");
        Image crowImage = GetMonsterImage("crow.png");
        Image voidImage = GetMonsterImage("void.png");
        Image bloodVoidImage = GetMonsterImage("bloodvoid.png");
        Image deathAngelImage = GetMonsterImage("deathangel.png");
        Image darkMageImage = GetMonsterImage("darkmage.png");
        Image bloodHorrorImage = GetMonsterImage("bloodhorror.png");

        Image awokenHorrorImage = GetMonsterImage("awokenhorror.png");

        // List of normal monsters NORMAL - NOPREFIX - SNOW - NIGHTMARE - ELITE - HORROR - HELLISH - CORRUPTED
        Monster normalGoblin = new("Goblin", 10, 10, 0, 1, 3, 7, 3, normalGoblinImage);
        Monster normalOrc = new("Orc", 7, 7, 0, 0, 3, 9, 0, normalOrcImage);
        Monster normalSkeleton = new("Skeleton", 8, 8, 1, 0, 1, 8, 0, normalSkeletonImage);
        Monster normalGhast = new("Ghast", 7, 7, 1, 0, 4, 8, 1, normalGhastImage);
        Monster normalCorpse = new("Corpse", 8, 4, 1, 0, 2, 6, 0, normalCorpseImage);
        Monster normalDemon = new("Demon", 10, 10, 1, 0, 2, 10, 2, normalDemonImage);
        Monster normalGhost = new("Ghost", 8, 8, 0, 0, 3, 10, 1, normalGhostImage);
        Monster normalWatchers = new("Watchers", 9, 9, 0, 0, 3, 7, 1, normalWatchersImage);
        Monster normalWeakBandit = new("Weak Bandit", 6, 6, 0, 0, 1, 7, 0, normalWeakBanditImage);

        // Act 1 East
        Monster golem = new("Golem", 28, 28, 2, 0, 5, 15, 0, golemImage);
        Monster knight = new("Knight", 27, 27, 1, 0, 7, 17, 3, knightImage);
        Monster horror = new("Horror", 21, 21, 3, 0, 5, 13, 0, horrorImage);
        Monster starved = new("Starved", 17, 17, 1, 0, 7, 19, 0, starvedImage);
        Monster bat = new("Bat", 20, 20, 4, 0, 2, 12, 0, batImage);
        Monster woodHorror = new("Wood Horror", 16, 16, 0, 0, 8, 22, 4, woodHorrorImage);
        Monster deadTroll = new("Dead Troll", 19, 19, 3, 0, 5, 20, 2, deadTrollImage);
        Monster lost = new("Lost", 27, 27, 4, 0, 1, 2, 4, lostImage);
        Monster lizard = new("Lizard", 33, 33, 1, 0, 6, 30, 0, lizardImage);

        // Act 2 Snow Monsters
        Monster snowGoldGoblin = new("Gold Goblin", 30, 30, 6, 0, 10, 0, 9, snowGoblinImage);
        Monster snowDemon = new("Snow Demon", 35, 35, 11, 0, 5, 22, 0, snowDemonImage);
        Monster snowAntler = new("Snow Antler", 33, 33, 10, 0, 5, 18, 3, snowAntlerImage);
        Monster snowCrazed = new("Snow Crazed", 30, 30, 9, 0, 5, 15, 1, snowCrazedImage);
        Monster snowHorror = new("Snow Horror", 45, 45, 8, 0, 6, 25, 5, snowHorrorImage);
        Monster snowMoose = new("Snow Moose", 43, 43, 12, 0, 3, 20, 3, snowMooseImage);
        Monster snowAngel = new("Snow Angel", 39, 39, 6, 0, 11, 21, 0, snowAngelImage);

        // Act 3 Sea Monsters
        Monster seaHorror = new("Sea Horror", 140, 140, 10, 0, 15, 40, 12, seaHorrorImage);
        Monster seaTerror = new("Sea Terror", 150, 150, 8, 0, 20, 50, 0, seaTerrorImage);
        Monster seaGhost = new("Ghost of the Sea", 170, 170, 3, 0, 29, 30, 17, seaGhostImage);
        Monster seaMonster = new("Monster of the Sea", 115, 115, 24, 0, 3, 38, 20, seaMonsterImage);
        Monster kraken = new("Kraken", 120, 120, 24, 0, 0, 50, 0, octopusImage);
        Monster lostPirate = new("Lost Pirate", 153, 153, 5, 0, 21, 66, 24, lostPirateImage);

        // Act 4 Magma monsters west
        Monster burningSkeleton = new("Burning Skeleton", 220, 210, 35, 0, 0, 70, 30, burningSkeletonImage);
        Monster burningLizard = new("Burning Lizard", 240, 230, 24, 0, 0, 70, 30, burningLizardImage);
        Monster magmaFrog = new("Magma Frog", 210, 210, 12, 0, 2, 88, 30, magmaFrogImage);
        Monster magmaHorror = new("Magma Horror", 180, 180, 40, 0, 0, 20, 30, magmaHorrorImage);
        Monster forgottenPrince = new("Forgotten Prince", 195, 195, 20, 0, 12, 77, 30, forgottenPrinceImage);
        Monster fireKnight = new("Fire Knight", 200, 180, 34, 0, 0, 66, 30, fireKnightImage);

        // Act 4 Dragons east
        Monster casterDragon = new("Dragon Mage", 240, 240, 36, 0, 0, 90, 44, casterDragonImage);
        Monster dragonKing = new("Dragon King", 320, 320, 23, 0, 14, 100, 30, dragonKingImage);
        Monster dragonHydra = new("Dragon Hydra", 276, 276, 29, 0, 8, 79, 0, dragonHydraImage);
        Monster silverDragon = new("Silver Dragon", 260, 260, 43, 0, 0, 20, 60, silverDragonImage);
        Monster goldenDragon = new("Golden Dragon", 350, 350, 24, 0, 5, 20, 60, goldenDragonImage);

        // Act 4 Dragon Nest Egg North
        Monster dragonNestWatcher = new("Nest-Watcher Dragon", 310, 310, 15, 0, 50, 60, 0, dragonNestWatcherImage);
        Monster dragonEggWatcher = new("Egg-Watcher Dragon", 310, 310, 15, 0, 50, 60, 0, dragonEggWatcherImage);

        // Act 5
        Monster shadow = new("Shadow", 470, 470, 0, 0, 66, 80, 120, shadowImage);
        Monster jester = new("Jester", 299, 299, 0, 0, 93, 90, 20, jesterImage);
        Monster falseLightEntity = new("False Light Entity", 510, 510, 53, 0, 0, 150, 0, falseLightEntityImage);
        Monster blackAngel = new("Black Angel", 360, 360, 0, 0, 39, 120, 120, blackAngelImage);
        Monster priest = new("Priest", 415, 415, 0, 0, 67, 50, 180, priestImage);
        Monster crow = new("Crow", 320, 320, 0, 0, 89, 77, 0, crowImage);
        Monster voidMonster = new("Void", 470, 470, 32, 0, 40, 99, 160, voidImage);
        Monster bloodVoid = new("Blood Void", 373, 340, 0, 0, 58, 77, 0, bloodVoidImage);
        Monster deathAngel = new("Death Angel", 364, 364, 0, 0, 74, 120, 133, deathAngelImage);
        Monster darkMage = new("Dark Mage", 394, 394, 15, 0, 45, 150, 60, darkMageImage);
        Monster bloodHorror = new("Blood Horror", 340, 310, 0, 0, 56, 50, 0, bloodHorrorImage);

        // Special enemies
        Monster act1Boss = new("Aldrus Thornfell", 100, 100, 5, 0, 7, 40, 5, act1BossImage);
        Monster hungryBeast = new("Hungry Beast", 42, 42, 3, 0, 11, 30, 0, hungryBeastImage);
        Monster act2Boss = new("Wintermaw", 270, 270, 8, 0, 17, 50, 0, act2BossImage);
        Monster act3Boss = new("The Devouring Abyss", 400, 400, 15, 0, 30, 100, 30, null);
        Monster act5Boss = new("Awoken Horror", 1346, 1346, 40, 0, 80, 1000, 500, awokenHorrorImage);
        Monster act2OptionalBoss = new("The Frostfallen King", 1100, 1100, 48, 0, 25, 500, 0, null);
        Monster act5OptionalBoss = new("Ultimate Darkness", 9999, 9999, 77, 0, 77, 9999, 999, null);

        // Special enemies
        ListOfMonstersBossAct1.Add(act1Boss);
        ListOfMonstersSnowGoldGoblin.Add(snowGoldGoblin);
        ListOfMonstersBossAct2.Add(act2Boss);
        ListOfMonstersBossAct3.Add(act3Boss);
        ListOfMonstersAct1Quest1.Add(hungryBeast);
        ListOfOptionalBossAct2.Add(act2OptionalBoss);
        ListOfOptionalBossAct5.Add(act5OptionalBoss);
        
        // List of Monsters 1
        ListOfMonsters1.Add(normalGoblin);
        ListOfMonsters1.Add(normalOrc);
        ListOfMonsters1.Add(normalSkeleton);
        ListOfMonsters1.Add(normalGhast);
        ListOfMonsters1.Add(normalCorpse);
        ListOfMonsters1.Add(normalDemon);
        ListOfMonsters1.Add(normalGhost);
        ListOfMonsters1.Add(normalWatchers);
        ListOfMonsters1.Add(normalWeakBandit);

        // List of Monsters 2
        ListOfMonsters2.Add(normalGhost);
        ListOfMonsters2.Add(normalGhast);
        ListOfMonsters2.Add(golem);
        ListOfMonsters2.Add(knight);
        ListOfMonsters2.Add(horror);
        ListOfMonsters2.Add(starved);
        ListOfMonsters2.Add(bat);
        ListOfMonsters2.Add(woodHorror);
        ListOfMonsters2.Add(deadTroll);
        ListOfMonsters2.Add(lost);
        ListOfMonsters2.Add(lizard);

        // Act 2 list of snow monsters
        ListOfSnowMonsters1.Add(snowDemon);
        ListOfSnowMonsters1.Add(snowAntler);
        ListOfSnowMonsters1.Add(snowCrazed);
        ListOfSnowMonsters1.Add(snowMoose);
        ListOfSnowMonsters1.Add(snowHorror);
        ListOfSnowMonsters1.Add(snowAngel);

        // Act 3 list of sea monsters
        ListOfMonstersAct3.Add(seaHorror);
        ListOfMonstersAct3.Add(seaGhost);
        ListOfMonstersAct3.Add(seaTerror);
        ListOfMonstersAct3.Add(seaMonster);
        ListOfMonstersAct3.Add(kraken);
        ListOfMonstersAct3.Add(lostPirate);

        // Act 4 list west
        ListOfMonstersAct4West.Add(burningSkeleton);
        ListOfMonstersAct4West.Add(burningLizard);
        ListOfMonstersAct4West.Add(magmaFrog);
        ListOfMonstersAct4West.Add(magmaHorror);
        ListOfMonstersAct4West.Add(forgottenPrince);
        ListOfMonstersAct4West.Add(fireKnight);

        // Act 4 list east Dragons
        ListOfDragonsAct4East.Add(casterDragon);
        ListOfDragonsAct4East.Add(dragonKing);
        ListOfDragonsAct4East.Add(silverDragon);
        ListOfDragonsAct4East.Add(dragonHydra);
        ListOfDragonsAct4East.Add(goldenDragon);

        // Act 4 Dragon Eggs North
        ListOfDragonEggAct4North.Add(dragonNestWatcher);
        ListOfDragonEggAct4North.Add(dragonNestWatcher);
        ListOfDragonEggAct4North.Add(dragonNestWatcher);
        ListOfDragonEggAct4North.Add(dragonNestWatcher);
        ListOfDragonEggAct4North.Add(dragonNestWatcher);
        ListOfDragonEggAct4North.Add(dragonEggWatcher);
        ListOfDragonEggAct4North.Add(dragonEggWatcher);
        ListOfDragonEggAct4North.Add(dragonEggWatcher);

        // Act 5 West & East
        ListOfAct5Monsters.Add(shadow);
        ListOfAct5Monsters.Add(jester);
        ListOfAct5Monsters.Add(falseLightEntity);
        ListOfAct5Monsters.Add(blackAngel);
        ListOfAct5Monsters.Add(priest);
        ListOfAct5Monsters.Add(crow);
        ListOfAct5Monsters.Add(bloodVoid);
        ListOfAct5Monsters.Add(voidMonster);
        ListOfAct5Monsters.Add(deathAngel);
        ListOfAct5Monsters.Add(darkMage);
        ListOfAct5Monsters.Add(bloodHorror);

        // Act 5 Boss
        ListOfMonstersBossAct5.Add(act5Boss);

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
