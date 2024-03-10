using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBehaviour : MonoBehaviour, IPointerClickHandler
{

    public InventorySystem player;
    public ShopBehaviour shop;

    public int priceWorth;

    //get it's own reference within inventory
    public Item myself;

    public bool shopItem;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
        shop = GameObject.FindGameObjectWithTag("Shopkeeper").GetComponent<ShopBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SellItem()
    {
        Debug.Log("Mouse over");
           
        player.coinAmount += priceWorth;
        player.inventory.RemoveItem(myself);
        player.RefreshInventory();
    }

    public void BuyItem()
    {
        if(player.coinAmount >= priceWorth)
        {
            player.coinAmount -= priceWorth;
            myself.price = 8;
            player.inventory.AddItem(myself);
            shop.inventory.RemoveItem(myself);
            player.RefreshInventory();
            shop.RefreshInventory();
        }      
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Object Clicked");
        if (eventData.button == PointerEventData.InputButton.Left)
            Debug.Log("Left click");
        else if (eventData.button == PointerEventData.InputButton.Middle)
            Debug.Log("Middle click");
        else if (eventData.button == PointerEventData.InputButton.Right)
            if (player.ableToSell)
            {
                SellItem();
            }

        if (shopItem)
        {
            BuyItem();
        }
    }
}
