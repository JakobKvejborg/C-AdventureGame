using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
    public bool IsInsideQuestPanel { get; set; }
    public bool IsAct3Q1Availiable { get; set; }

    internal QuestManager(MainWindow mainWindow, ImageSetter imageSetter, StoryProgress storyProgress)
    {
        _mainWindow = mainWindow;
        _imageSetter = imageSetter;
        _storyProgress = storyProgress;

    }

    public void ContinueAct1Quest1Dialogue()
    {
        if (IsInsideQuestPanel)
        {
            //currentDialogueIndex++;
        }
    }
    public void ReturnToTownFromQuest()
    {
        if (!IsInsideQuestPanel) // The player can only return to town from the quest panel if the player is inside a quest panel
        {
            return;
        }
        _mainWindow.panelAct4Quest1.Hide();
        _mainWindow.panelAct1Quest1.Hide();
        _mainWindow.panelAct3Q1.Hide();
        _mainWindow.panelAct2Q1.Hide();
        _mainWindow.panelTown.Show();
        _mainWindow.panelReforgeItemFrog.Hide();
        IsInsideQuestPanel = false;
        StoryProgress.playerIsInTown = true;
        _mainWindow.IsButtonContinueEnabled = true;
    }

    // Start Act 1 Quest 1
    public void StartAct1Quest1()
    {
        if (StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 1)
        {
            _mainWindow.IsButtonContinueEnabled = false;
            IsInsideQuestPanel = true;
            if (!Act1Quest1BoyFound)
            {
                Act1Quest1EncounterIsActive = true;
                _mainWindow.panelAct1Quest1.Show();
                _mainWindow.panelTown.Hide();
                _sounds.PlayAct1WomanCrying();

                if (!FirstTimeText)
                {
                    _mainWindow.textBoxAct1Quest1.Text = "Hey, you! You must help me! I... I’ve lost my little boy. I turned away for a moment, and now he’s gone. I’m so worried — I can’t bear the thought of him being out there alone. Please, if you could help me find him, I’d be forever grateful.";
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
        _mainWindow.IsButtonContinueEnabled = false;
        _imageSetter.SetAct1Quest1CompletedBackgroundImage();
        _mainWindow.panelTown.Hide();
        _mainWindow.panelAct1Quest1.Show();
        if (!Act1Quest1IsCompleted)
        {
            _mainWindow.textBoxAct1Quest1.Text = "Thank you so much for returning my boy to me! As a token of my gratitude, here, take this. It belonged to my father. Farewell, Hero.\r\n[Father's Helmet added to inventory]";
            _mainWindow.comboBoxInventory.Items.Add(new Item("Father's Helmet", ItemType.Helmet, 0, 0, 1, 1, new Random().Next(1, 6), 1, 0, 0, 0, 4, 5));
            Act1Quest1IsCompleted = true;
        }
        else
        {
            _mainWindow.textBoxAct1Quest1.Text = "Thank you again, Hero. Maybe you'll save us all some day.";
        }
    }

    // Start Act 4 Quest 1
    public void StartAct4Quest1()
    {
        if (StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 4)
        {
            IsInsideQuestPanel = true;
            _imageSetter.SetAct4Quest1BackgroundImage();
            _mainWindow.panelTown.Hide();
            _mainWindow.panelAct4Quest1.Show();
            _mainWindow.textBoxAct4Quest1.Text = "\"You've fought the Dragons bravely, but beyond this valley awaits a darkness that defies comprehension. I can take you there — but please be careful.\"";
            _sounds.PlayAct4Q1Voice();
            StoryProgress.playerIsInTown = false;
        }
    }

    // Start Act 3 Quest 1
    public void StartAct3Quest1()
    {
        if (StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 3 && StoryProgress.PlayerHasEnteredAct4 == true)
        {
            _sounds.PlayAct3Frog();
            IsInsideQuestPanel = true;
            _mainWindow.panelTown.Hide();
            _mainWindow.panelAct3Q1.Show();
            StoryProgress.playerIsInTown = false;
            _mainWindow.textBoxAct3Q1.Text = "You spot a small island in the distance and steer toward it. Sitting by the shore is a frog-like man. \"I'm pretty good with items, you know,\" he says.";
        }
    }

    public void PlayerGivesFrozenLilyToFrog()
    {
        _mainWindow.textBoxAct3Q1.Text = "\"What's that I see? You’ve got somethin’ special there, don’t ya? A lily, frozen in time. Give it to me, and I promise to make your equipment even stronger, sharper, deadlier.\"";
        Player.HasFrozenLily = false;
        _imageSetter.SetAct3Q1FrogGotLilyImage();
        ReforgeItemStat.LilyReforgeModifer = 0.20;
        _mainWindow.pictureBoxFrozenLily.Hide();
    }

    public void StartAct5Quest1()
    {
        if (StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 5 && _storyProgress.Act5BossDefeatedFlag)
        {
            UltimateDarknessFinalBossEncounter();
        }
    }

    public void StartAct2Quest1()
    {
        if (StoryProgress.playerIsInTown && StoryProgress.WhichActIsThePlayerIn == 2 && StoryProgress.PlayerHasEnteredAct4 == true)
        {
            IsInsideQuestPanel = true;
            _imageSetter.SetAct2IcyCaveImage();
            _mainWindow.panelTown.Hide();
            _mainWindow.panelAct2Q1.Show();
            StoryProgress.playerIsInTown = false;

            if (!_storyProgress.Act2OptionalBossDefeatedFlag)
            {
                _mainWindow.textBoxAct2Q1.Text = "After a long search in the cold mountains, you stand before the frozen cave you have been seeking. The entrance is blocked by a thick layer of ice. Do you truly dare shatter this icy barrier and unleash what lies within?";
            }
            else
            {
                _mainWindow.textBoxAct2Q1.Text = "The tomb of the King has been magically encased in ice once more. Maybe it's best left this way.";
            }
        }
    }

    public void FrozenKingEncounter()
    {
        if (StoryProgress.WhichActIsThePlayerIn == 2 && StoryProgress.PlayerHasEnteredAct4 == true && !_storyProgress.Act2OptionalBossDefeatedFlag)
        {
            IsInsideQuestPanel = false;
            _mainWindow.panelAct2Q1.Hide();
            _mainWindow.IsButtonContinueEnabled = false;
            _mainWindow.panelEncounter.Show();
            _storyProgress.StoryState = 110;
            _storyProgress.ProgressStory();
            Encounter.EncounterCompleted += OnAct2OptionalBossDefeated;
        }
    }

    public void UltimateDarknessFinalBossEncounter()
    {
        if (StoryProgress.WhichActIsThePlayerIn == 5 && !_storyProgress.Act5UltimatedarknessBossDefeatedFlag && _storyProgress.SophiaIsAlive && _storyProgress.Act2OptionalBossDefeatedFlag && !_storyProgress.Act5UltimatedarknessBossDefeatedFlag)
        {
            IsInsideQuestPanel = false;
            _mainWindow.IsButtonContinueEnabled = false;
            _mainWindow.panelEncounter.Show();
            _storyProgress.StoryState = 111;
            _storyProgress.ProgressStory();
            Encounter.EncounterCompleted += OnAct5OptionalBossDefeated;
        }
    }

    private void OnAct2OptionalBossDefeated(object sender, EventArgs e)
    {
        _storyProgress.Act3BossDefeatedFlag = true;
        _mainWindow.IsButtonContinueEnabled = true;
        Encounter.EncounterCompleted -= OnAct2OptionalBossDefeated; // Unsubscribe from the event to avoid multiple invocations
    }

    private void OnAct5OptionalBossDefeated(object sender, EventArgs e)
    {
        _storyProgress.Act3BossDefeatedFlag = true;
        _mainWindow.IsButtonContinueEnabled = true;
        Encounter.EncounterCompleted -= OnAct5OptionalBossDefeated; // Unsubscribe from the event to avoid multiple invocations
    }

}