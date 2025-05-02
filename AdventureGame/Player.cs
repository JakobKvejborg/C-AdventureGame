using System.Text.Json;
using System.Xml;

namespace AdventureGame;

internal class Player
{
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int Damage { get; set; }
    public int Strength { get; set; }
    public int Lifesteal { get; set; }
    public int Armor { get; set; }
    public int DodgeChance { get; set; }
    public int GoldInPocket { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public int CritChance { get; set; }
    public int Regeneration { get; set; }
    public int CritDamage { get; set; }
    public List<Item> Inventory { get; set; }
    public event Action LevelUpEvent;
    public static int priceToHeal { get; set; } = 2; 
    public static int PriceToLearnTechnique { get; set; } = 10;
    public Dictionary<ItemType, Item> EquippedItems { get; private set; }
    public int XpNeededToLevelUp => ((10 * (Level + Level)) + (Level * Level) - 1);
    public bool techniqueBloodLustIsLearned { get; set; }
    public bool techniqueSwiftIsLearned { get; set; }
    public bool techniqueRoarIsLearned { get; set; }
    public bool techniqueDivineIsLearned { get; set; }
    public bool techniqueGuardIsLearned { get; set; }
    public int advanceTechnique = 0;
    public int NumberOfDragonEggsInInventory { get; set; }
    public bool HasDragonMageUpgradeForSmith { get; set; }
    public int RoarBuffDodge { get; set; } = 10;
    public int RoarBuffCrit { get; set; } = 5;
    public bool IsRoarActive { get; set; } = false;
    public int RoarBuffCountdown { get; set; }
    public int GuardBuffArmor { get; set; }
    public bool GuardBuffIsActive { get; set; }
    public double PlayerIsOnLowHealth => MaxHealth * 0.27;
    public static bool HasFrozenLily;

    public Player(string name, int maxHealth, int currentHealth, int damage, int strength, int lifesteal,
        int armor, int dodgeChance, int goldInPocket, int experience, int level, int critChance, int regeneration, int critDamage)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
        Damage = damage;
        Strength = strength;
        Lifesteal = lifesteal;
        Armor = armor;
        DodgeChance = dodgeChance;
        GoldInPocket = goldInPocket;
        Experience = experience;
        Level = level;
        Inventory = new List<Item>();
        EquippedItems = new Dictionary<ItemType, Item>();
        CritChance = critChance;
        Regeneration = regeneration;
        CritDamage = critDamage;
    }

    public void LevelUp(PlayerState playerState)
    {
        if (Experience >= XpNeededToLevelUp)
        {
            Level++;
            playerState.Player.Experience = 0;

            playerState.Player.MaxHealth += playerState.Player.Level + (playerState.Player.Level / 2);
            playerState.Player.CurrentHealth = playerState.Player.MaxHealth; // this heals the player to full hp on level up

            LevelUpEvent?.Invoke();
        }
    }

    public int CalculateTotalDamage(PlayerState playerState)
    {
        return playerState.Player.Damage + ((playerState.Player.Strength / 6) * (playerState.Player.Level / 3));
    }

    public void AddItemToInventory(Item foundItem)
    {
        Inventory.Add(foundItem);
    }

    public void HealPlayer(PlayerState playerState)
    {
        if (playerState.Player.GoldInPocket >= priceToHeal)
        {
            playerState.Player.CurrentHealth = MaxHealth;
            playerState.Player.GoldInPocket -= priceToHeal;
            priceToHeal += (int)((priceToHeal * 0.1) + 7) / ModifierProcessor.HealPriceReducedModifier; // Add 10% of the current price + a flat value
        }
    }
    public async Task HandlePlayerDeathAsync(MainWindow mainWindow)
    {
        if (CurrentHealth <= 0)
        {
            await Task.Delay(200);
            Thread.Sleep(1000);
            mainWindow.panelEncounter.Hide();
            mainWindow.panelGameOver.Show();
            await Task.Delay(2100);
            Application.Exit();
        }
    }

