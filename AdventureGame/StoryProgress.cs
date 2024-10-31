
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
    private ImageSetter imageSetter = new ImageSetter();
    private MusicAndSound sounds = new MusicAndSound();
    public static bool TutorialIsOver { get; set; }

    public StoryProgress(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public string GetFirstText()
    {
        return "You have just returned from a long journey to far realms." +
            "\n\r The roads are littered with corpses.\n\r Do you have the will to survive the Horrors of the lands?";
    }

    private void NextPanel() // Currently unused. Maybe this could've been used to switch between different acts/towns
    {
        if (_mainWindow.panelsIndex < _mainWindow.panelsList.Count - 1)
        {
            _mainWindow.panelsList[++_mainWindow.panelsIndex].BringToFront();
        }
    }

    public string GetSecondText()
    {
        return "You ride through the thickening fog, the air heavy with dread." +
            " A chill sweeps over you as a deadly fiend emerges. It blocks your path - deny its life!";
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

    public void ProgressStory()
    {
        switch (StoryState)
        {
            case 0:
                _mainWindow.textBox1.Clear();
                _mainWindow.textBox1.AppendText(GetFirstText());
                StoryState++;
                break;
            case 1:
                _mainWindow.textBox1.Clear();
                _mainWindow.textBox1.AppendText(GetSecondText());
                StoryState++;
                break;
            case 2:
                _mainWindow.pictureBoxHero.Show();
                _mainWindow.pictureBoxHeroBag.Show();
                Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1, _mainWindow);
                _mainWindow.textBox1.AppendText("");
                StoryState++;
                break;
            case 3:
            case 4:
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1, _mainWindow);
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
                        sounds.PlayAct1TownMusic();
                        _mainWindow.SetAct1TownBackgroundimage(); // TODO DELETE
                        _mainWindow.txtBox_Town.Text = "You come across a small town in the middle of the forest. " +
                            "While the town isn’t completely deserted, it's dead quiet. " +
                            "Be vary of the road straight ahead. Choose a path.";
                        oneTimeMessage = false;
                    }
                    else
                    {
                        _mainWindow.txtBox_Town.Text = "You return to the nearly abandoned town. " +
                            "\r\nWhat comes next is up to you.";
                    }
                    PlayerIsInTown();
                    //StoryState++; // When this line isn't excecuted, the story will loop here
                    progressFlag = true; // The progressFlag is set to false in performEncounter
                }
                TutorialIsOver = true;
                break;
            case 8:
                _mainWindow.textBox1.Text = "After slaying the demon tree, you venture forth, much further to the north. ";
                StoryState++;
                break;
            case 9:
                sounds.PlayAct2WindMusic();
                _mainWindow.SetAct2Backgroundimage();
                _mainWindow.textBox1.Text = "The high mountains are cold, and you are close to freezing to death. " +
                    "But for some unknown reason you mindlessly continue - to face the horrors ahead.";
                oneTimeMessage = (true); // Reusing the flag for act2
                StoryState++;
                break;
            case 10:
            case 11:
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.listOfSnowMonsters1, itemContainer.items1, _mainWindow);
                    StoryState++;
                }
                break;
            case 12: // The player enters town Act2 
                if (progressFlag == true)
                {
                    if (oneTimeMessage == true)
                    {
                        _mainWindow.txtBox_Town.Text = "A frozen town. Time almost stands still here. " +
                            "The streets are buried under a thick blanket of snow, with not a footprint in sight.";
                        SetupAct2controls();
                        oneTimeMessage = false;
                    }
                    else
                    {
                        _mainWindow.txtBox_Town.Text = "You return to the small frozen town. " +
                            "\r\nMaybe the few people living here can help you.";
                    }
                    PlayerIsInTown();
                    //StoryState++; // When this line isn't excecuted, the story will loop here
                    progressFlag = true; // The progressFlag is set to false in performEncounter
                }
                break;

            // Special cases:
            case 100: // Act 1 West repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1, _mainWindow);
                }
                break;
            case 101: // Act 1 East repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.listOfMonsters2, itemContainer.items2, _mainWindow);
                }
                break;
            case 102: // Act 2 East repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.listOfSnowMonsters1, itemContainer.items1, _mainWindow);
                }
                break;
            case 103: // Act 2 West repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.listOfMonstersSnowGoldGoblin, itemContainer.noItems, _mainWindow);
                }
                break;
        }
    }

    private void SetupAct2controls()
    {
        _mainWindow.pictureBoxTown.Image = imageSetter.GetImagePath("act2town.png"); // Sets the town image to Act2Town
        _mainWindow.pictureBoxHealer.Image = imageSetter.GetImagePath("act2healer.png");
        _mainWindow.pictureBoxAct2Smith.Image = imageSetter.GetImagePath("act2smith.png");
        _mainWindow.pictureBoxHealer.Size = new Size(210, 310);
        _mainWindow.pictureBoxAct2Smith.Show();
        _mainWindow.comboBoxUpgradeItems.Show();
        _mainWindow.buttonUpgradeItem.Show();
    }

    private void PlayerIsInTown()
    {
        _mainWindow.textBox1.Clear();
        _mainWindow.panelEncounter.Hide();
        _mainWindow.panelTown.Show();
        _mainWindow.HideInventory();
        playerIsInTown = true;
    }


}