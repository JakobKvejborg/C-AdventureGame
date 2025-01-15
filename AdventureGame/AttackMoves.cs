using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

internal class AttackMoves
{
    private PlayerState _playerState;
    private MainWindow _mainWindow;
    private MusicAndSound _sounds;
    private Random randomRoar = new Random();

    public AttackMoves(PlayerState playerState, MainWindow mainWindow, MusicAndSound sounds)
    {
        _mainWindow = mainWindow;
        _playerState = playerState;
        _sounds = sounds;
    }

    public async Task NormalAttack()
    {
        if (Encounter.Monster != null && Encounter.Monster.CurrentHealth > 0)
        {
            _sounds.PlayNormalAttackSound();
            int playerAttackDamageTotal = _playerState.Player.CalculateTotalDamage(_playerState);
            await Encounter.ExecuteAttack(_playerState, _mainWindow, playerAttackDamageTotal, noLifeSteal: false, noCrit: false);
        }
    }

    public async Task BloodLustAttack()
    {
        if (Encounter.Monster != null && Encounter.Monster.CurrentHealth > 0)
        {
            _sounds.PlayBloodLustSound();
            int playerAttackDamageTotal = (int)(_playerState.Player.CalculateTotalDamage(_playerState) * 1.6); // 1.6x damage for Blood Lust attack
            int healthCost = (int)(_playerState.Player.MaxHealth * 0.10); // % cost of health
            _playerState.Player.CurrentHealth -= healthCost;
            _playerState.Player.CurrentHealth = Math.Max(_playerState.Player.CurrentHealth, 0); // Prevent negative health
            _mainWindow.UpdatePlayerLabels(); // Update player health bar
            await Encounter.ExecuteAttack(_playerState, _mainWindow, playerAttackDamageTotal, noLifeSteal: false, noCrit: false);
        }
    }

    public async Task SwiftAttack()
    {
        if (Encounter.Monster != null && Encounter.Monster.CurrentHealth > 0)
        {
            _sounds.PlaySwiftAttackSound();
            int playerAttackDamageTotal = _playerState.Player.CalculateTotalDamage(_playerState);
            if (!Encounter.PlayerDodgedFlag)
            {
                playerAttackDamageTotal = (int)(playerAttackDamageTotal * 0.4);
            }
            else
            {
                playerAttackDamageTotal = (int)(playerAttackDamageTotal * 1.4);
            }
            Encounter.PlayerDodgedFlag = false;
            await Encounter.ExecuteAttack(_playerState, _mainWindow, playerAttackDamageTotal, noLifeSteal: false, noCrit: false);
        }
    }

    public async Task RoarAttack()
    {
        _playerState.Player.RoarBuffCountdown = randomRoar.Next(3, 7); // Number of "rounds" the roar buff is active
        if (Encounter.Monster != null && Encounter.Monster.CurrentHealth > 0)
        {
            _sounds.PlayRoarAttackSound();
            int playerAttackDamageTotal = _playerState.Player.CalculateTotalDamage(_playerState);
            playerAttackDamageTotal = (int)(playerAttackDamageTotal * 0.1);

            if (!_playerState.Player.IsRoarActive)
            {
                _playerState.Player.TurnOnRoarBuff(_mainWindow);
            }

            await Encounter.ExecuteAttack(_playerState, _mainWindow, playerAttackDamageTotal, noLifeSteal: true, noCrit: true);
        }
    }

    public async Task DivineAttack()
    {
        if (Encounter.Monster != null && Encounter.Monster.CurrentHealth > 0)
        {
            _sounds.PlayDivineAttackSound();
            double missingHealthPercentage = (double)(_playerState.Player.MaxHealth - _playerState.Player.CurrentHealth) / _playerState.Player.MaxHealth;
            double damageMultiplier = 0.2 + (2.5 - 0.2) * Math.Pow(missingHealthPercentage, 1.6);
            int playerAttackDamageTotal = _playerState.Player.CalculateTotalDamage(_playerState);
            playerAttackDamageTotal = (int)(playerAttackDamageTotal * damageMultiplier);

            await Encounter.ExecuteAttack(_playerState, _mainWindow, playerAttackDamageTotal, noLifeSteal: true, noCrit: true);
        }
    }

    public void GuardAttack()
    {
        if (Encounter.Monster != null && Encounter.Monster.CurrentHealth > 0)
        {
            double percentPlayerHealth = _playerState.Player.MaxHealth * 0.15;

            // Guard clause (the method does nothing if the buff is already active or the player has too much health)
            if (_playerState.Player.GuardBuffIsActive || _playerState.Player.CurrentHealth > percentPlayerHealth) { return; }

            int guardHealPlayer = _playerState.Player.MaxHealth / 10;
            _playerState.Player.GuardBuffArmor = (int)(_playerState.Player.Armor * 0.10); // The buff is % of the players' armor

            _sounds.PlayGuardSound();
            _playerState.Player.CurrentHealth = Math.Min(_playerState.Player.MaxHealth, _playerState.Player.CurrentHealth + guardHealPlayer); // ensures maxhealth isn't exceeded
            _playerState.Player.Armor += _playerState.Player.GuardBuffArmor;
            _mainWindow.UpdatePlayerLabels(); // updates labels after the buff is given
            _mainWindow.textBox1.Text = "You stand your ground, boosting your defenses!";
            _playerState.Player.GuardBuffIsActive = true;
        }
    }

}