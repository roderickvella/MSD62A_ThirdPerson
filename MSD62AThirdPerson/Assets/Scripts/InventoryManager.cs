using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour
{

    [Tooltip("The minimum amount of items the player can have in the inventory")]
    public int minItems = 5;

    [Tooltip("The maximum amount of items the player can have in the inventory")]
    public int maxItems = 10;

    [Tooltip("Items Selection Panel")]
    public GameObject itemsSelectionPanel;

    [Tooltip("List of Inventory Items that we can use")]
    public List<ItemSriptableObject> itemsAvailable;

    private List<InventoryItem> itemsForPlayer;

    // Start is called before the first frame update
    void Start()
    {
        itemsForPlayer = new List<InventoryItem>();
        PopulateInventorySpawn();
        RefreshInventoryGUI();

    }

    private void RefreshInventoryGUI()
    {
        int buttonId = 0;
        foreach(InventoryItem i in itemsForPlayer)
        {
            GameObject button = itemsSelectionPanel.transform.Find("Button" + buttonId).gameObject;
            button.transform.Find("Image").GetComponent<Image>().sprite = i.item.icon;
            button.transform.Find("Quantity").GetComponent<TextMeshProUGUI>().text = "x"+ i.quantity;
            buttonId += 1;
        }

        //active false redundant buttons
        for (int i=buttonId; i < 6; i++)
        {
            itemsSelectionPanel.transform.Find("Button" + i).gameObject.SetActive(false);
        }


    }


    private void PopulateInventorySpawn()
    {
        //randomly decide the number of items to create in the inventory
        int numberOfItems = UnityEngine.Random.Range(minItems, maxItems);

        //pick random items
        for(int i=0; i < numberOfItems; i++)
        {
            ItemSriptableObject objItem = itemsAvailable[UnityEngine.Random.Range(0, itemsAvailable.Count)];

            int countItems = itemsForPlayer.Where(x => x.item == objItem).ToList().Count;

            if(countItems == 0)
            {
                itemsForPlayer.Add(new InventoryItem() { item = objItem, quantity = 1 });
            }
            else
            {
                var item = itemsForPlayer.First(x => x.item == objItem);
                item.quantity += 1;
            }


            //InventoryItem inventoryItem = new InventoryItem();
            //inventoryItem.item = objItem;
            //inventoryItem.quantity = 1;
            //itemsForPlayer.Add(inventoryItem);

            
        }



    }


    public class InventoryItem
	{
		public ItemSriptableObject item { get; set; }
		public int quantity { get; set; }

	}


}
