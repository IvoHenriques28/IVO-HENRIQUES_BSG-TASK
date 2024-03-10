using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    public Inventory inventory; // inventory reference
    public bool InventoryShowing; //say if the inventory should be on display or not
    [SerializeField] private UIInventory uiInventory;
    public Animator UIAnimatorInventory; //UI animator component related to the inventory
   
    //coin amount
    public int coinAmount;
    public TextMeshProUGUI coinAmountDisplay;
    public bool ableToSell;
    public int itemAmount;

    public GameObject sellingTip;
    public GameObject shopUI;

    // Start is called before the first frame update
    void Start()
    {
        //start bool as false
        InventoryShowing = false;
        coinAmount = 5;
        //create new inventory and set it in the UI
        inventory = new Inventory();
        for(int i = 0; i < itemAmount; i++)
        {
            inventory.AddItem(new Item { itemType = Item.ItemType.Misc, id = Random.Range(0, 8), price = 4 });
        }
       
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        //update the coin total
        coinAmountDisplay.text = coinAmount.ToString();

        //display inventory function
        DisplayInventory();
    }

    public void DisplayInventory()
    {
        //set animator bool equal to script
        UIAnimatorInventory.SetBool("Inventory", InventoryShowing);

        //if inventory key is pressed, change inventory bool
        if (Input.GetKeyDown("i") && !ableToSell)
        {
            TurnInventoryOnOff();
            
        }

        if (ableToSell)
        {
            sellingTip.SetActive(true);
        }
        else
        {
            sellingTip.SetActive(false);
        }
    }

    public void TurnInventoryOnOff()
    {
        InventoryShowing = !InventoryShowing;

        if (!ableToSell) 
        {
            gameObject.GetComponent<PlayerMovement>().enabled = !gameObject.GetComponent<PlayerMovement>().enabled;
        }
        else
        {
            StartCoroutine(ResetShopOptions());
                

        }
    }

    IEnumerator ResetShopOptions()
    {
        yield return new WaitForSeconds(0.5f);

        shopUI.GetComponent<ShopkeeperReference>().SellItems();
    }

    public void RefreshInventory()
    {
        uiInventory.SetInventory(inventory);
    }
}
