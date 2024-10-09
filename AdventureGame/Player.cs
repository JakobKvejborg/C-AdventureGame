namespace AdventureGame;

internal class Player
{

    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int Damage { get; set; }
    public int Strength { get; set; }
    public int Lifesteal {  get; set; }
    public int Armor { get; set; }
    public int DodgeChance { get; set; }
    public int GoldInPocket { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public List<Item> Inventory { get; set; }
    public List<Item> EquippedItems { get; set; }
    public event Action LevelUpEvent;

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
        EquippedItems = new List<Item>();
    }
       
    public void LevelUp(PlayerState playerState)
    {
        if (Experience >= 10 * (Level + Level))
        {
            Level++;
            playerState.Player.Experience = 0;
            
            LevelUpEvent?.Invoke();
        }
    }

    internal int CalculateTotalDamage(PlayerState playerState)
    {
        return playerState.Player.Damage + ((playerState.Player.Strength / 2) * playerState.Player.Level / 3);
    }

    public void AddItemToInventory(Item foundItem)
    {
        Inventory.Add(foundItem);
    }
}
