using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{

    public List<Item> itemList; //items in our inventory
    public Inventory()
    {
        itemList = new List<Item>(); //initialize Inventory list       
    }

    //add new item to inventory
    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        itemList.Remove(item);
    }
}
