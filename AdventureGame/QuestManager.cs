using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class QuestManager
{
    private readonly MainWindow _mainWindow;
    private readonly StoryProgress _storyProgress;
    private readonly ImageSetter _imageSetter;
    public bool Act1Quest1BoyFound { get; set; }
    public bool FirstTimeText { get; private set; }
    private MusicAndSound _sounds = new MusicAndSound();
    public bool Act1Quest1EncounterIsActive { get; set; }
    public bool Act1Quest1IsCompleted { get; set; }
    public bool isInsideAct1Quest1Panel { get; set; }

    public QuestManager(MainWindow mainWindow, ImageSetter imageSetter)
    {
        _mainWindow = mainWindow;
        _imageSetter = imageSetter;
        _storyProgress = new StoryProgress(_mainWindow, _sounds);

    }

    public void ContinueAct1Quest1Dialogue()
    {
        if (isInsideAct1Quest1Panel)
        {
            //currentDialogueIndex++;
        }
    }

    // Start Act 1 Quest 1
    public void StartAct1Quest1()
    {
        if (StoryProgress.playerIsInTown && !_storyProgress.Act1BossDefeatedFlag && StoryProgress.WhichActIsThePlayerIn == 1)
        {
            isInsideAct1Quest1Panel = true;
            if (!Act1Quest1BoyFound)
            {
                Act1Quest1EncounterIsActive = true;
                _imageSetter.SetAct1Quest1BackgroundImage();
                _mainWindow.panelAct1Quest1.Show();
                _mainWindow.panelTown.Hide();
                _sounds.PlayAct1WomanCrying();

                if (!FirstTimeText)
                {
                    _mainWindow.textBoxAct1Quest1.Text = "Hey, you! You must help me! I... I’ve lost my little boy. I turned away for a moment, and now he’s gone. I’m so worried—I can’t bear the thought of him out there alone. Please, if you could help me find him, I’d be forever grateful.";
                    FirstTimeText = true;
                }
                else
                {
                    _mainWindow.textBoxAct1Quest1.Text = "Have you found him yet? It’s not safe out there. I hope nothing’s happened to him.";
                }
            }
            else
            {
                CompleteAct1Quest1();
            }
            StoryProgress.playerIsInTown = false;
        }
    }

    public void CompleteAct1Quest1()
    {
        _imageSetter.SetAct1Quest1CompletedBackgroundImage();
        _mainWindow.panelAct1Quest1.Show();
        _mainWindow.panelTown.Hide();
        if (!Act1Quest1IsCompleted)
        {
            _mainWindow.textBoxAct1Quest1.Text = "Thank you so much for returning my boy to me! As a token of my gratitude, here, take this. It belonged to my father. Farewell, hero.\r\n[Father's Helmet added to inventory]";
            _mainWindow.comboBoxInventory.Items.Add(new Item("Father's Helmet", ItemType.Helmet, 0, 0, 1, 1, new Random().Next(1, 6), 1, 0, 0, 4, 5));
            Act1Quest1IsCompleted = true;
        }
        else
        {
            _mainWindow.textBoxAct1Quest1.Text = "Thank you again, hero. Maybe you'll save us all some day.";
        }
    }

    public void ReturnToTownFromAct1Quest1()
    {
        if (isInsideAct1Quest1Panel)
        {
            _mainWindow.panelAct1Quest1.Hide();
            _mainWindow.panelTown.Show();
            isInsideAct1Quest1Panel = false;
            StoryProgress.playerIsInTown = true;
        }
    }

}