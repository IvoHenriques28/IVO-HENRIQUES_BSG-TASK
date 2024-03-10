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

    public GameObject sellingTip;

    // Start is called before the first frame update
    void Start()
    {
        //start bool as false
        InventoryShowing = false;
        coinAmount = 10;
        //create new inventory and set it in the UI
        inventory = new Inventory();
        inventory.AddItem(new Item { itemType = Item.ItemType.Misc, id = 1, price = 10 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Misc, id = 2, price = 20 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Misc, id = 2, price = 20 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Misc, id = 3, price = 30 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Misc, id = 5, price = 20 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Misc, id = 4, price = 10 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Misc, id = 3, price = 20 });
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
        if (Input.GetKeyDown("i"))
        {
            InventoryShowing = !InventoryShowing;
            gameObject.GetComponent<PlayerMovement>().enabled = !gameObject.GetComponent<PlayerMovement>().enabled;
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

    public void RefreshInventory()
    {
        uiInventory.SetInventory(inventory);
    }
}
