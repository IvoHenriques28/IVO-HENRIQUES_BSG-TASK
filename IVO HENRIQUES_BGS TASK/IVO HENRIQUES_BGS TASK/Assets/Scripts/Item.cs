using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{ 

    public enum ItemType
    {
        Head,
        Accessory,
        Shirt,
        Pants,
        Misc,

    }

    public ItemType itemType;

    public int id;

    //get item Sprite
    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Head:      return ItemAssets.instance.headSprites[id];
            case ItemType.Accessory: return ItemAssets.instance.accessorySprites[id];
            case ItemType.Shirt:     return ItemAssets.instance.shirtSprites[id];
            case ItemType.Pants:     return ItemAssets.instance.pantsSprites[id];
            case ItemType.Misc:      return ItemAssets.instance.miscSprites[id];
        }
    }
}
