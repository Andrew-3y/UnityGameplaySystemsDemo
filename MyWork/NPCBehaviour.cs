using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    [Header("Settings")]
    public string requiredItemName; // TYPE: "FireButton" or "OpenButton" here in Inspector

    [Header("Visuals & Audio")]
    public GameObject questionMarkIcon; 
    public AudioSource npcAudio;    // Renamed for clarity
    public AudioClip confusedSound;     
    public AudioClip successSound; 

    [Header("Rewards")]
    public GameObject doorObject;   
    public GameObject winMessage;   

    [Header("State")]
    public bool isReadyToListen = false; 
    public bool puzzleSolved = false;

    void Start()
    {
        if(questionMarkIcon != null) questionMarkIcon.SetActive(false);
        if(winMessage != null) winMessage.SetActive(false);
    }

    public void HearBark()
    {
        if (puzzleSolved) return;
        if (questionMarkIcon != null && questionMarkIcon.activeSelf) questionMarkIcon.SetActive(false);

        isReadyToListen = true;
        if (questionMarkIcon != null) questionMarkIcon.SetActive(true);
        if (npcAudio != null && confusedSound != null) npcAudio.PlayOneShot(confusedSound);
    }

    public void ReceiveItem(string itemName)
    {
        if (puzzleSolved) return;

        if (isReadyToListen)
        {
            if (itemName == requiredItemName)
            {
                puzzleSolved = true;
                if(questionMarkIcon != null) questionMarkIcon.SetActive(false);
                if (npcAudio != null && successSound != null) npcAudio.PlayOneShot(successSound);
                if (doorObject != null) doorObject.SetActive(false);
                if (winMessage != null) winMessage.SetActive(true);
            }
            else { Debug.Log("Wrong item. I need: " + requiredItemName); }
        }
    }
}