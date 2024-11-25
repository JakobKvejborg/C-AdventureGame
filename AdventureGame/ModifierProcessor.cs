using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class ModifierProcessor
{
    private PlayerState _playerState;
    private MainWindow _mainWindow;
    private HashSet<string> _appliedModifiers;

    internal ModifierProcessor(PlayerState playerState)
    {
        _playerState = playerState;
        _appliedModifiers = new HashSet<string>(); // Tracks applied modifiers
    }

    public string ProcessCommand(string command)
    {
        if (string.IsNullOrEmpty(command)) return "Found any modifiers yet?";

        command = command.ToLower(); // This ensures modifiers works even if typed in CAPS

        if (_appliedModifiers.Contains(command)) return "Modifier already applied."; // if the modifier has already been applied, do nothing

        switch (command)
        {
            case "crit":
                _playerState.Player.CritChance += 5;
                _appliedModifiers.Add(command);
                return "Crit chance increased!";
            case "hpup":
                _playerState.Player.MaxHealth += 10;
                _appliedModifiers.Add(command);
                return "Health increased!";
            case "juggernaut":
                _playerState.Player.Armor += 1;
                _appliedModifiers.Add(command);
                return "Armor increased!";
            case "quicklearner":
                Player.PriceToLearnTechnique /= 2;
                _appliedModifiers.Add(command);
                return "Costs reduced!";
            case "upgrader":
                Item.CostToUpgrade /= 2;
                _appliedModifiers.Add(command);
                return "Costs reduced!";
            case "healer":
                Player.priceToHeal = 1;
                _appliedModifiers.Add(command);
                return "Costs reduced!";
            case "vampire":
                _playerState.Player.Lifesteal += 5;
                return "Lifesteal increased!";
            case "rich":
                _playerState.Player.GoldInPocket += 5;
                return "Starting gold increased!";
           
            // Debugging modes
            case "debug":
                _playerState.Player.Damage += 15;
                _playerState.Player.DodgeChance += 60;
                _playerState.Player.GoldInPocket += 50;
                _playerState.Player.Lifesteal += 50;
                return "Debugging mode enabled.";
            default:
                return "Unknown modifier";
        }
    }
}
