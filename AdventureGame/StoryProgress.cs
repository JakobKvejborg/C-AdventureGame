
using System.Reflection.Metadata.Ecma335;

namespace AdventureGame;

internal class StoryProgress
{

    public int StoryState;
    public MonsterContainer monsterContainer = new MonsterContainer();
    public ItemContainer itemContainer = new ItemContainer();
    public static bool progressFlag { get; set; }
    public static bool playerIsInTown { get; set; } = false;
    private MainWindow _mainWindow;
    public bool oneTimeMessage = true;
    bool oneTimeMessage2 = true;
    bool oneTimeMessage3 = true;
    private ImageSetter _imageSetter;
    public MusicAndSound _sounds;
    private PlayVideos _videos;
    public static bool TutorialIsOver { get; set; }
    private int MageTalkInteractionCounter = 0;
    public bool Act1ArtsTeacherIsAvailable { get; set; } = true;
    public bool Act1BossDefeatedFlag = false;
    public bool Act2BossDefeatedFlag = false;
    public bool Act3BossDefeatedFlag = false;
    public bool Act5BossDefeatedFlag = false;
    public bool Act2OptionalBossDefeatedFlag;
    public bool Act5UltimatedarknessBossDefeatedFlag;
    public bool SophiaIsAlive { get; private set; }
    public static int WhichActIsThePlayerIn { get; set; } = 1;
    public static bool PlayerHasEnteredAct4 { get; set; }

    public StoryProgress(MainWindow mainWindow, MusicAndSound sounds, PlayVideos videos)
    {
        _mainWindow = mainWindow;
        _imageSetter = new ImageSetter(mainWindow);
        _sounds = sounds;
        _videos = videos;
    }

    public string GetFirstText()
    {
        return "The road home is littered with corpses.\n\r Do you have the will to survive the horrors of the lands?" +
            "\r\nYour sister is missing - you must find her!";
    }

    public string GetSecondText()
    {
        return "You ride through the thickening fog, the air heavy with dread. " +
            "A deadly horror emerges. It blocks your path - deny its life!";
    }

    public string GetHealingText()
    {
        return "The old man lays his hands on your wounds and whisper magic words. You feel refreshed.";
    }
    public string GetAct2HealingText()
    {
        return "The girl’s white eyes hints her blindness, but as you approach she seems to see you coming. " +
            "She takes care of your wounds and you hand her some coins as thanks.";
    }
    public string GetAct4HealingText()
    {
        return "\"Careful, the Dragons may bite,\" the girl says with a hint of a smile on her face. The fire burns hot around her. " +
            "\"You don't have to pay me, I'm just glad to help!\" You pay for her help anyways.";
    }

    public string GetAct4FirstTimeText()
    {
        return "After almost drowning you arrive at the fiery lands of the Dragons. " +
            "As the towering beasts loom in the distance, you begin to worry you'll never find Sophia.";
    }

    public string GetAct3FrogReforgeText()
    {
        return "\"Did it work? Did it work, you ask... I have no idea! Go see for yourself!\" *Ribbit*";
    }

    public string GetAct3FrogItemAlreadyReforgedText()
    {
        return "\"Looks like I've already applied my skills to this item! Hopefully it's what you wanted! And if not... Oh well.\" *Ribbit*";
    }
    public string GetAct3FrogNoCoinText()
    {
        return "\"You nearly don't have any coins! What are you, some kind of cheap pirate? Aarrrrr, haha!\" *Ribbit*";
    }

    public string GetAct4PortalText()
    {
        return "The molten girl takes you to a portal leading to the skies high above. Did Sophia really come here? Maybe she was taken here - hopefully she's still alive.";
    }

    public string GetSophiaIsSavedText()
    {
        return "Sophia embraces you with tears streaming down her face. You have saved her, and the world seems just a bit brighter. " +
                        "\"About time! What took you so long?\" she says smiling, with tears coming down her cheeks. Sophia returns with you out of the door behind you." +
                        " Congratulations Hero, you have finally done it. " +
                        $"But one last challenge remains - if you dare. MODIFIER: [{ModifierProcessor.GetRandomModifier()}]";
    }

    public string GetTimeTravelText()
    {
        return "The Hero now must journey back through time, wielding the wisdom of past battles to change the fate of Sophia. Use the given Modifier code to gain " +
            "some small advantage, and be stronger than before. Many Modifier codes can be collected at random, and any number of Modifier codes can be used " +
            "each run. ";
    }

