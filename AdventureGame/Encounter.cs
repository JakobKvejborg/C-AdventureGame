using Accessibility;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

internal static class Encounter
{
    public static Monster Monster { get; set; } // Stores the monster encountered
    public static Item ItemDroppedFromMonster { get; set; } // Stores the randomly found item
    private static readonly Random _randomMonster = new Random();
    private static readonly Random _randomItem = new Random();
    private static readonly Random _randomDodge = new Random();
    private static readonly Random _randomCrit = new Random();
    public static List<Item>? EncounteredMonsterItems; // saves the list of items from the parameter til at property
    public static event EventHandler? EncounterCompleted;
    public static MusicAndSound sounds = new MusicAndSound();
    public static bool PlayerDodgedFlag;
    public static int TotalNumberOfMonstersDefeated;

    public static void PerformEncounter(List<Monster> listOfMonsters, List<Item> listOfItems, MainWindow mainWindow)
    {
        ResetDroppedItem(); // Resets the item found from monster, in case it wasn't looted
        mainWindow.pictureBoxLoot.Hide();
        // Disables encounters while in combat
        StoryProgress.playerIsInTown = false;
        StoryProgress.progressFlag = false;

        // Prepares the GUI
        mainWindow.textBoxEncounter.Clear();
        mainWindow.panelMonster.Show();

        EncounteredMonsterItems = listOfItems; // saves the list of items from the parameter til at property

        // Finds a random monster from the list of monsters to fight against, and stores it in the Monster property
        Monster = GetRandomMonster(listOfMonsters);
        mainWindow.SetEncounteredMonsterLabels(Monster);

    }

    public static Monster GetRandomMonster(List<Monster> listOfMonsters)
    {
        int randomMonsterIndex = _randomMonster.Next(listOfMonsters.Count);
        Monster encounteredMonster = listOfMonsters[randomMonsterIndex];

        Monster monsterClone = encounteredMonster.CloneMonster();

        return monsterClone; // returns the encountered monster
    }

    // Helper method for all attack methods
    public static async Task ExecuteAttack(PlayerState playerState, MainWindow mainWindow, int playerAttackDamageTotal, bool noLifeSteal, bool noCrit)
    {
        PlayerDodgedFlag = false;
        mainWindow.buttonSwiftAttack.Invalidate(); // This is to prevent dodge button to continously be lit up even when the player haven't dodged
        playerState.Player.RoarBuffCountdown -= 1;
        if (playerState.Player.IsRoarActive && playerState.Player.RoarBuffCountdown == 0) // this resets the roar attack when the RoarBuffCountdown is 0, subtracts the roar buff from the player
        {
            playerState.Player.TurnOffRoarBuff(mainWindow);
        }

        // Player lifesteals before crit (we don't want crit+lifesteal)
        if (!noLifeSteal && playerState.Player.Lifesteal > 0)
        {
            int playerLifestealAmount = (playerState.Player.CalculateTotalDamage(playerState) * playerState.Player.Lifesteal) / 100;
            playerState.Player.CurrentHealth += playerLifestealAmount;
            playerState.Player.CurrentHealth = Math.Min(playerState.Player.CurrentHealth, playerState.Player.MaxHealth); // ensures currenthealth doesn't exceed maxhealth
            mainWindow.UpdatePlayerLabels(); // update player health after lifestealing
            if (playerLifestealAmount > 0) // checks if the player actually gains life from the attack
            {
                mainWindow.labelHpPopup.Text = $"+{playerLifestealAmount}";
                mainWindow.PopupFadeLabel(mainWindow.labelHpPopup);
            }
        }

        // Check for critical hit
        bool isCriticalHit = playerState.Player.CritChance >= _randomCrit.Next(1, 101);
        if (isCriticalHit && !noCrit)
        {
            playerAttackDamageTotal = (int)(playerAttackDamageTotal * (playerState.Player.CritDamage / 100.00)); // Increase damage for a critical hit based on the players' critdmg
            sounds.PlayCritSound();
        }

        // Apply damage to the monster
        Monster.CurrentHealth -= playerAttackDamageTotal;
        if (Monster.CurrentHealth < 0)
        {
            Monster.CurrentHealth = 0;
        }

        // Update the UI
        mainWindow.UpdateMonsterHealthLabels(Monster);
        AttackText(playerState, mainWindow, playerAttackDamageTotal); // Show attack text

        // Check if the monster is still alive
        if (Monster.CurrentHealth > 0)
        {
            await Task.Delay(200);
            MonsterAttacks(playerState, mainWindow); // Monster attacks back if still alive
        }
        else
        {
            CheckIfMonsterIsDefeated(playerState, mainWindow);
        }
    }


