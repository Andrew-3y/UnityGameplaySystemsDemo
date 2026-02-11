using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    public GameObject inventoryPanel;

    // Reference to the timer (if you are using the start lock feature)
    private GameTimer gameTimer;

    void Start()
    {
        // Find the timer
        gameTimer = Object.FindFirstObjectByType<GameTimer>();

        // --- AUTO HIDE ---
        // We hide the panel here in code, so it can start "Active" in the Inspector
        if (inventoryPanel != null)
        {
            inventoryPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Check for "I" key press
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Optional: Check if game has started (Timer check)
            if (gameTimer != null && !gameTimer.IsGameRunning())
            {
                return; // Don't open if game hasn't started
            }

            // Toggle the panel on/off
            if (inventoryPanel != null)
            {
                inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            }
        }
    }
}