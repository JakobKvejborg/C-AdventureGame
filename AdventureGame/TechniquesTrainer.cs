using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

internal class TechniquesTrainer
{
    public PlayerState playerState;
    public StoryProgress storyProgress;
    private MainWindow _mainWindow;
    public MusicAndSound _sounds;

    internal TechniquesTrainer(PlayerState playerState, StoryProgress storyProgress, MainWindow mainWindow, MusicAndSound sounds)
    {
        this.playerState = playerState;
        this.storyProgress = storyProgress;
        _mainWindow = mainWindow;
        _sounds = sounds;
    }

    public async Task LearnTechniqueAsync()
    {
        if (StoryProgress.playerIsInTown && !storyProgress.Act1BossDefeatedFlag && storyProgress.Act1ArtsTeacherIsAvailable)
        {
            if (playerState.Player.GoldInPocket >= Player.PriceToLearnTechnique)
            {
                playerState.Player.GoldInPocket -= Player.PriceToLearnTechnique;

                switch (playerState.Player.advanceTechnique)
                {
                    case 0:
                        playerState.Player.techniqueBloodLustIsLearned = true;
                        _mainWindow.txtBox_Town.Text = "After many hours of training you have learned the Bloodlust technique. Use it with care.";
                        _mainWindow.buttonBloodLust.Show();
                        break;
                    case 1:
                        playerState.Player.techniqueSwiftIsLearned = true;
                        _mainWindow.txtBox_Town.Text = "After many hours of training you have learned the Swift technique. A way to angle the sword after dodging an attack.";
                        _mainWindow.buttonSwiftAttack.Show();
                        break;
                    case 2:
                        playerState.Player.techniqueRoarIsLearned = true;
                        _mainWindow.txtBox_Town.Text = "After many hours of training you have learned the Roar technique. A battle cry that boosts your stats for a period.";
                        _mainWindow.buttonRoarAttack.Show();
                        break;
                    case 3:
                        playerState.Player.techniqueDivineIsLearned = true;
                        _mainWindow.txtBox_Town.Text = "After many hours of training you have learned the Divine technique - a sacred plea for aid in your most desperate hour.";
                        _mainWindow.buttonDivine.Show();
                        break;
                    case 4:
                        playerState.Player.techniqueGuardIsLearned = true;
                        _mainWindow.txtBox_Town.Text = "The once mighty warrior teaches you the Guard technique - a way to boost your defenses when time is running out.";
                        _mainWindow.buttonGuard.Show();
                        break;
                }

                playerState.Player.advanceTechnique += 1;
                Player.PriceToLearnTechnique *= 3;
                _mainWindow.buttonLearnTechnique.Text = $"Learn {Player.PriceToLearnTechnique}G";
                _mainWindow.UpdatePlayerLabels();
                _sounds.PlayAct1ArtsTeacher();
                storyProgress.Act1ArtsTeacherIsAvailable = false;
                _mainWindow.buttonLearnTechnique.Hide();

                await Task.Delay(7280);
                _mainWindow.pictureBoxAct1ArtsTeacher.Hide();
            }
            else
            {
                _sounds.PlayAct1ArtsTeacherNo();
            }
        }
    }
        }
