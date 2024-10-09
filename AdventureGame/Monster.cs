using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

internal class Monster
{

    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }
    public int RandomDamageModifier { get; set; }
    public int MonsterExperience { get; set; }
    public int MonsterGold { get; set; }
    public Image MonsterImage { get; set; }
    private Random randomMonsterDamage = new Random();


    public Monster(string name, int maxHealth, int currentHealth, int minDamage, int maxDamage, int randomDamageModifier,
        int monsterExperience, int monsterGold)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        RandomDamageModifier = randomDamageModifier;
        MonsterExperience = monsterExperience;
        MonsterGold = monsterGold;
    }

    // Constructor with image
    public Monster(string name, int maxHealth, int currentHealth, int minDamage, int maxDamage, int randomDamageModifier,
     int monsterExperience, int monsterGold, Image monsterImage)
    {
        Name = name;
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        RandomDamageModifier = randomDamageModifier;
        MonsterExperience = monsterExperience;
        MonsterGold = monsterGold;
        MonsterImage = monsterImage;
    }

    public String ToString()
    {
        return $"Monster: {Name}, Health: {MaxHealth}";
    }

    public int CalculateMonsterDamage(Monster encounteredMonster)
    {
        return encounteredMonster.MinDamage + encounteredMonster.randomMonsterDamage.Next(encounteredMonster.RandomDamageModifier + 1);
    }

    public Monster CloneMonster()
    {
        return (Monster)this.MemberwiseClone();
    }

    //// // this works if you want to clone the list of monsters
    //public Monster Clone()
    //{
    //    return new Monster(

    //        Name,
    //        MaxHealth,
    //        CurrentHealth,
    //        MaxDamage,
    //        MinDamage,
    //        RandomDamageModifier,
    //        MonsterExperience,
    //        MonsterGold,
    //        MonsterImage
    //    );
    //    }
}
