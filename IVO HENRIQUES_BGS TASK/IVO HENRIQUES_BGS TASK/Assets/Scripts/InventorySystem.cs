using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Inventory inventory; // inventory reference
    private bool InventoryShowing; //say if the inventory should be on display or not
    [SerializeField] private UIInventory uiInventory;
    public Animator UIAnimatorInventory; //UI animator component related to the inventory
    // Start is called before the first frame update

   
    void Start()
    {
        //start bool as false
        InventoryShowing = false;

        //create new inventory and set it in the UI
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }
}
