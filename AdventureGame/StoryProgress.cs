

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
    private ImageSetter imageSetter;
    public MusicAndSound sounds = new MusicAndSound();
    public static bool TutorialIsOver { get; set; }
    public bool Act1ArtsTeacherIsAvailable { get; set; } = true;
    public bool Act1BossDefeatedFlag = false;
    public bool Act2BossDefeatedFlag = false;
    public bool Act3BossDefeatedFlag = false;
    public int WhichActIsThePlayerIn { get; set; } = 1;

    public StoryProgress(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
        imageSetter = new ImageSetter(mainWindow);
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
                _mainWindow.btn_attack.Show();
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
                    WhichActIsThePlayerIn = 1;
                    imageSetter.SetAct1TownBackgroundimage();
                    _mainWindow.pictureBoxAct1ArtsTeacher.Image = imageSetter.GetImagePath("act1artsteacher.png");
                    sounds.StopAct2TownMusic();
                    PlayerIsInTown();
                    //StoryState++; // When this line isn't excecuted, the story will loop here
                    if (Act1ArtsTeacherIsAvailable)
                    {
                        _mainWindow.pictureBoxAct1ArtsTeacher.Show();
                        _mainWindow.buttonLearnTechnique.Show();
                    }
                    progressFlag = true; // The progressFlag is set to false in performEncounter
                }
                TutorialIsOver = true;
                break;
            case 8:
                _mainWindow.textBox1.Text = "After slaying the demon tree, you venture forth, much further to the north. ";
                StoryState++;
                break;
            case 9:
                sounds.StopAct1TownMusic();
                sounds.PlayAct2WindMusic();
                imageSetter.SetAct2Backgroundimage();
                _mainWindow.textBox1.Text = "The high mountains are cold, and you are close to freezing to death. " +
                    "But for some unknown reason you mindlessly continue - to face the horrors ahead.";
                oneTimeMessage = (true); // Reusing the flag for act2
                StoryState++;
                break;
            case 10:
            case 11:
                WhichActIsThePlayerIn = 2;
                _mainWindow.IsReturnToTownEnabled = true;
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
                        sounds.PlayAct2TownMusic();
                        sounds.StopAct1TownMusic();
                        _mainWindow.txtBox_Town.Text = "A frozen town. Time almost stands still here. " +
                            "The streets are buried under a thick blanket of snow, with not a footprint in sight.";
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
                _mainWindow.textBox1.Text = "The colossal snow beast crashes to the ground, dead. " +
                    "Your quest now leads you beyond the shores and into the vast expanse of the sea. ";
                StoryState++;
                break;
            case 14:
                playerIsInTown = false;
                SetUpAct3Controls();
                WhichActIsThePlayerIn = 3;
                imageSetter.SetAct3Backgroundimage();
                sounds.PlayAct3Waves();
                _mainWindow.textBox1.Text = "You feel lost at sea. Get eaten by a seamonster or drown - which is worse? ";
                StoryState++;
                break;
            case 15:
                if (progressFlag == true)
                {
                    _mainWindow.buttonReturnToTown.Enabled = true;
                    _mainWindow.IsReturnToTownEnabled = true;
                    _mainWindow.buttonReturnToTown.Show();
                    Encounter.PerformEncounter(monsterContainer.listOfMonstersAct3, itemContainer.items4, _mainWindow);
                    StoryState++;
                }
                break;
            case 16: // The player enters town act 3
                SetUpAct3Controls();
                WhichActIsThePlayerIn = 3;
                if (progressFlag == true)
                {
                    playerIsInTown = true;
                    PlayerIsInTown();
                    // sounds.playact3music
                    _mainWindow.txtBox_Town.Text = "There's nothing out here for you. You consider returning to the frozen town, or continuing forward. ";
                }
                break;


            // Special cases:
            case 99: // Act 1 Quest 1 Hungry Beast
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.listOfMonstersAct1Quest1, itemContainer.noItems, _mainWindow);
                    StoryState = 7;
                }
                break;
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
            case 102: // Act 2 West repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.listOfMonstersSnowGoldGoblin, itemContainer.noItems, _mainWindow);
                }
                break;
            case 103: // Act 2 East repeated snow
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.listOfSnowMonsters1, itemContainer.items3, _mainWindow);
                }
                break;
            case 104: // Act 3 West & East repeated
                if (progressFlag == true)
                {
                    Encounter.PerformEncounter(monsterContainer.listOfMonstersAct3, itemContainer.items4, _mainWindow);
                }
                break;
        }
    }

    private void SetUpAct3Controls()
    {
        imageSetter.SetAct3Backgroundimage();
        _mainWindow.comboBoxUpgradeItems.Hide();
        _mainWindow.buttonUpgradeItem.Hide();
        _mainWindow.pictureBoxTown.Hide();
        _mainWindow.pictureBoxAct2Smith.Hide();
        _mainWindow.pictureBoxHealer.Hide();
        _mainWindow.buttonHeal.Hide();
        _mainWindow.pictureBoxAct1ArtsTeacher.Hide();
        WhichActIsThePlayerIn = 3;

        sounds.StopAct2WindSound();
        sounds.StopAct2TownMusic();
    }

    public void SetupAct2controls()
    {
        imageSetter.SetAct2Backgroundimage();
        imageSetter.SetAct2PictureBoxTownImage(); // Sets the town image to Act2Town
        imageSetter.SetAct2HealerPictureBoxImage();
        imageSetter.SetAct2SmithPictureBoxImage();
        _mainWindow.pictureBoxAct1ArtsTeacher.Hide();
        _mainWindow.buttonLearnTechnique.Hide();
        _mainWindow.pictureBoxHealer.Show();
        _mainWindow.buttonHeal.Show();
        _mainWindow.pictureBoxHealer.Size = new Size(210, 310);
        _mainWindow.pictureBoxHealer.SizeMode = PictureBoxSizeMode.Zoom;
        _mainWindow.pictureBoxAct2Smith.Show();
        _mainWindow.comboBoxUpgradeItems.Show();
        _mainWindow.buttonUpgradeItem.Show();
        _mainWindow.pictureBoxTown.Show();
        _mainWindow.labelAct1Quest1.Hide();
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