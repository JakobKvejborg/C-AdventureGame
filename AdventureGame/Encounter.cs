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

    public static void PerformEncounter(TextBox textBox1, List<Monster> listOfMonsters)
    {
        // Finds a random monster from the list of monsters to fight against, and stores it in the Monster property
        Monster = GetRandomMonster(listOfMonsters);

    }

    public static Monster GetRandomMonster(List<Monster> listOfMonsters)
    {
        Random randomMonster = new Random();
        int randomMonsterIndex = randomMonster.Next(listOfMonsters.Count);
        Monster encounteredMonster = listOfMonsters[randomMonsterIndex];

        SetEncounteredMonsterLabels(encounteredMonster);

        return encounteredMonster;
    }

    // This method sets all the labels to match the encountered monsters stats
    private static void SetEncounteredMonsterLabels(Monster encounteredMonster)
    {
        int monsterHealth = encounteredMonster.MaxHealth;
        int monsterAttack = encounteredMonster.MaxDamage;

        MainWindow.labelMonsterName.Text = encounteredMonster.Name;
        MainWindow.progressBarMonsterHP.Maximum = encounteredMonster.MaxHealth;
        MainWindow.progressBarMonsterHP.Value = encounteredMonster.CurrentHealth;
        MainWindow.labelMonsterHp.Text = $"HP: {encounteredMonster.CurrentHealth}/{encounteredMonster.MaxHealth}";
        MainWindow.pictureBoxMonster1.Image = encounteredMonster.MonsterImage; // Sets the image to the encountered monster
    }

    public static void PlayerAttacks(PlayerState playerState, TextBox textBox1)
    {
        if (Monster != null && Monster.CurrentHealth != 0)
        {
            Monster.CurrentHealth -= playerState.Player.Damage; // The player deals damage
            MainWindow.progressBarMonsterHP.Value = Monster.CurrentHealth;
            textBox1.Text = $"You attack the {Monster.Name}, and deal {playerState.Player.Damage} damage!";
            MainWindow.labelMonsterHp.Text = $"HP: {Monster.CurrentHealth}/{Monster.MaxHealth}";
            if (Monster.CurrentHealth <= 0)
            {
                MonsterIsDefeated(textBox1, playerState); // Checks if the monster is dead
            }
            else
            {
                MonsterAttacks(playerState, textBox1); // Monster attacks back if still alive
            }
        }
    }


    public static void MonsterAttacks(PlayerState playerState, TextBox textBox1)
    {
        if (playerState.Player.CurrentHealth > 0)
        {
            playerState.Player.CurrentHealth -= (Monster.MinDamage + Monster.RandomDamageModifier);
            playerState.Player.CurrentHealth = Math.Max(playerState.Player.CurrentHealth, 0);
            MainWindow.progressBarPlayerHP.Value = playerState.Player.CurrentHealth;
            MainWindow.labelPlayerHP.Text = $"HP: {playerState.Player.CurrentHealth.ToString()}/{playerState.Player.MaxHealth}";
        }

        // Check if the player is defeated
        if (playerState.Player.CurrentHealth <= 0)
        {
            textBox1.Text = "You are dead, game over.";
            Thread.Sleep(2000);
            Application.Exit();
        }
    }

    private static void MonsterIsDefeated(TextBox textBox1, PlayerState playerState)
    {
        if (Monster.CurrentHealth == 0)
        {
            textBox1.Text = $"You have defeated the monster. You gain {Monster.MonsterExperience}xp.";
            MainWindow.panelMonster.Visible = false; // Hides the monster once it's defeated
            PlayerGetsExperiencePoints(playerState);
            StoryProgress.progressFlag = true;

            // resets the monster object
            Monster.CurrentHealth = Monster.MaxHealth;
            Monster = null;
        }
    }

    private static void PlayerGetsExperiencePoints(PlayerState playerState)
    {
        // I want the player to get the experience points the monster has
        playerState.Player.Experience += Monster.MonsterExperience;
        playerState.Player.LevelUp();
    }
}
