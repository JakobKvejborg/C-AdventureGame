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
    public List<Item> Inventory { get; set; }
    //public List<Item> EquippedItems { get; set; }
    public event Action LevelUpEvent;
    public static int priceToHeal { get; set; } = 2; // 2 is the default value
    public Dictionary<ItemType, Item> EquippedItems { get; private set; }

    public Player(string name, int maxHealth, int currentHealth, int damage, int strength, int lifesteal,
        int armor, int dodgeChance, int goldInPocket, int experience, int level)
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
        //EquippedItems = new List<Item>();
        EquippedItems = new Dictionary<ItemType, Item>();
    }

    public void LevelUp(PlayerState playerState)
    {
        if (Experience >= 10 * (Level + Level))
        {
            Level++;
            playerState.Player.Experience = 0;

            playerState.Player.MaxHealth += playerState.Player.Level;
            playerState.Player.CurrentHealth = playerState.Player.MaxHealth; // this heals the player to full hp on level up

            LevelUpEvent?.Invoke();
        }
    }

    public int CalculateTotalDamage(PlayerState playerState)
    {
        return playerState.Player.Damage + ((playerState.Player.Strength / 2) * playerState.Player.Level / 3);
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
            priceToHeal += 3 * priceToHeal;
        }
    }

    public void EquipItem(Item item, ComboBox comboboxInventory)
    {
        if (EquippedItems.ContainsKey(item.Type)) // Check if the itemtype is already equipped
        {
            UnequipItem(EquippedItems[item.Type], comboboxInventory);
        }

        // Equip the item
        EquippedItems[item.Type] = item;

        // Apply item bonuses to the player
        Damage += item.Damage;
        Armor += item.Armor;
        MaxHealth += item.Health;
        DodgeChance += item.DodgeChance;
        Strength += item.Strength;
        Level += item.SkillLevel;

    }

    public void UnequipItem(Item item, ComboBox comboboxInventory)
    {
        if (EquippedItems.ContainsKey(item.Type))
        {
            // Remove item bonuses to the player
            Damage -= item.Damage;
            Armor -= item.Armor;
            MaxHealth -= item.Health;
            DodgeChance -= item.DodgeChance;
            Strength -= item.Strength;
            Level -= item.SkillLevel;

            EquippedItems.Remove(item.Type);
            comboboxInventory.Items.Add(item);
        }
    }
}
