using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame;

internal class ItemContainer
{
    private List<Item> items1;

    public ItemContainer() 
    {
        items1 = new List<Item>();
    }

    public void AddItemsToList()
    {
        Item item1 = new Item("Axe", 1, 0, 0, 0, 0, 0, 2);

        items1.Add(item1);
    }

}