using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

	public class InventoryItem
	{
		public ItemSriptableObject item { get; set; }
		public int quantity { get; set; }

	}


}
