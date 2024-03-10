using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject emote;
    [SerializeField] private GameObject player;
    public Animator DialogueUI;

    private bool DialogueTriggered;

    //shop inventory
    public Inventory inventory;
    [SerializeField] private UIInventory uiInventory;
    // Start is called before the first frame update
    void Start()
    {
        //create new inventory and set it in the UI
        inventory = new Inventory();
        inventory.AddItem(new Item { itemType = Item.ItemType.Shirt, id = 1, price = 10 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Pants, id = 2, price = 20 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Shirt, id = 2, price = 20 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Pants, id = 3, price = 30 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Head, id = 2, price = 20 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Head, id = 3, price = 10 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Accessory, id = 2, price = 20 });
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        //if the player presses F while inside collider before dialogue is already active
        if (Input.GetKeyDown("f") && emote.activeSelf && !DialogueTriggered)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            DialogueTriggered = true;
            DialogueUI.SetBool("DialogueTrigger", DialogueTriggered);
            emote.SetActive(false);
        }
    }

    //if player collides with this object's collider, show the player he can interact with NPC, remove sign if player leaves collider area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            emote.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            emote.SetActive(false);
        }
    }

    public void ReactivateScene()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        DialogueTriggered = false;
        DialogueUI.SetBool("DialogueTrigger", DialogueTriggered);

        emote.SetActive(true);
    }
}
