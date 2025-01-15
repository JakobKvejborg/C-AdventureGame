using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AdventureGame;

internal class PlayerState
{
    // Name, maxhealth, currenthealth, damage, strength, lifesteal, armor, dodge, gold, experience, level, crit, regen
    private Player player = new Player("Hero", 40, 40, 1, 3, 0, 0, 0, 0, 0, 1, 0, 0, 150);
    public Player Player => player;
   
}
