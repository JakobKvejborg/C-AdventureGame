using System;
using System.Collections.Generic;
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

    public static void PerformEncounter(List<Monster> listOfMonsters, List<Item> listOfItems, MainWindow mainWindow)
    {
        // Disables encounters from town
        StoryProgress.playerIsInTown = false;
        StoryProgress.progressFlag = false;

        // Prepares the GUI
        mainWindow.textBox1.Clear();
        mainWindow.panelMonster.Visible = true;

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
        mainWindow.textBox1.Text = $"You have encountered a {encounteredMonster.Name}! Kill it.";

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
            mainWindow.textBox1.AppendText($"You attack the {Monster.Name}, and deal {playerState.Player.CalculateTotalDamage(playerState)} damage. \r\n");
            mainWindow.labelMonsterHp.Text = $"HP: {Monster.CurrentHealth}/{Monster.MaxHealth}";

            if (Monster.CurrentHealth > 0)
            {
                MonsterAttacks(playerState, mainWindow); // Monster attacks back if still alive
            }
        }
    }

    public static async void MonsterAttacks(PlayerState playerState, MainWindow mainWindow)
    {
        if (playerState.Player.CurrentHealth > 0)
        {
        int dodgeChanceRoll = randomDodge.Next(1, 101);
        if (dodgeChanceRoll <= playerState.Player.DodgeChance)
        {
            mainWindow.textBox1.AppendText("\n\r You dodged the monster's attack!");
            return; // Exit the method if the player dodges
        }
            // Stores the monsters damage dealt in a local variable to avoid the damage being calculated twice
            int monsterDamageDealt = Monster.CalculateMonsterDamage(Monster);

            playerState.Player.CurrentHealth -= monsterDamageDealt;
            playerState.Player.CurrentHealth = Math.Max(playerState.Player.CurrentHealth, 0);
            mainWindow.progressBarPlayerHP.Value = playerState.Player.CurrentHealth;
            mainWindow.labelPlayerHP.Text = $"HP: {playerState.Player.CurrentHealth.ToString()}/{playerState.Player.MaxHealth}";
            mainWindow.textBox1.AppendText($"\r\nThe monster attacks you back and deals {monsterDamageDealt} damage.");
        }

        // Check if the player is defeated
        await CheckIfPlayerIsDefeated(playerState, mainWindow);
    }

    private static async Task CheckIfPlayerIsDefeated(PlayerState playerState, MainWindow mainWindow)
    {
        if (playerState.Player.CurrentHealth <= 0)
        {
            await Task.Delay(200);
            Thread.Sleep(1000);
            mainWindow.panelEncounter.Visible = false;
            mainWindow.panelGameOver.Visible = true;
            await Task.Delay(1200);
            Application.Exit();
        }
    }

    public static void MonsterIsDefeated(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster == null)
        {
            return;
        }
        if (Monster.CurrentHealth <= 0)
        {
            mainWindow.textBox1.Text = $"You have defeated the monster. You gain {Monster.MonsterExperience}xp.";
            mainWindow.panelMonster.Visible = false; // Hides the monster once it's defeated
            PlayerGetsExperiencePoints(playerState, mainWindow);
            PlayerGetsGoldFromMonster(playerState, mainWindow);
            PlayerFindsItemFromMonster(playerState, mainWindow);
            StoryProgress.progressFlag = true;

            // resets the monster object
            Monster.CurrentHealth = Monster.MaxHealth;
            Monster = null;

        }
    }

    public static void PlayerFindsItemFromMonster(PlayerState playerState, MainWindow mainWindow)
    {
        if (Monster == null)
        {
            return;
        }
        //Get a random item from the list
        int randomItemIndex = randomItem.Next(encounteredMonsterItems.Count);
        Item foundItem = encounteredMonsterItems[randomItemIndex];
        if (foundItem != null)
        {
            mainWindow.textBox1.AppendText($"\r\nYou find an item on the monster's corpse: {foundItem.ToString()}");
            playerState.Player.AddItemToInventory(foundItem); // this may do nothing, because the combobox can hold the items instead
            mainWindow.comboBoxInventory.Items.Add(foundItem);
            mainWindow.comboBoxInventory.SelectedItem = foundItem;
        }

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
        mainWindow.labelExperience.Text = $"Experience: {playerState.Player.Experience}/{10 * (playerState.Player.Level + playerState.Player.Level)}";
        playerState.Player.LevelUp(playerState);
    }
}
