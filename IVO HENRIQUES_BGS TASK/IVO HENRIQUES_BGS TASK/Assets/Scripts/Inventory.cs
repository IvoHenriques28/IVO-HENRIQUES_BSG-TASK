using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{

    public List<Item> itemList; //items in our inventory
    public Inventory()
    {
        itemList = new List<Item>(); //initialize Inventory list

        AddItem(new Item { itemType = Item.ItemType.Head, amount = 3, id = 1 });
        AddItem(new Item { itemType = Item.ItemType.Accessory, amount = 3, id = 2 });
        AddItem(new Item { itemType = Item.ItemType.Pants, amount = 3, id= 2 });
        AddItem(new Item { itemType = Item.ItemType.Shirt, amount = 3, id = 3 });
        AddItem(new Item { itemType = Item.ItemType.Shirt, amount = 3, id = 3 });
        AddItem(new Item { itemType = Item.ItemType.Shirt, amount = 3, id = 3 });
        AddItem(new Item { itemType = Item.ItemType.Shirt, amount = 3, id = 3 });
        AddItem(new Item { itemType = Item.ItemType.Shirt, amount = 3, id = 3 });
        AddItem(new Item { itemType = Item.ItemType.Shirt, amount = 3, id = 3 });
        AddItem(new Item { itemType = Item.ItemType.Shirt, amount = 3, id = 3 });
    }

    //add new item to inventory
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }
}
