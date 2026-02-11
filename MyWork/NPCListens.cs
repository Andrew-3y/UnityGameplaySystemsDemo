using UnityEngine;

public class NpcCommandListener : MonoBehaviour
{
    private NpcDoorController doorController;

    void Awake()
    {
        doorController = GetComponent<NpcDoorController>();
    }

    public void ReceiveSoundCommand(AudioClip clip)
    {
        if (doorController != null)
        {
            doorController.HandleSoundCommand(clip);
        }
    }
}
