using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

internal class TechniquesTrainer
{
    public PlayerState _playerState;
    public StoryProgress _storyProgress;
    private MainWindow _mainWindow;
    public MusicAndSound _sounds;

    internal TechniquesTrainer(PlayerState playerState, StoryProgress storyProgress, MainWindow mainWindow, MusicAndSound sounds)
    {
        this._playerState = playerState;
        this._storyProgress = storyProgress;
        _mainWindow = mainWindow;
        _sounds = sounds;
    }

    public async Task LearnTechniqueAsync()
    {
        if (StoryProgress.playerIsInTown && !_storyProgress.Act1BossDefeatedFlag && _storyProgress.Act1ArtsTeacherIsAvailable)
        {
            if (_playerState.Player.GoldInPocket >= Player.PriceToLearnTechnique)
            {

                switch (_playerState.Player.AdvanceTechnique)
                {
                    case 0:
                        _playerState.Player.TechniqueBloodLustIsLearned = true;
                        _mainWindow.txtBox_Town.Text = "After many hours of training you have learned the Bloodlust technique. Use it with care - it deals huge damage, but comes at the cost of blood.";
                        _mainWindow.buttonBloodLust.Show();
                        break;
                    case 1:
                        _playerState.Player.TechniqueSwiftIsLearned = true;
                        _mainWindow.txtBox_Town.Text = "After many hours of training you have learned the Swift technique. Unleash a powerful strike after dodging an attack.";
                        _mainWindow.buttonSwiftAttack.Show();
                        break;
                    case 2:
                        _playerState.Player.TechniqueRoarIsLearned = true;
                        _mainWindow.txtBox_Town.Text = "After many hours of training you have learned the Roar technique. A battle cry that boosts your reflexes for a period.";
                        _mainWindow.buttonRoarAttack.Show();
                        break;
                    case 3:
                        _playerState.Player.TechniqueDivineIsLearned = true;
                        _mainWindow.txtBox_Town.Text = "After many hours of training you have learned the Divine technique - a holy attack dealing damage that increases with your missing health.";
                        _mainWindow.buttonDivine.Show();
                        break;
                    case 4:
                        _playerState.Player.TechniqueGuardIsLearned = true;
                        _mainWindow.txtBox_Town.Text = "The once mighty warrior teaches you the Guard technique - a way to boost your defenses. Once per battle, when near death, use this stance to stay alive.";
                        _mainWindow.buttonGuard.Show();
                        break;
                    default:
                        _mainWindow.txtBox_Town.Text = "Sorry, I've taught you everything I know.";
                        _sounds.PlayAct1ArtsTeacherNo();
                        return;
                }

                _playerState.Player.GoldInPocket -= Player.PriceToLearnTechnique;
                _playerState.Player.AdvanceTechnique += 1;
                Player.PriceToLearnTechnique *= 3;
                _mainWindow.buttonLearnTechnique.Text = $"Learn {Player.PriceToLearnTechnique}G";
                _mainWindow.UpdatePlayerLabels();
                _sounds.PlayAct1ArtsTeacher();
                _storyProgress.Act1ArtsTeacherIsAvailable = false;
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
