using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Singleton so Inventory.cs can find this script
    public static InventoryUI instance;

    public Transform itemsParent;   // The object holding all your slots
    public GameObject inventoryUI;  // The entire visual panel

    Inventory inventory;
    InventorySlot[] slots;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        inventory = Inventory.instance;
        if (inventory != null)
        {
            inventory.onItemChangedCallback += UpdateUI;
        }

        // --- THE FIX ---
        // The 'true' tells Unity to find slots even if they are currently hidden/inactive
        slots = itemsParent.GetComponentsInChildren<InventorySlot>(true); 
    }

    public void UpdateUI()
    {
        // Loop through all slots
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                // If there is an item, add it to the slot
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                // If there is no item, clear the slot
                slots[i].ClearSlot();
            }
        }
    }
}