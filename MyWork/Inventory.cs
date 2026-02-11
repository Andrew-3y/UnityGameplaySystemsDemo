using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Singleton pattern to access this from anywhere
    public static Inventory instance;

    // List of items currently in the inventory
    public List<Item> items = new List<Item>();
    
    // Maximum number of items allowed
    public int space = 20;

    // Event for when items change (optional, keeps code clean)
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    void Awake()
    {
        // Ensure there is only one Inventory system
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    public bool Add(Item item)
    {
        // Check if there is room
        if (items.Count >= space)
        {
            Debug.Log("Not enough room.");
            return false;
        }

        // Add item to list
        items.Add(item);

        // --- SAFE UPDATE ---
        // Trigger the update event if anyone is listening
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        
        // Direct Safety Check for the UI
        if (InventoryUI.instance != null)
        {
            InventoryUI.instance.UpdateUI();
        }
        // -------------------

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        // Update the UI safely
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }

        if (InventoryUI.instance != null)
        {
            InventoryUI.instance.UpdateUI();
        }
    }
}