    // This method is called by MainWindow every time the player attacks
    public static async void MonsterAttacks(PlayerState playerState, MainWindow mainWindow)
    {
        if (playerState.Player.CurrentHealth > 0 && Monster != null) // checks if player is dead
        {
            // Player dodge
            int dodgeChanceRoll = _randomDodge.Next(1, 101);
            if (dodgeChanceRoll <= playerState.Player.DodgeChance)
            {
                mainWindow.textBoxEncounter.AppendText("\n\rYou dodged the horror's attack!");
                PlayerDodgedFlag = true; // This is used for a special Swift attack
                mainWindow.buttonSwiftAttack.Invalidate(); // Repaints the button to show the player dodged
                sounds.PlayDodgeSound();
                return; // Exit the method if the player dodges
            }
            // Stores the monsters damage dealt in a local variable to avoid the damage being calculated twice
            int monsterDamageDealt = Monster.CalculateMonsterDamage(Monster);
            int armorBlocked = Math.Min(playerState.Player.Armor, monsterDamageDealt); // Armor can't block more than damage dealt
            int damageTaken = Math.Max(monsterDamageDealt - armorBlocked, 0); // ensures the damage isn't negative

            playerState.Player.CurrentHealth -= damageTaken;
            playerState.Player.CurrentHealth = Math.Max(playerState.Player.CurrentHealth, 0);
            mainWindow.UpdatePlayerLabels();
            mainWindow.textBoxEncounter.AppendText($"The horror attacks you back and deals {monsterDamageDealt} damage.");
        }
        // Check if the player is defeated
        await mainWindow.CheckIfPlayerIsDefeated();
    }

    private static void PlayerRegensHealth(PlayerState playerState)
    {
        if (playerState.Player.CurrentHealth >= playerState.Player.MaxHealth)
        {
            return;
        }
        int regeneration = playerState.Player.Regeneration;
        playerState.Player.CurrentHealth = Math.Min(playerState.Player.CurrentHealth + regeneration, playerState.Player.MaxHealth);

    }

    // This method is called by MainWindow when the player attacks
    public static void CheckIfMonsterIsDefeated(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster == null) { return; }

