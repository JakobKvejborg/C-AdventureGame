using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

    public QuestManager(MainWindow mainWindow, ImageSetter imageSetter)
    {
        _mainWindow = mainWindow;
        _imageSetter = imageSetter;
        _storyProgress = new StoryProgress(_mainWindow);
    }
    public void ContinueAct1Quest1Dialogue()
    {
        //currentDialogueIndex++;
        _mainWindow.ButtonContinue(); // closes the questpanel finally
    }


        // Start Act 1 Quest 1
        public void StartAct1Quest1()
    {
        if (StoryProgress.playerIsInTown && !_storyProgress.Act1BossDefeatedFlag && _storyProgress.WhichActIsThePlayerIn == 1)
        {
            if (!Act1Quest1BoyFound)
            {
                _mainWindow.panelAct1Quest1.Show();
                _imageSetter.SetAct1Quest1BackgroundImage();
                _mainWindow.panelTown.Hide();

                if (!FirstTimeText)
                {
                _mainWindow.textBoxAct1Quest1.Text = "Hey, you! You must help me! I... I’ve lost my little boy. I turned away for a moment, and now he’s gone. I’m so worried—I can’t bear the thought of him out there alone. Please, if you could help me find him, I’d be forever grateful.";
                    FirstTimeText = true;
                } else
                {
                    _mainWindow.textBoxAct1Quest1.Text = "Have you found him yet? It’s not safe out there. I hope nothing’s happened to him.";
                }
            } else
            {
                CompleteAct1Quest1();
            }
        }
    }

    public void CompleteAct1Quest1()
    {
        _imageSetter.SetAct1Quest1CompletedBackgroundImage();
    }

}