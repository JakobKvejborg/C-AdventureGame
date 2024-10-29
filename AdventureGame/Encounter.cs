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
    private static readonly Random randomMonster = new Random();
    private static readonly Random randomItem = new Random();
    private static readonly Random randomDodge = new Random();
    public static List<Item>? encounteredMonsterItems; // saves the list of items from the parameter til at property
    public static event EventHandler? EncounterCompleted;


    public static void PerformEncounter(List<Monster> listOfMonsters, List<Item> listOfItems, MainWindow mainWindow)
    {
        // Disables encounters from town
        StoryProgress.playerIsInTown = false;
        StoryProgress.progressFlag = false;

        // Prepares the GUI
        mainWindow.textBox1.Clear();
        mainWindow.panelMonster.Show();

        encounteredMonsterItems = listOfItems; // saves the list of items from the parameter til at property

        // Finds a random monster from the list of monsters to fight against, and stores it in the Monster property
        Monster = GetRandomMonster(listOfMonsters);
        SetEncounteredMonsterLabels(Monster, mainWindow);

    }


    public static Monster GetRandomMonster(List<Monster> listOfMonsters)
    {
        int randomMonsterIndex = randomMonster.Next(listOfMonsters.Count);
        Monster encounteredMonster = listOfMonsters[randomMonsterIndex];

        // TEST Return a deep copy of monster
        Monster monsterClone = encounteredMonster.CloneMonster();

        //return encounteredMonster;
        return monsterClone;
    }

    // This method sets all the labels to match the encountered monsters stats
    private static void SetEncounteredMonsterLabels(Monster encounteredMonster, MainWindow mainWindow)
    {
        if (encounteredMonster.Name == "Aldrus Thornfell" || encounteredMonster.Name == "Another Boss Name")
        {
            mainWindow.textBox1.Text = $"You have awakened {encounteredMonster.Name}! Your end is near.";
        }
        else
        {
            mainWindow.textBox1.Text = $"You have encountered a {encounteredMonster.Name}! Kill it.";
        }

        int monsterHealth = encounteredMonster.MaxHealth;
        int monsterAttack = encounteredMonster.MaxDamage;

        mainWindow.labelMonsterName.Text = encounteredMonster.Name;
        mainWindow.progressBarMonsterHP.Maximum = encounteredMonster.MaxHealth;
        mainWindow.progressBarMonsterHP.Value = encounteredMonster.CurrentHealth;
        mainWindow.labelMonsterHp.Text = $"HP: {encounteredMonster.CurrentHealth}/{encounteredMonster.MaxHealth}";
        mainWindow.pictureBoxMonster1.Image = encounteredMonster.MonsterImage; // Sets the image to the encountered monster
    }

    public static void PlayerAttacks(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster != null && Monster.CurrentHealth > 0)
        {
            mainWindow.textBox1.Text = (""); // clears the textbox
            int playerAttackDamageTotal = playerState.Player.CalculateTotalDamage(playerState); // The player deals damage
            Monster.CurrentHealth -= playerAttackDamageTotal;

            // This makes sure the monsters' hp doesn't drop below 0
            if (Monster.CurrentHealth < 0)
            {
                Monster.CurrentHealth = 0;
            }

            mainWindow.progressBarMonsterHP.Value = Monster.CurrentHealth;
            AttackText(playerState, mainWindow);
            mainWindow.labelMonsterHp.Text = $"HP: {Monster.CurrentHealth}/{Monster.MaxHealth}";

            if (Monster.CurrentHealth > 0)
            {
                MonsterAttacks(playerState, mainWindow); // Monster attacks back if still alive
            }
        }
    }

    private static void AttackText(PlayerState playerState, MainWindow mainWindow)
    {

        if (Monster.Name == "Aldrus Thornfell" || Monster.Name == "Another Boss Name")
        {
            mainWindow.textBox1.AppendText($"You attack {Monster.Name}, and deal {playerState.Player.CalculateTotalDamage(playerState)} damage. \r\n");
        }
        else
        {
            mainWindow.textBox1.AppendText($"You attack the {Monster.Name}, and deal {playerState.Player.CalculateTotalDamage(playerState)} damage. \r\n");
        }
    }

    // This method is called by MainWindow every time the player attacks
    public static async void MonsterAttacks(PlayerState playerState, MainWindow mainWindow)
    {
        if (playerState.Player.CurrentHealth > 0) // checks if player is dead
        {

            int dodgeChanceRoll = randomDodge.Next(1, 101);
            if (dodgeChanceRoll <= playerState.Player.DodgeChance)
            {
                mainWindow.textBox1.AppendText("\n\rYou dodged the horror's attack!");
                return; // Exit the method if the player dodges
            }
            // Stores the monsters damage dealt in a local variable to avoid the damage being calculated twice
            int monsterDamageDealt = Monster.CalculateMonsterDamage(Monster);
            int armorBlocked = Math.Min(playerState.Player.Armor, monsterDamageDealt); // Armor can't block more than damage dealt
            int damageTaken = Math.Max(monsterDamageDealt - armorBlocked, 0); // ensures the damage isn't negative

            playerState.Player.CurrentHealth -= damageTaken;
            playerState.Player.CurrentHealth = Math.Max(playerState.Player.CurrentHealth, 0);
            mainWindow.progressBarPlayerHP.Value = playerState.Player.CurrentHealth; // game crashed here
            mainWindow.labelPlayerHP.Text = $"HP: {playerState.Player.CurrentHealth.ToString()}/{playerState.Player.MaxHealth}";
            mainWindow.textBox1.AppendText($"The monster attacks you back and deals {monsterDamageDealt} damage.");
            //if (armorBlocked > 0) // I am not sure I want to display this
            //{
            //    mainWindow.textBox1.AppendText($"\n\r Your armor blocks {armorBlocked} damage.");
            //}
        }

        // Check if the player is defeated
        await playerState.Player.HandlePlayerDeathAsync(mainWindow);
    }



    public static void MonsterIsDefeated(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster == null)
        {
            return;
        }
        if (Monster.CurrentHealth <= 0)
        {
            mainWindow.textBox1.AppendText($"\n\rYou have defeated the monster. You gain {Monster.MonsterExperience}xp. ");
            mainWindow.panelMonster.Hide(); // Hides the monster once it's defeated
            PlayerGetsExperiencePoints(playerState, mainWindow);
            PlayerGetsGoldFromMonster(playerState, mainWindow);
            PlayerFindsItemFromMonster(playerState, mainWindow);
            StoryProgress.progressFlag = true;

            // resets the monster object
            Monster.CurrentHealth = Monster.MaxHealth;
            Monster = null;
            EncounterCompleted?.Invoke(null, EventArgs.Empty);
        }
    }

    public static void PlayerFindsItemFromMonster(PlayerState playerState, MainWindow mainWindow)
    {
        int randomItemIndex = randomItem.Next(encounteredMonsterItems.Count);
        Item foundItem = encounteredMonsterItems[randomItemIndex];

        if (Monster == null || foundItem == null)
        {
            return;
        }
        //Get a random item from the list

        Item itemClone = foundItem.CloneItem();
        mainWindow.textBox1.AppendText($"\r\nYou find an item on the monster's corpse: {itemClone.Name}.");
        playerState.Player.AddItemToInventory(itemClone); // this may do nothing, because the combobox can hold the items instead
        mainWindow.comboBoxInventory.Items.Add(itemClone);
        mainWindow.comboBoxInventory.SelectedItem = itemClone;
    }



    private static void PlayerGetsGoldFromMonster(PlayerState playerState, MainWindow mainWindow)
    {
        playerState.Player.GoldInPocket += Monster.MonsterGold;
        mainWindow.labelGoldInPocket.Text = $"Gold: {playerState.Player.GoldInPocket.ToString()}";
    }

    private static void PlayerGetsExperiencePoints(PlayerState playerState, MainWindow mainWindow)
    {
        // The player gets experience based on the monster
        playerState.Player.Experience += Monster.MonsterExperience;
        playerState.Player.LevelUp(playerState);
        mainWindow.UpdatePlayerLabels();
    }
}
