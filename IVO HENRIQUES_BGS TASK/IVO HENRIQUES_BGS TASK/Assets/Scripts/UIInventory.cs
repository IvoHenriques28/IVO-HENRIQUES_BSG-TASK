using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{

    private Inventory inventory;

    [SerializeField] private GameObject InventoryPanel;
    private Transform itemSlotContainter;
    private Transform itemSlotTemplate;

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
    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        int rowLimit = 8;
        float itemSlotCellSize = 120f;
        foreach(Item item in inventory.itemList)
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainter).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("Item Icon").GetComponent<Image>();

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
