using UnityEngine;
using UnityEngine.UI; // We still need this for the Image component

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    
    // --- THE FIX IS BELOW ---
    // We specifically ask for the UI Button to avoid conflicts with your files
    public UnityEngine.UI.Button removeButton; 
    
    public Item item;

    // Interaction settings
    public float interactionRadius = 3f;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        
        // This line was causing the 'interactable' error
        if (removeButton != null) removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        
        if (removeButton != null) removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        if (Inventory.instance != null)
        {
            Inventory.instance.Remove(item);
        }
    }

    public void UseItem()
    {
        if (item != null)
        {
            // 1. Find Player
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) return;

            // 2. Scan for NPCs
            Collider[] hits = Physics.OverlapSphere(player.transform.position, interactionRadius);
            foreach (var hit in hits)
            {
                NPCBehavior npc = hit.GetComponent<NPCBehavior>();
                if (npc == null) npc = hit.GetComponentInParent<NPCBehavior>();

                if (npc != null)
                {
                    // This fixes the 'TryGiveButton' error
                    npc.ReceiveItem(item.name); 
                    return; 
                }
            }
        }
    }
}