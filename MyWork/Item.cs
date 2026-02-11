using UnityEngine;

public enum ItemType
{
    Button,
    items,
    Equipment
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public bool consumeOnUse = true;
    public string itemName;
    public Sprite icon;
    public ItemType itemType;

    public virtual void Use()
    {
        Debug.Log("Using " + itemName);
    }
}