    public string GetMageText(bool playerHasDragonEggs)
    {
        if (playerHasDragonEggs)
        {
            return "\"Ahhh, the eggs! Magnificent, yesss! Here, take this as your reward... Now go, before I change my mind!";
        }
        switch (MageTalkInteractionCounter)
        {
            case 0:
                MageTalkInteractionCounter++;
                return "\"Hmmm yesss... You! Collect me three dragon eggs. Yes, three! And then, maybe... " +
                    "just MAYBE, I'll give you something... useful in return. Yesss, heehe...\"";
            default:
                return "\"Hmmmm whyyy are you here without the eggs? I need the dragon eggs! Three of them. Romours say there are nests north of here... " +
                    "Hehehe...";
        }
    }

    public string GetMageDoesntWantAnythingText()
    {
        return "\"I don't want anything more from you, so go away! Hmmmmmm...\"";
    }

    public void ProgressStory()
    {
        switch (StoryState)
        {
            case 0:
                _mainWindow.textBoxEncounter.Clear();
                _mainWindow.textBoxEncounter.AppendText(GetFirstText());
                StoryState++;
                break;
            case 1:
                _mainWindow.textBoxEncounter.Clear();
                _mainWindow.textBoxEncounter.AppendText(GetSecondText());
                StoryState++;
                break;
            case 2:
                _mainWindow.pictureBoxHero.Show();
                _mainWindow.btn_attack.Show();
                _mainWindow.pictureBoxHeroBag.Show();
                Encounter.PerformEncounter(monsterContainer.ListOfMonsters1, itemContainer.items1, _mainWindow);
                _mainWindow.textBoxEncounter.AppendText("");
                StoryState++;
                break;
            case 3:
            case 4:
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfMonsters1, itemContainer.items1, _mainWindow);
                    StoryState++;
                }
                break;
            case 5:
            case 6:
            case 7: // The player enters town act 1
                if (progressFlag == true)
                {

                    if (oneTimeMessage == true)
                    {
                        _sounds.PlayAct1TownMusic();
                        _mainWindow.txtBox_Town.Text = "You finally arrive at your hometown. The many horrors surrounding the town does not bode well for Sophia. " +
                            "The town is dead quiet. " +
                            "Be vary of the road straight ahead.";
                        oneTimeMessage = false;
                    }
                    else
                    {
                        _mainWindow.txtBox_Town.Text = "You return to the nearly abandoned town. " +
                            "\r\nWhat comes next is up to you.";
                    }
                    WhichActIsThePlayerIn = 1;
                    _imageSetter.SetAct1TownBackgroundimage();
                    _mainWindow.pictureBoxAct1ArtsTeacher.Image = _imageSetter.GetImagePath("act1artsteacher.png");
                    _sounds.StopAct2TownMusic();
                    PlayerIsInTown();
                    //StoryState++; // When this line isn't excecuted, the story will loop here
                    if (Act1ArtsTeacherIsAvailable)
                    {
                        _mainWindow.pictureBoxAct1ArtsTeacher.Show();
                        _mainWindow.buttonLearnTechnique.Show();
                    }
                    SetupAct1Controls();
                    progressFlag = true; // The progressFlag is set to false in performEncounter
                }
                TutorialIsOver = true;
                break;
            case 8:
                _mainWindow.textBoxEncounter.Text = "After slaying the demon tree, you venture forth, much further to the north. ";
                StoryState++;
                break;
            case 9:
                _sounds.StopAct1TownMusic();
                _sounds.PlayAct2WindMusic();
                _imageSetter.SetAct2BackgroundImages();
                _mainWindow.textBoxEncounter.Text = "The high mountains are cold, and you are close to freezing to death. " +
                    "But you must continue and face the horrors ahead. You must find Sophia!";
                oneTimeMessage = (true); // Reusing the flag for act2
                StoryState++;
                break;
            case 10:
            case 11: // The player enters Act2
                WhichActIsThePlayerIn = 2;
                _mainWindow.IsReturnToTownEnabled = true;
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfSnowMonsters1, itemContainer.items1, _mainWindow);
                    StoryState++;
                }
                break;
            case 12: // Town Act 2
                IfFrostfallenKingIsDefeated();
                if (progressFlag == true)
                {
                    if (oneTimeMessage == true)
                    {
                        _sounds.PlayAct2TownMusic();

                        _mainWindow.txtBox_Town.Text = "A frozen town. Time almost stands still here. " +
                            "The roads are buried under a thick blanket of snow, with not a footprint in sight.";
                        oneTimeMessage = false;
                    }
                    else
                    {
                        _mainWindow.txtBox_Town.Text = "You return to the small frozen town. " +
                            "\r\nMaybe the few people living here can help you.";
                    }
                    WhichActIsThePlayerIn = 2;
                    SetupAct2controls();
                    PlayerIsInTown();
                    //StoryState++; // When this line isn't excecuted, the story will loop here
                    progressFlag = true; // The progressFlag is set to false in performEncounter
                }
                break;
            case 13: // Act 2 boss is defeated
                _mainWindow.textBoxEncounter.Text = "The colossal snow beast crashes to the ground, dead. " +
                    "Your quest now leads you beyond the shores and into the vast expanse of the sea.";
                StoryState++;
                break;
            case 14:
                playerIsInTown = false;
                SetUpAct3Controls();
                _sounds.PlayAct3Music();
                _mainWindow.textBoxEncounter.Text = "You feel lost at sea. Get eaten by a seamonster or drown - which is worse? ";
                StoryState++;
                break;
            case 15:
                if (progressFlag == true)
                {
                    EnableReturnToTownFunction();
                    Encounter.PerformEncounter(monsterContainer.ListOfMonstersAct3, itemContainer.items4, _mainWindow);
                    StoryState++;
                }
                break;
            case 16: // The player enters town act 3
                SetUpAct3Controls();
                if (progressFlag == true)
                {
                    if (oneTimeMessage3 == true)
                    {
                        _sounds.PlayAct3Waves();
                        // sounds.playact3music TODO maybe?
                        oneTimeMessage3 = false;
                    }
                    PlayerIsInTown();
                    _mainWindow.txtBox_Town.Text = "There's nothing out here for you. You consider returning to the frozen town, or continuing forward. ";
                }
                break;
            case 17: // Act 4 start
                SetupAct4Controls();
                _sounds.PlayAct4Music();
                if (oneTimeMessage2)
                {
                    _mainWindow.textBoxEncounter.Text = GetAct4FirstTimeText();
                    oneTimeMessage2 = false;
                }
                else // This message is displayed when coming from act 5
                {
                    _mainWindow.txtBox_Town.Text = "The town is still standing, luckily the dragons haven't burned it down just yet. Where to next?";
                }
                StoryState++;
                break;
            case 18: // Town Act 4
                SetupAct4Controls();
                EnableReturnToTownFunction();
                if (progressFlag == true)
                {
                    PlayerIsInTown();
                    _mainWindow.txtBox_Town.Text = "The fiery town is burning hot, you can barely breathe. But surely here you will find what you're searching for. \r\nOr maybe it's here you'll die trying.";
                    progressFlag = true;
                    //StoryState++;
                }
                break;
            case 19: // Act 5 start
                SetupAct5Controls();
                //_sounds. // TODO
                playerIsInTown = false;
                _mainWindow.panelTown.Show();
                _imageSetter.SetAct5IntroImage();
                _mainWindow.txtBox_Town.Text = GetAct4PortalText();
                _mainWindow.IsReturnToTownEnabled = false;
                _mainWindow.pictureBoxCompass.Hide();
                StoryState++;
                break;
            case 20: // Town Act 5
                IfDarknessIsDefeated();
                SetupAct5Controls();
                _mainWindow.pictureBoxAct5Hero.Show();
                EnableReturnToTownFunction();
                if (progressFlag == true)
                {
                    PlayerIsInTown();
                    _mainWindow.txtBox_Town.Text = "Three doors black as the void. The nightmares on the other side are just waiting for the next victim to enter. Which to choose?";
                }
                break;
            case 21:
                _mainWindow.textBoxEncounter.Text = "You have slain the Awoken Horror. There's not a sound to be heard. You've almost lost your mind, and all hope with it.";
                StoryState++;
                break;
            case 22:
                _mainWindow.textBoxEncounter.Text = "You look a little further into the void, hoping to find any signs of life. And then, right in front of you, there she is.";
                StoryState++;
                break;
            case 23: // ENDING
                _mainWindow.pictureBoxCompass.Hide();
                _mainWindow.txtBox_Town.Clear();
                _mainWindow.pictureBoxAct5Hero.Hide();
                _mainWindow.panelEncounter.Hide();
                _mainWindow.panelTown.Show();

                if (Encounter.TotalNumberOfMonstersDefeated < 201 && ModifierProcessor.NumberOfModifiersCurrentlyActive >= 3) // If Sophia is alive
                {
                    _imageSetter.SetAct5SophiaAlive();
                    _mainWindow.txtBox_Town.Text = GetSophiaIsSavedText();
                    SophiaIsAlive = true;
                    StoryState = 20; // Advance the story state
                }
                else // If Sophia is not alive
                {
                    _mainWindow.txtBox_Town.Text = "You find Sophia's lifeless body in the void. The darkness has consumed her. " +
                        "Your heart sinks as you realize you've failed to save her.";
                    _imageSetter.SetAct5SophiaDeath(); // Show an image for Sophia being dead, if applicable
                    StoryState++; // Advance the story state
                }
                break;
            case 24:
                _mainWindow.txtBox_Town.Text = GetTimeTravelText();
                StoryState++;
                break;
            case 25: // Player gets the Modifier code
                _mainWindow.txtBox_Town.Text = $"MODIFIER: [{ModifierProcessor.GetRandomModifier()}] Write this code down, and use it on your next playthrough. Now go and save her, and good luck Hero!";
                StoryState = 20;
                break;



            // Special cases:
            case 99: // Act 1 Quest 1 Hungry Beast
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfMonstersAct1Quest1, itemContainer.noItems, _mainWindow);
                    StoryState = 7;
                }
                break;
            case 100: // Act 1 West repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfMonsters1, itemContainer.items1, _mainWindow);
                }
                break;
            case 101: // Act 1 East repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfMonsters2, itemContainer.items2, _mainWindow);
                }
                break;
            case 102: // Act 2 West repeated GOBLINS
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfMonstersSnowGoldGoblin, itemContainer.noItems, _mainWindow);
                }
                break;
            case 103: // Act 2 East repeated Snow
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfSnowMonsters1, itemContainer.items3, _mainWindow);
                }
                break;
            case 104: // Act 3 West & East repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfMonstersAct3, itemContainer.items4, _mainWindow);
                }
                break;
            case 105: // Act 4 East dragons repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfDragonsAct4East, itemContainer.items6, _mainWindow);
                }
                break;
            case 106: // Act 4 West repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfMonstersAct4West, itemContainer.items5, _mainWindow);
                }
                break;
            case 107: // Act 4 Dragon Eggs North
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfDragonEggAct4North, itemContainer.noItems, _mainWindow);
                }
                break;
            case 108: // Act 5 West repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfAct5Monsters, itemContainer.items7, _mainWindow);
                }
                break;
            case 109: // Act 5 East
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.ListOfAct5Monsters, itemContainer.items8, _mainWindow);
                }
                break;
            case 110: // Act 2 Optional boss The Frostfallen King
                if (progressFlag == true)
                {
                    _imageSetter.SetAct2FrostFallenKingImage();
                    _sounds.PlayAct2FrostfallenKing();
                    _mainWindow.buttonReturnToTown.Hide();
                    Encounter.PerformEncounter(monsterContainer.ListOfOptionalBossAct2, itemContainer.godlyBossItems, _mainWindow);
                    Act2OptionalBossDefeatedFlag = true;
                    StoryState = 12;
                }
                break;
            case 111: // Act 5 Final boss Ultimate Darkness
                if (progressFlag == true)
                {
                    _imageSetter.SetAct5SecretFinalBossImage();
                    //_sounds. // TODO
                    _mainWindow.buttonReturnToTown.Hide();
                    Encounter.PerformEncounter(monsterContainer.ListOfOptionalBossAct5, itemContainer.godlyBossItems, _mainWindow);
                    Act5UltimatedarknessBossDefeatedFlag = true;
                    StoryState = 20;
                }
                break;

        }
    }

    private void IfDarknessIsDefeated()
    {
        if (Act5UltimatedarknessBossDefeatedFlag == true && !_videos.OneTimeDarknessVideoHasBeenPlayed)
        {
            _videos.PlayAnyVideo("darkness.mov");
            _videos.OneTimeDarknessVideoHasBeenPlayed = true;
        }
    }

    private void IfFrostfallenKingIsDefeated()
    {
        if (Act2OptionalBossDefeatedFlag == true && !_videos.OneTimeFrostfallenVideoHasBeenPlayed)
        {
            _videos.PlayAnyVideo("frostfallenking.mov");
            _videos.OneTimeFrostfallenVideoHasBeenPlayed = true;
            Act1ArtsTeacherIsAvailable = true;
        }
    }

    private void SetupAct5Controls()
    {
        WhichActIsThePlayerIn = 5;
        _sounds.StopAct4Music();

        _imageSetter.SetAct5EncounterBackground();
        _mainWindow.pictureBoxCompass.Show();
        _mainWindow.panelAct4Quest1.Hide();
        _imageSetter.SetAct5TownBackgroundImage();
        _mainWindow.buttonHeal.Hide();
        _mainWindow.pictureBoxAct4Mage.Hide();
        _mainWindow.labelAct4Q1.Hide();
        _mainWindow.buttonTalkMage.Hide();
        _mainWindow.pictureBoxHealer.Hide();
        _mainWindow.labelAct5Q1.Show();
    }

    private void SetupAct1Controls()
    {
        _sounds.StopAct2TownMusic();
        _imageSetter.SetAct1Backgroundimage();
        _imageSetter.SetAct1TownBackgroundimage();
        _imageSetter.SetAct1HealerPictureBoxImage();
        _mainWindow.pictureBoxAct2Smith.Hide();
        _mainWindow.buttonUpgradeItem.Hide();
        _mainWindow.comboBoxUpgradeItems.Hide();
        _mainWindow.labelAct1Quest1.Show();
        _mainWindow.labelAct2Q1.Hide();
    }

    private void EnableReturnToTownFunction()
    {
        _mainWindow.buttonReturnToTown.Enabled = true;
        _mainWindow.IsReturnToTownEnabled = true;
        _mainWindow.buttonReturnToTown.Show();
    }

    private void SetupAct4Controls()
    {
        WhichActIsThePlayerIn = 4;
        PlayerHasEnteredAct4 = true;
        _imageSetter.SetAct4EncounterBackgroundImage();
        _imageSetter.SetAct4TownBackgroundImage();
        _mainWindow.pictureBoxHealer.Show();
        _mainWindow.buttonHeal.Show();
        _imageSetter.SetAct4HealerImage();
        _imageSetter.SetAct4MageImage();
        _mainWindow.pictureBoxAct4Mage.Show();
        _mainWindow.labelAct4Q1.Show();
        _mainWindow.labelAct3Q1.Hide();
        _mainWindow.buttonTalkMage.Show();
        _mainWindow.pictureBoxAct5Hero.Hide();
        _mainWindow.labelAct5Q1.Hide();

        _sounds.StopAct3Waves();
        _sounds.StopAct3Music();
    }

    private void SetUpAct3Controls()
    {
        WhichActIsThePlayerIn = 3;
        _imageSetter.SetAct3Backgroundimage();
        _mainWindow.comboBoxUpgradeItems.Hide();
        _mainWindow.buttonUpgradeItem.Hide();
        _mainWindow.pictureBoxAct2Smith.Hide();
        _mainWindow.pictureBoxHealer.Hide();
        _mainWindow.buttonHeal.Hide();
        _mainWindow.pictureBoxAct1ArtsTeacher.Hide();
        _mainWindow.pictureBoxAct4Mage.Hide();
        WhichActIsThePlayerIn = 3;
        _mainWindow.labelAct4Q1.Hide();
        _mainWindow.labelAct3Q1.Show();
        _mainWindow.buttonTalkMage.Hide();
        _mainWindow.labelAct2Q1.Hide();

        _sounds.StopAct4Music();
        _sounds.StopAct2WindSound();
        _sounds.StopAct2TownMusic();
    }

    public void SetupAct2controls()
    {
        _mainWindow.labelAct2Q1.Show();
        _imageSetter.SetAct2BackgroundImages();
        _imageSetter.SetAct2HealerPictureBoxImage();
        _mainWindow.pictureBoxAct1ArtsTeacher.Hide();
        _mainWindow.buttonLearnTechnique.Hide();
        _mainWindow.pictureBoxHealer.Show();
        _mainWindow.buttonHeal.Show();
        _mainWindow.pictureBoxHealer.SizeMode = PictureBoxSizeMode.Zoom;
        _mainWindow.pictureBoxAct2Smith.Show();
        _mainWindow.comboBoxUpgradeItems.Show();
        _mainWindow.buttonUpgradeItem.Show();
        _mainWindow.labelAct1Quest1.Hide();
        _mainWindow.labelAct3Q1.Hide();

        _sounds.StopAct1TownMusic();
        _sounds.StopAct3Waves();
        _sounds.StopAct3Music();
    }

    private void PlayerIsInTown()
    {
        _mainWindow.textBoxEncounter.Clear();
        _mainWindow.panelEncounter.Hide();
        _mainWindow.panelTown.Show();
        _mainWindow.HideInventory();
        playerIsInTown = true;
    }


}