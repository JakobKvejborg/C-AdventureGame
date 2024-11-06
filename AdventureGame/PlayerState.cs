using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AdventureGame;

internal class PlayerState
{
    // Name, maxhealth, currenthealth, damage, strength, lifesteal, armor, dodge, gold, experience, level, crit, regen
    private Player player = new Player("Hero", 35, 35, 331, 3, 0, 0, 0, 0, 0, 1, 0, 0);
    public Player Player => player;
   
}
