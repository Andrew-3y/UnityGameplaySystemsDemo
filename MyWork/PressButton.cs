using UnityEngine;

public class PressButton : MonoBehaviour
{
    public Transform player;
    public float interactDistance = 2f;
    public AudioSource buttonSound;
    public GameObject promptPanel;
    public float cooldown = 1.0f;

    private float lastPlayTime = 0f;
    private bool onCooldown = false;

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        bool inRange = distance <= interactDistance;

        // Check if cooldown is over
        if (onCooldown && Time.time >= lastPlayTime + cooldown)
        {
            onCooldown = false;
        }

        // Manage prompt visibility
        if (inRange && !onCooldown)
        {
            if (!promptPanel.activeSelf)
            {
                promptPanel.SetActive(true);
            }
        }
        else
        {
            if (promptPanel.activeSelf)
            {
                promptPanel.SetActive(false);
            }
        }

        // Detect interaction (E key)
        if (inRange && !onCooldown && Input.GetKeyDown(KeyCode.E))
        {
            if (buttonSound != null)
            {
                buttonSound.Play();
            }
            lastPlayTime = Time.time;
            onCooldown = true;

            // Hide the prompt immediately when cooldown starts
            if (promptPanel.activeSelf)
            {
                promptPanel.SetActive(false);
            }
        }
    }
}