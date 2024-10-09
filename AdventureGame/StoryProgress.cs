namespace AdventureGame;

internal class StoryProgress
{

    public int StoryState;
    public MonsterContainer monsterContainer = new MonsterContainer();
    public ItemContainer itemContainer = new ItemContainer();
    public static bool progressFlag { get; set; }
    public static bool townEncountersEnabled { get; set; } = false;
    private MainWindow _mainWindow;

    public StoryProgress(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public string GetFirstText()
    {
        return "You have just returned from a long journey to far realms." +
            "\n\rThe roads are littered with corpses. \n\rDo you have the will to survive the Horrors of the lands?";
    }

    public string GetSecondText()
    {
        return "You ride through the thickening fog, the air heavy with dread." +
            " A chill sweeps over you as a deadly fiend emerges. It blocks your path - deny it its life.";
    }

    public void ProgressStory(TextBox textBox1)
    {
        switch (StoryState)
        {
            case 0:
                textBox1.Clear();
                textBox1.AppendText(GetFirstText());
                StoryState++;
                break;
            case 1:
                textBox1.Clear();
                textBox1.AppendText(GetSecondText());
                StoryState++;
                break;
            case 2:
                Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1, _mainWindow);
                textBox1.AppendText("");
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
                if (progressFlag == true)
                {
                    textBox1.Clear();
                    textBox1.AppendText("You have arrived at a nearly abandoned town. \r\nWhat comes next is up to you.");
                    StoryState++;
                    progressFlag = true;
                }
                break;
            case 6:
                if (progressFlag == true)
                {
                    textBox1.Clear();
                    textBox1.AppendText("While the town isn’t completely deserted, it's very quit. \r\nChoose a path.");
                    _mainWindow.panelTown.Visible = true;
                    townEncountersEnabled = true;
                }
                break;
        }
    }
}
