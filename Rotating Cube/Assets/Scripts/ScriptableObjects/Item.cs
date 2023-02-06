using UnityEngine;

[CreateAssetMenu(menuName = "Item", fileName = "New Item")]
public class Item : ScriptableObject
{
    public ItemType itemType;
    public Sprite icon;
    public string itemId;
    public string itemName;
    public string itemDesc;
    public bool isStackable;
    public int stackMax;
    public int stackCurrent;
    public int cost;
}

public enum ItemType
{
    none,
    weapon,
    armour,
    consumable,
    materials,
    quest,
    misc
}
