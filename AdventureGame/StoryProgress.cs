namespace AdventureGame;

internal class StoryProgress
{

    public int StoryState;
    public MonsterContainer monsterContainer = new MonsterContainer();
    public ItemContainer itemContainer = new ItemContainer();
    public static bool progressFlag { get; set; }
    public static bool playerIsInTown { get; set; } = false;
    private MainWindow _mainWindow;
    bool oneTimeMessage = true;

    public StoryProgress(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public string GetFirstText()
    {
        return "You have just returned from a long journey to far realms." +
            "\n\rThe roads are littered with corpses. \n\rDo you have the will to survive the Horrors of the lands?";
    }

    private void NextPanel() // Currently unused
    {
        if (_mainWindow.panelsIndex < _mainWindow.panelsList.Count - 1)
        {
            _mainWindow.panelsList[++_mainWindow.panelsIndex].BringToFront();
        }
    }

    public string GetSecondText()
    {
        return "You ride through the thickening fog, the air heavy with dread." +
            " A chill sweeps over you as a deadly fiend emerges. It blocks your path - deny it its life.";
    }

    public string GetHealingText()
    {
        return "The old man lays his hands on your wounds and whisper magic words. You feel refreshed.";
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
            case 7:
                if (progressFlag == true)
                {
                    if (oneTimeMessage == true)
                    {
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

                break;
            case 8:
                _mainWindow.textBox1.Text = "After killing the demon tree, you venture forth, much further to the north. " +
                    "The high mountains are cold, and you are close to freezing to death.";
                StoryState++;
                break;
            case 9:
                _mainWindow.SetAct2Backgroundimage();
                StoryState++;
                break;
            case 10:
            case 11:
                    Encounter.PerformEncounter(monsterContainer.listOfSnowMonsters1, itemContainer.items1, _mainWindow);
                    StoryState++;
                break;
        }
    }

    private void PlayerIsInTown()
    {
        _mainWindow.textBox1.Clear();
        _mainWindow.panelEncounter.Hide();
        _mainWindow.panelTown.Show();
        playerIsInTown = true;
    }
}
