using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{

    private Inventory inventory;

    [SerializeField] private GameObject InventoryPanel;
    private Transform itemSlotContainter;
    private Transform itemSlotTemplate;

    public bool ShopInventory;


    private void Awake()
    {
        //grab references to the UI item slots
        itemSlotContainter = InventoryPanel.transform.Find("Item Container");
        itemSlotTemplate = itemSlotContainter.Find("Item Container Template");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }


    //for each item currently in our inventory, display it in the UI in a grid format
    public void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainter.transform)
        {
            if(child != itemSlotTemplate)
            {
                Destroy(child.gameObject);
            }
        }
        int x = 0;
        int y = 0;
        int rowLimit = 8;
        float itemSlotCellSize = 120f;
        foreach(Item item in inventory.itemList)
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainter).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            itemSlotRectTransform.gameObject.GetComponent<ItemBehaviour>().priceWorth = item.price;
            itemSlotRectTransform.gameObject.GetComponent<ItemBehaviour>().myself = item;
            Image image = itemSlotRectTransform.Find("Item Icon").GetComponent<Image>();
            if (ShopInventory)
            {
                TextMeshProUGUI price = itemSlotRectTransform.Find("Item Price").GetComponent<TextMeshProUGUI>();

                if (price != null)
                {
                    price.text = itemSlotRectTransform.gameObject.GetComponent<ItemBehaviour>().priceWorth.ToString() + "c";
                }
            }
            

            image.sprite = item.GetSprite();
            x++;
            if(x > rowLimit)
            {
                x = 0;
                y--;
            }
        }
    }


}
