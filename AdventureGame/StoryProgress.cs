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
        return "Hello, welcome to game";
    }

    public string GetSecondText()
    {
        return "Oh noes, a monster - slay it";
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
                    Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items2);
                    StoryState++;
                }
                break;
            case 4:
                if (progressFlag == true)
                {
                    progressFlag = false;
                    textBox1.Clear();
                    MainWindow.panelMonster.Visible = true;
                    Encounter.PerformEncounter(monsterContainer.listOfMonsters1, itemContainer.items2);
                    StoryState++;
                }
                break;
        }
    }
}
