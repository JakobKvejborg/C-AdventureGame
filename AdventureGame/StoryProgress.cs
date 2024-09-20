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

    public String GetFirstText()
    {
        return "Hello, welcome to game";
    }

    public String GetSecondText()
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
                textBox1.Text = "case 2";
                panelMonster.Visible = true;
                Encounter.PerformEncounter(textBox1, monsterContainer.listOfMonsters1);
                textBox1.AppendText("");
                StoryState++;
                break;
            case 3:
                if (progressFlag == true)
                {
                    progressFlag = false;
                    textBox1.Clear();
                    MainWindow.panelMonster.Visible = true;
                    Encounter.PerformEncounter(textBox1, monsterContainer.listOfMonsters1);
                    StoryState++;
                }
                break;
            case 4:
                if (progressFlag == true)
                {
                    progressFlag = false;
                    textBox1.Clear();
                    textBox1.Text = "case 4";
                    StoryState++;
                }
                break;
        }
    }
}
