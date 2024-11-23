using Accessibility;
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
    public static Monster Monster { get; private set; } // Stores the monster encountered
    public static Item ItemDroppedFromMonster { get; set; } // Stores the randomly found item
    private static readonly Random _randomMonster = new Random();
    private static readonly Random _randomItem = new Random();
    private static readonly Random _randomDodge = new Random();
    private static readonly Random _randomCrit = new Random();
    public static List<Item>? EncounteredMonsterItems; // saves the list of items from the parameter til at property
    public static event EventHandler? EncounterCompleted;
    public static MusicAndSound sounds = new MusicAndSound();
    public static bool PlayerDodgedFlag;
    private static int RoarBuffDodgeAndCrit = 10;
    private static bool isRoarActive = false;


    public static void PerformEncounter(List<Monster> listOfMonsters, List<Item> listOfItems, MainWindow mainWindow)
    {
        ResetDroppedItem(); // Resets the item found from monster, in case it wasn't looted
        mainWindow.pictureBoxLoot.Hide();
        // Disables encounters while in combat
        StoryProgress.playerIsInTown = false;
        StoryProgress.progressFlag = false;

        // Prepares the GUI
        mainWindow.textBox1.Clear();
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

    public static async void BloodLustAttack(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster != null && Monster.CurrentHealth > 0)
        {
            int playerAttackDamageTotal = (int)(playerState.Player.CalculateTotalDamage(playerState) * 1.5); // 1.5x damage for Blood Lust attack
            // Cost the player % of max health
            int healthCost = (int)(playerState.Player.MaxHealth * 0.10); // % cost of health
            playerState.Player.CurrentHealth -= healthCost;
            playerState.Player.CurrentHealth = Math.Max(playerState.Player.CurrentHealth, 0); // Prevent negative health
            mainWindow.UpdatePlayerLabels(); // updates the player health bar
            await ExecuteAttack(playerState, mainWindow, playerAttackDamageTotal, isRoarAttack: false);
        }
    }

    public static async void NormalAttack(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster != null && Monster.CurrentHealth > 0)
        {
            int playerAttackDamageTotal = playerState.Player.CalculateTotalDamage(playerState);
            await ExecuteAttack(playerState, mainWindow, playerAttackDamageTotal, isRoarAttack: false);
        }
    }
    public static async void DodgeJabAttack(PlayerState playerState, MainWindow mainWindow)
    {
        int playerAttackDamageTotal = playerState.Player.CalculateTotalDamage(playerState);
        if (Monster != null && Monster.CurrentHealth > 0)
        {
            if (!PlayerDodgedFlag)
            {
                playerAttackDamageTotal = (int)(playerAttackDamageTotal * 0.4);
            }
            else
            {
                playerAttackDamageTotal = (int)(playerAttackDamageTotal * 1.4);
            }
            PlayerDodgedFlag = false;
            await ExecuteAttack(playerState, mainWindow, playerAttackDamageTotal, isRoarAttack: false);
        }
    }
    public static async void RoarAttack(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster != null && Monster.CurrentHealth > 0)
        {
            int playerAttackDamageTotal = playerState.Player.CalculateTotalDamage(playerState);
            playerAttackDamageTotal = (int)(playerAttackDamageTotal * 0.2);

            if (!isRoarActive)
            {
                playerState.Player.DodgeChance += RoarBuffDodgeAndCrit; // + 10
                playerState.Player.CritChance += RoarBuffDodgeAndCrit;
                isRoarActive = true;
            }

            await ExecuteAttack(playerState, mainWindow, playerAttackDamageTotal, isRoarAttack: true);
        }
    }

    // Helper method for all attack methods
    private static async Task ExecuteAttack(PlayerState playerState, MainWindow mainWindow, int playerAttackDamageTotal, bool isRoarAttack)
    {
        // Player lifesteals before crit (we don't want critlifesteal)
        if (!isRoarAttack && playerState.Player.Lifesteal > 0)
        {
            int playerLifeStealAmount = (playerAttackDamageTotal * playerState.Player.Lifesteal) / 100;
            playerState.Player.CurrentHealth += playerLifeStealAmount;
            playerState.Player.CurrentHealth = Math.Min(playerState.Player.CurrentHealth, playerState.Player.MaxHealth); // ensures currenthealth doesn't exceed maxhealth
            mainWindow.UpdatePlayerLabels(); // update player health after lifestealing
            if (playerLifeStealAmount > 0) // checks if the player actually gains life from the attack
            {
                mainWindow.labelHpPopup.Text = $"+{playerLifeStealAmount}";
                mainWindow.PopupFadeLabel(mainWindow.labelHpPopup);
            }
        }

        // Check for critical hit
        bool isCriticalHit = playerState.Player.CritChance >= _randomCrit.Next(1, 101);
        if (isCriticalHit)
        {
            playerAttackDamageTotal = (int)(playerAttackDamageTotal * 1.5); // Increase damage for a critical hit
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
            MonsterIsDefeated(playerState, mainWindow);
        }
    }

    // Helper method for some UI text, depending on which monster type is encountered
    private static void AttackText(PlayerState playerState, MainWindow mainWindow, int playerAttackDamageTotal)
    {
        if (Monster.Name == "Aldrus Thornfell" || Monster.Name == "Wintermaw" || Monster.Name == "The Devouring Abyss") // add alls boss names
        {
            mainWindow.textBox1.AppendText($"You attack {Monster.Name}, and deal {playerAttackDamageTotal} damage. \r\n");
        }
        else
        {
            mainWindow.textBox1.AppendText($"You attack the {Monster.Name}, and deal {playerAttackDamageTotal} damage. \r\n");
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
                mainWindow.textBox1.AppendText("\n\rYou dodged the horror's attack!");
                PlayerDodgedFlag = true; // This is used for a special Dodge Jab attack
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
            mainWindow.textBox1.AppendText($"The horror attacks you back and deals {monsterDamageDealt} damage.");

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
    public static void MonsterIsDefeated(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster == null)
        {
            return;
        }
        if (Monster.CurrentHealth <= 0)
        {
            if (isRoarActive) // this resets the roar attack
            {
                playerState.Player.DodgeChance -= RoarBuffDodgeAndCrit;
                playerState.Player.CritChance -= RoarBuffDodgeAndCrit;
                isRoarActive = false;
            }

            PlayerDodgedFlag = false;
            mainWindow.textBox1.AppendText($"\n\rYou have defeated the horror. You gain {Monster.MonsterExperience}xp. ");
            mainWindow.pictureBoxMonster1.Image = null;
            mainWindow.panelMonster.Hide(); // Hides the monster once it's defeated
            PlayerGetsExperiencePoints(playerState, mainWindow);
            PlayerGetsGoldFromMonster(playerState, mainWindow);
            GenerateItemFoundOnMonster(playerState, mainWindow); // This creates the item found on the monster
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
            mainWindow.textBox1.AppendText($"\r\nYou find an item on the horror's corpse: {ItemDroppedFromMonster.Name}.");
            mainWindow.comboBoxInventory.Items.Add(ItemDroppedFromMonster); // the combobox holds the player inventory, not the player
            mainWindow.comboBoxInventory.SelectedItem = ItemDroppedFromMonster;
        }
    }

    private static void PlayerGetsGoldFromMonster(PlayerState playerState, MainWindow mainWindow)
    {
        int goldDropped = Monster.MonsterGold;
        if (goldDropped > 0)
        {
            playerState.Player.GoldInPocket += goldDropped;
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
}


