using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AdventureGame;

internal class PlayerState
{

    private Player player = new Player("Hero", 35, 35, 5, 3, 0, 0, 0, 0, 0, 1, 0, 0);
    public Player Player => player;
   
}
