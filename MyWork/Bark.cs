using UnityEngine;

public class PlayerBark : MonoBehaviour
{
    public float barkRadius = 5f;
    public LayerMask npcLayer; 

    [Header("Audio Settings")]
    public AudioSource playerAudio; // This slot is MISSING in your screenshot!
    public AudioClip barkSound;     // This slot is MISSING in your screenshot!

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PerformBark();
        }
    }

    void PerformBark()
    {
        // 1. Play Sound
        if (playerAudio != null && barkSound != null)
        {
            playerAudio.PlayOneShot(barkSound);
        }

        Debug.Log("Bark!"); 

        // 2. Find NPCs
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, barkRadius, npcLayer);
        foreach (var hitCollider in hitColliders)
        {
            NPCBehavior npc = hitCollider.GetComponent<NPCBehavior>();
            if (npc != null)
            {
                npc.HearBark();
            }
        }
    }
}