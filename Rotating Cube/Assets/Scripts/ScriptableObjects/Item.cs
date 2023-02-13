/* this is a ScriptableObject
 * ScriptableObject is a serializable Unity class that allows you to store large quantities of shared data independent from script instances.
 * They make it easier to manage changes and debugging.
 * For example, when instantiating a new prefab, it will create a copy of its own data. Instead of doing this, you can use a ScriptableObject to store the data and access it
 * by reference from all the prefabs.
 * 
 * Pros:
 * - Data is persistent in Unity
 * - Economic memory usage
 * - Allows code decoupling
 * - Rapid prototyping and testing
 * - It is an object
 * - You can nest SO in another SO
 * - Hold multiple datatypes
 * 
 * Cons:
 * - Doesn't save on standalone build
 * - Doesn't scale well with large builds
 * - Requires a script which inherits from Monobehaviour, to use the SO 
 * - You can nest SO in another SO
 */

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
