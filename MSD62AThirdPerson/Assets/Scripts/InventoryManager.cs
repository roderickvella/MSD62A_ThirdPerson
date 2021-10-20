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

    [Tooltip("Default Colour")]
    public Color notSelectedColor;

    [Tooltip("Selected Colour")]
    public Color SelectedColor;

    private int currentSelectedIndex = 0;


    [Tooltip("Show inventory GUI")]
    public bool showInventory = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        itemsForPlayer = new List<InventoryItem>();
        PopulateInventorySpawn();
        RefreshInventoryGUI();

        animator = itemsSelectionPanel.GetComponent<Animator>();

    }

    public void ShowToggleInventory()
    {
        if(showInventory == false)
        {
            showInventory = true;
            animator.SetTrigger("InventoryIn");
        }
        else
        {
            showInventory = false;
            animator.SetTrigger("InventoryOut");
        }
    }

    private void OnEnable()
    {
        InputManager.KeyDown += ObservorKeyDown;
    }

    private void OnDisable()
    {
        InputManager.KeyDown -= ObservorKeyDown;
    }

    private void ObservorKeyDown(KeyCode keyCode)
    {
        print("pressed key:" + keyCode.ToString());

        if(keyCode==KeyCode.J || keyCode == KeyCode.K)
        {
            ChangeSelection(keyCode);
        }
        else if(keyCode == KeyCode.Return)
        {
            ConfirmSelection();
        }


    }

    private void ConfirmSelection()
    {
        InventoryItem currentSelectedItem = itemsForPlayer[currentSelectedIndex];
        print("Item selected is:" + currentSelectedItem.item.name);
        //reduce the quantity
        currentSelectedItem.quantity -= 1;

        //if quantity is 0 then delete from array
        if(currentSelectedItem.quantity == 0)
        {
            itemsForPlayer.RemoveAt(currentSelectedIndex);
        }

        //refresh screen with new quantities
        RefreshInventoryGUI();
    }

    private void ChangeSelection(KeyCode keyCode)
    {
        if (keyCode == KeyCode.J)
            currentSelectedIndex -= 1;
        else if (keyCode == KeyCode.K)
            currentSelectedIndex += 1;

        //check boundaries
        if (currentSelectedIndex < 0)
            currentSelectedIndex = 0;

        if (currentSelectedIndex == itemsForPlayer.Count)
            currentSelectedIndex = currentSelectedIndex - 1;

        //refresh GUI to show current selected colour
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

            //change colour if buttonId is the same as currentSelectedIndex
            if (buttonId == currentSelectedIndex)
                button.GetComponent<Image>().color = SelectedColor; //change to green
            else
                button.GetComponent<Image>().color = notSelectedColor; //change to white

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