    public void EquipItem(Item item, ComboBox comboboxInventory, ComboBox comboboxUpgradeItems, ComboBox comboboxAct3Frog)
    {
        if (EquippedItems.ContainsKey(item.Type)) // Check if the itemtype is already equipped
        {
            UnequipItem(EquippedItems[item.Type], comboboxInventory, comboboxUpgradeItems, comboboxAct3Frog);
        }

        bool wasAtOneHealth = CurrentHealth < 2; // Check if the player was at 1 health before equipping the item

        // Equip the item
        //EquippedItems.Add(item.Type, item);
        EquippedItems[item.Type] = item; // This replaces any existing item of the same type

        // Apply item bonuses to the player
        Damage += item.Damage;
        Armor += item.Armor;
        MaxHealth += item.Health;
        CurrentHealth += item.Health;
        DodgeChance += item.DodgeChance;
        Strength += item.Strength;
        Level += item.SkillLevel;
        Regeneration += item.Regeneration;
        CritChance += item.CritChance;
        Lifesteal += item.Lifesteal;
        CritDamage += item.CritDamage;

        if (wasAtOneHealth)
        {
            CurrentHealth = 1; // Restore player to 1 hp if the player was on no health - this is due to the way equipping/unequipping items add/subtracks health
        }
    }

    public void UnequipItem(Item item, ComboBox comboboxInventory, ComboBox comboboxUpgradeItem, ComboBox comboboxAct3Frog)
    {
        if (EquippedItems.ContainsKey(item.Type))
        {
            // Remove item bonuses to the player
            Damage -= item.Damage;
            Armor -= item.Armor;
            MaxHealth -= item.Health;
            CurrentHealth -= item.Health;
            DodgeChance -= item.DodgeChance;
            Strength -= item.Strength;
            Level -= item.SkillLevel;
            Regeneration -= item.Regeneration;
            CritChance -= item.CritChance;
            Lifesteal -= item.Lifesteal;
            CritDamage -= item.CritDamage;

            EquippedItems.Remove(item.Type);
            comboboxInventory.Items.Add(item);
            comboboxUpgradeItem.Items.Remove(item);
            comboboxAct3Frog.Items.Remove(item);
            comboboxAct3Frog.SelectedIndex = -1;
            comboboxAct3Frog.Text = string.Empty;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 1;
            }

        }
    }

    public void TurnOffRoarBuff(MainWindow mainWindow)
    {
        DodgeChance -= RoarBuffDodge;
        CritChance -= RoarBuffCrit;
        mainWindow.labelCritChance.ForeColor = Color.White;
        mainWindow.labelPlayerDodge.ForeColor = Color.White;
        IsRoarActive = false;
    }

    public void TurnOnRoarBuff(MainWindow mainWindow)
    {
        DodgeChance += RoarBuffDodge;
        CritChance += RoarBuffCrit;
        mainWindow.labelCritChance.ForeColor = Color.LightBlue;
        mainWindow.labelPlayerDodge.ForeColor = Color.LightBlue;
        IsRoarActive = true;
    }

    public void ResetGuardBuff()
    {
        if (GuardBuffIsActive)
        {
            Armor -= GuardBuffArmor;
            GuardBuffIsActive = false;
            GuardBuffArmor = 0;
        }
    }

    public void ResetRoarBuff(MainWindow mainWindow)
    {
        RoarBuffCountdown = 0;
        if (IsRoarActive)
        {
            TurnOffRoarBuff(mainWindow);
        }
    }

    public void SaveEquippedItemsToFile(string filePath)
    {
        // Check if EquippedItems has any content
        if (EquippedItems == null || !EquippedItems.Any())
        {
            return;
        }

        // Serialize the equipped items to JSON
        string json = JsonSerializer.Serialize(EquippedItems, new JsonSerializerOptions { WriteIndented = true });

        // Write the JSON to the file
        File.WriteAllText(filePath, json);
    }





}