        if (Monster.CurrentHealth <= 0)
        {
            playerState.Player.ResetRoarBuff(mainWindow); // this resets the roar attack, subtracts the roar buff from the player
            playerState.Player.ResetGuardBuff(); // this subtracts the guard armor buff from the player

            PlayerDodgedFlag = false;
            mainWindow.buttonSwiftAttack.Invalidate();
            mainWindow.textBoxEncounter.AppendText($"\n\rYou have defeated the horror. You gain {Monster.MonsterExperience}xp. ");
            mainWindow.pictureBoxMonster1.Image = null;
            mainWindow.panelMonster.Hide(); // Hides the monster once it's defeated
            PlayerGetsExperiencePoints(playerState, mainWindow);
            PlayerGetsGoldFromMonster(playerState, mainWindow);
            GenerateItemFoundOnMonster(playerState, mainWindow); // This creates the item found on the monster
            TotalNumberOfMonstersDefeated++; // Keeps track of how many monsters the player has slayed
            StoryProgress.progressFlag = true;

            if (playerState.Player.Regeneration > 0)
            {  // The player regens health after each battle
                PlayerRegensHealth(playerState);
            }
            if (StoryProgress.TutorialIsOver)
            {  // Shows the return to town button if the tutorial is over
                mainWindow.buttonReturnToTown.Show();
            }
            // resets the monster object
            Monster.CurrentHealth = Monster.MaxHealth;
            Monster = null;
            EncounterCompleted?.Invoke(null, EventArgs.Empty); // this is used for bosses
            mainWindow.UpdatePlayerLabels();
        }
    }

    public static void GenerateItemFoundOnMonster(PlayerState playerState, MainWindow mainWindow)
    {
        GetDragonEgg(playerState, mainWindow); // Gives the player a dragon egg if a specific dragon was killed.
        GetFrozenLily(playerState, mainWindow);

        //Get a random item from the list
        int randomItemIndex = _randomItem.Next(EncounteredMonsterItems.Count);
        Item foundItem = EncounteredMonsterItems[randomItemIndex];

        if (Monster == null || foundItem == null)
        {
            return;
        }

        ItemDroppedFromMonster = foundItem.CloneItem(); // This stores the item found in a property on class level
        if (ItemDroppedFromMonster != null)
        {
            mainWindow.pictureBoxLoot.Show();
        }

    }


    // This method is called fromm mainWindow when the loot is clicked
    public static void ItemIsLootetFromMonster(PlayerState playerState, MainWindow mainWindow)
    {
        if (ItemDroppedFromMonster != null)
        {
            // Tell the player which item has been found
            mainWindow.textBoxEncounter.AppendText($"\r\nYou find an item on the horror's corpse: {ItemDroppedFromMonster.Name}.");
            mainWindow.comboBoxInventory.Items.Add(ItemDroppedFromMonster); // the combobox holds the player inventory, not the player
            mainWindow.comboBoxInventory.SelectedItem = ItemDroppedFromMonster;
        }
    }

    private static void PlayerGetsGoldFromMonster(PlayerState playerState, MainWindow mainWindow)
    {
        int goldDropped = Monster.MonsterGold;
        if (goldDropped > 0)
        {
            playerState.Player.GoldInPocket += goldDropped * playerState.Player.GoldFind;
            mainWindow.labelGoldInPocket.Text = $"{playerState.Player.GoldInPocket.ToString()}";
            mainWindow.PopupFadeLabel(mainWindow.labelGoldPopup);
            mainWindow.labelGoldPopup.Text = $"+{goldDropped}G";
            goldDropped = 0;
            sounds.PlayCoinSound();
        }
    }

    private static void PlayerGetsExperiencePoints(PlayerState playerState, MainWindow mainWindow)
    {
        // The player gets experience based on the monster
        playerState.Player.Experience += Monster.MonsterExperience;
        playerState.Player.LevelUp(playerState);
        mainWindow.UpdatePlayerLabels(); // This also checks if player is dead
    }

    public static void ResetDroppedItem()
    {
        ItemDroppedFromMonster = null;
    }

    // Helper method for some UI text, depending on which monster type is encountered
    private static void AttackText(PlayerState playerState, MainWindow mainWindow, int playerAttackDamageTotal)
    {
        if (Monster.Name == "Aldrus Thornfell" || Monster.Name == "Wintermaw" || Monster.Name == "The Devouring Abyss" || Monster.Name == "The Frostfallen King") // add alls boss names
        {
            mainWindow.textBoxEncounter.AppendText($"You attack {Monster.Name}, and deal {playerAttackDamageTotal} damage. \r\n");
        }
        else
        {
            mainWindow.textBoxEncounter.AppendText($"You attack the {Monster.Name}, and deal {playerAttackDamageTotal} damage. \r\n");
        }
    }

    public static void DisplayInitialEncounterText(Monster monster, MainWindow mainWindow)
    {
        switch (monster.Name)
        {
            case "Watchers":
                mainWindow.textBoxEncounter.Text = $"You have encountered some {monster.Name}! Kill them.";
                break;
            case "Aldrus Thornfell":
            case "Wintermaw":
            case "The Devouring Abyss":
                mainWindow.textBoxEncounter.Text = $"You have awakened {monster.Name}! Your end is near.";
                break;
            case "The Frostfallen King":
                mainWindow.textBoxEncounter.Text = $"You have shattered the ice tomb of {monster.Name}! A colossal figure unlike anything you've ever seen before rises from its crystalized prison.";
                break;
            case "Ultimate Darkness":
                mainWindow.textBoxEncounter.Text = $"The Hero now faces the {monster.Name} - a final challenge.";
                break;
            case "Awoken Horror":
                mainWindow.textBoxEncounter.Text = $"You stand before the {monster.Name} itself. This is where you die.";
                break;
            default:
                mainWindow.textBoxEncounter.Text = $"You have encountered a {monster.Name}! Kill it.";
                break;
        }
    }

    private static void GetDragonEgg(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster.Name == "Egg-Watcher Dragon")
        {
            playerState.Player.NumberOfDragonEggsInInventory++;
            mainWindow.labelDragonEggs.Text = $"{playerState.Player.NumberOfDragonEggsInInventory}x";
            mainWindow.pictureBoxDragonEggs.Show();
            mainWindow.labelDragonEggs.Show();
        }
    }

    private static void GetFrozenLily(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster.Name == "The Frostfallen King")
        {
            mainWindow.pictureBoxFrozenLily.Show();
            Player.HasFrozenLily = true;
            mainWindow.textBoxEncounter.AppendText("\r\nInside the King's Tomb, you find a rare frozen lily.");
        }
    }

}


