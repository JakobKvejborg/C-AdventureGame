using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

internal class StoryProgress
{

    public int StoryState;
    public MonsterContainer monsterContainer = new MonsterContainer();
    public ItemContainer itemContainer = new ItemContainer();
    
    public static bool progressFlag { get; set; }

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

    public void ProgressStory(TextBox textBox1, Panel panelMonster)
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
                textBox1.Clear();
                panelMonster.Visible = true;
                Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1);
                textBox1.AppendText("");
                StoryState++;
                break;
            case 3:
                if (progressFlag == true)
                {
                    progressFlag = false;
                    textBox1.Clear();
                    MainWindow.panelMonster.Visible = true;
                    Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1);
                    StoryState++;
                }
                break;
            case 4:
                if (progressFlag == true)
                {
                    progressFlag = false;
                    textBox1.Clear();
                    MainWindow.panelMonster.Visible = true;
                    Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items1);
                    StoryState++;
                }
                break;
        }
    }
}
