using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperReference : MonoBehaviour
{

    public GameObject shopKeeper;
    public InventorySystem player;

    public void AnimationEvent()
    {
        shopKeeper.GetComponent<ShopBehaviour>().ReactivateScene();
    }

    public void LeaveShop()
    {
        gameObject.GetComponent<Animator>().SetBool("DialogueTrigger", false);
        gameObject.GetComponent<Animator>().SetBool("ShowOptions", false);
    }

    public void SellItems()
    {
        player.ableToSell = !player.ableToSell;
        gameObject.GetComponent<Animator>().SetBool("Sell", !gameObject.GetComponent<Animator>().GetBool("Sell"));
    }

    public void TurnOnInventory()
    {
        player.InventoryShowing = true;
    }
}
