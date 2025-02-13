using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

public class ModifierProcessor
{
    private PlayerState _playerState;
    private MainWindow _mainWindow;
    private HashSet<string> _appliedModifiers;
    public static int HealPriceReducedModifier { get; set; } = 1;
    public static bool ModifierHasBeenGiven;
    public static int NumberOfModifiersCurrentlyActive { get; set; }

    internal ModifierProcessor(PlayerState playerState, MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
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
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.CritChance += 5;
                _appliedModifiers.Add(command);
                return "Crit chance increased!";
            case "hpup":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.MaxHealth += 10;
                _appliedModifiers.Add(command);
                return "Health increased!";
            case "juggernaut":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.Armor += 1;
                _appliedModifiers.Add(command);
                return "Armor increased!";
            case "quicklearner":
                NumberOfModifiersCurrentlyActive++;
                Player.PriceToLearnTechnique /= 2;
                _appliedModifiers.Add(command);
                return "Costs reduced!";
            case "upgrader":
                NumberOfModifiersCurrentlyActive++;
                Item.CostToUpgrade /= 2;
                _appliedModifiers.Add(command);
                return "Costs reduced!";
            case "healer":
                NumberOfModifiersCurrentlyActive++;
                HealPriceReducedModifier = 2;
                _appliedModifiers.Add(command);
                return "Healing cost reduced!";
            case "vampire":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.Lifesteal += 5;
                _appliedModifiers.Add(command);
                return "Lifesteal increased!";
            case "thief":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.GoldInPocket += 50;
                _appliedModifiers.Add(command);
                return "Starting gold increased!";
            case "rich":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.GoldInPocket += 250;
                _appliedModifiers.Add(command);
                return "Starting gold increased!";
            case "immortal":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.Regeneration += 5;
                _appliedModifiers.Add(command);
                return "Regeneration increased!";
            case "dangerous":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.CritDamage += 20;
                _appliedModifiers.Add(command);
                return "Critical Damage increased!";
            case "smuggler":
                NumberOfModifiersCurrentlyActive++;
                _mainWindow.comboBoxInventory.Items.Add(new Item("Soldier's Dagger", ItemType.WeaponRightHand, 1, 1, 0, 0, 0, 0, 0, 1, 1));
                _appliedModifiers.Add(command);
                return "Dagger aqquired!";
            case "strong":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.Strength += 3;
                _appliedModifiers.Add(command);
                return "Strength increased!";
            case "soldier":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.Damage += 1;
                _appliedModifiers.Add(command);
                return "Damage increased!";
            case "veteran":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.Damage += 2;
                _appliedModifiers.Add(command);
                return "Damage increased!";
            case "quickreflexes":
                NumberOfModifiersCurrentlyActive++;
                _playerState.Player.DodgeChance += 3;
                _appliedModifiers.Add(command);
                return "Dodge chance increased!";
            case "improvedsmithing":
                NumberOfModifiersCurrentlyActive++;
                Item.SmithUpgradeMultiplication++;
                _appliedModifiers.Add(command);
                return "Smithing improved!";
            case "cheappirate":
                NumberOfModifiersCurrentlyActive++;
                ReforgeItemStat.PriceToReforgeFrog /= 2;
                _appliedModifiers.Add(command);
                return "Reforge costs reduced!";
            case "cheapsmith":
                NumberOfModifiersCurrentlyActive++;
                Item.CostToUpgrade -= 10;
                _appliedModifiers.Add(command);
                return "Smithing cost reduced!";
            case "friendlypirate":
                NumberOfModifiersCurrentlyActive++;
                ReforgeItemStat.ReforgeModifier += 0.15;
                _appliedModifiers.Add(command);
                return "Reforging upgraded!";

            // Debugging modes TODO scramble these
            case "presentation32":
                _playerState.Player.Damage += 15;
                _playerState.Player.DodgeChance += 60;
                _playerState.Player.GoldInPocket += 50;
                _playerState.Player.Lifesteal += 50;
                _appliedModifiers.Add(command);
                return "Presentation mode enabled.";
            case "debug32":
                _playerState.Player.Damage += 10;
                _playerState.Player.DodgeChance += 10;
                _playerState.Player.GoldInPocket += 9999;
                _playerState.Player.Lifesteal += 150;
                _playerState.Player.Armor += 25;
                _appliedModifiers.Add(command);
                return "Debugging mode enabled.";
            //case "guard32":
            //    _playerState.Player.techniqueGuardIsLearned = true;
            //    _mainWindow.buttonGuard.Show();
            //    _appliedModifiers.Add(command);
            //    return "Guard attack enabled.";
            //case "delete32":
            //    _playerState.Player.Armor += 100;
            //    return "armor armor enabled.";

            default:
                return "Unknown modifier";
        }
    }

    public static string GetRandomModifier()
    {
        if (ModifierHasBeenGiven) { return "You already have been given the Modifier for this run"; }

        // List of valid modifiers excluding "presentation", "debug", and any other debug-related commands.
        List<string> validModifiers = new List<string>
    {
        "crit", "hpup", "juggernaut", "quicklearner", "upgrader", "healer", "vampire",
        "thief", "rich", "immortal", "dangerous", "smuggler", "strong", "soldier",
        "veteran", "quickreflexes", "improvedsmithing", "cheappirate", "cheapsmith",
        "friendlypirate"
    };

        ModifierHasBeenGiven = true;

        // If no valid modifiers are found, return a default message
        if (validModifiers.Count == 0)
            return "No valid modifiers found.";

        // Get a random index from the available modifiers
        Random random = new Random();
        int randomIndex = random.Next(validModifiers.Count);

        // Return the randomly selected modifier
        return validModifiers[randomIndex];
    }





}
