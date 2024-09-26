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
    //private static List<Monster> listOfMonsters = new List<Monster> { }; // this works if you want to clone the list of monsters
    private static readonly Random randomMonster = new Random();
    private static readonly Random randomItem = new Random();


    public static void PerformEncounter(List<Monster> listOfMonsters, List<Item> listOfItems)
    {
        // creates a copy of the list of monsters so we don't change the mob's health permanently
        //listOfMonsters = originalListOfMonsters.Select(monster => monster.Clone()).ToList(); // this works if you want to clone the list of monsters

        // Finds a random monster from the list of monsters to fight against, and stores it in the Monster property
        Monster = GetRandomMonster(listOfMonsters);
    }

    public static Monster GetRandomMonster(List<Monster> listOfMonsters)
    {
        int randomMonsterIndex = randomMonster.Next(listOfMonsters.Count);
        Monster encounteredMonster = listOfMonsters[randomMonsterIndex];
        SetEncounteredMonsterLabels(encounteredMonster);


        return encounteredMonster;
    }

    // This method sets all the labels to match the encountered monsters stats
    private static void SetEncounteredMonsterLabels(Monster encounteredMonster)
    {
        MainWindow.textBox1.Text = $"You have encountered a {encounteredMonster.Name}! Kill it.";

        int monsterHealth = encounteredMonster.MaxHealth;
        int monsterAttack = encounteredMonster.MaxDamage;

        MainWindow.labelMonsterName.Text = encounteredMonster.Name;
        MainWindow.progressBarMonsterHP.Maximum = encounteredMonster.MaxHealth;
        MainWindow.progressBarMonsterHP.Value = encounteredMonster.CurrentHealth;
        MainWindow.labelMonsterHp.Text = $"HP: {encounteredMonster.CurrentHealth}/{encounteredMonster.MaxHealth}";
        MainWindow.pictureBoxMonster1.Image = encounteredMonster.MonsterImage; // Sets the image to the encountered monster
    }

    public static void PlayerAttacks(PlayerState playerState, List<Item> listOfItems)
    {
        MainWindow.textBox1.Text = (""); // clears the textbox

        if (Monster != null && Monster.CurrentHealth > 0)
        {
            int playerAttackDamageTotal = playerState.Player.CalculateTotalDamage(playerState); // The player deals damage
            Monster.CurrentHealth -= playerAttackDamageTotal;

            // This makes sure the monsters' hp doesn't drop below 0
            if (Monster.CurrentHealth < 0)
            {
                Monster.CurrentHealth = 0;
            }

            MainWindow.progressBarMonsterHP.Value = Monster.CurrentHealth;
            MainWindow.textBox1.AppendText($"You attack the {Monster.Name}, and deal {playerState.Player.Damage} damage. \r\n");
            MainWindow.labelMonsterHp.Text = $"HP: {Monster.CurrentHealth}/{Monster.MaxHealth}";

            if (Monster.CurrentHealth <= 0)
            {
                MonsterIsDefeated(playerState, listOfItems); // Checks if the monster is dead
            }
            else
            {
                MonsterAttacks(playerState); // Monster attacks back if still alive
            }
        }

    }


    public static void MonsterAttacks(PlayerState playerState)
    {
        if (playerState.Player.CurrentHealth > 0)
        {
            playerState.Player.CurrentHealth -= Monster.CalculateMonsterDamage(Monster);
            playerState.Player.CurrentHealth = Math.Max(playerState.Player.CurrentHealth, 0);
            MainWindow.progressBarPlayerHP.Value = playerState.Player.CurrentHealth;
            MainWindow.labelPlayerHP.Text = $"HP: {playerState.Player.CurrentHealth.ToString()}/{playerState.Player.MaxHealth}";
            MainWindow.textBox1.AppendText($"The monster attacks you back and deals {Monster.CalculateMonsterDamage(Monster)} damage.");

        }

        // Check if the player is defeated
        if (playerState.Player.CurrentHealth <= 0)
        {
            MainWindow.textBox1.Text = "You are dead, game over.";
            Application.Exit();
        }
    }

    private static void MonsterIsDefeated(PlayerState playerState, List<Item> listOfItems)
    {
        if (Monster.CurrentHealth <= 0)
        {
            MainWindow.textBox1.Text = $"You have defeated the monster. You gain {Monster.MonsterExperience}xp.";
            MainWindow.panelMonster.Visible = false; // Hides the monster once it's defeated
            PlayerGetsExperiencePoints(playerState);
            PlayerGetsGoldFromMonster(playerState);
            StoryProgress.progressFlag = true;
            PlayerFindsItemFromMonster(playerState, listOfItems);

            // resets the monster object
            Monster.CurrentHealth = Monster.MaxHealth;
            Monster = null;
        }
    }

    private static void PlayerFindsItemFromMonster(PlayerState playerState, List<Item> listOfItems)
    {
        //Get a random item from the list
        if (listOfItems.Count > 0)
        {
            int randomItemIndex = randomItem.Next(listOfItems.Count);
            Item foundItem = listOfItems[randomItemIndex];
            if (foundItem != null)
            {
                MainWindow.textBox1.Text = $"You found item: {foundItem.ToString()}";
            }
        }


    }



    private static void PlayerGetsGoldFromMonster(PlayerState playerState)
    {
        playerState.Player.GoldInPocket += Monster.MonsterGold;
        MainWindow.labelGoldInPocket.Text = $"Gold: {playerState.Player.GoldInPocket.ToString()}";
    }

    private static void PlayerGetsExperiencePoints(PlayerState playerState)
    {
        // The player gets experience based on the monster
        playerState.Player.Experience += Monster.MonsterExperience;
        playerState.Player.LevelUp(playerState);
    }
}
