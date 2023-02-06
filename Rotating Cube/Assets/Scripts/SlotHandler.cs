using UnityEngine;

public class SlotHandler : MonoBehaviour
{
    public int slotValue;
    public InventoryManager parentInventory;

    public void SlotEvent()
    {
        DragNDrop.selectedSlotIndex = slotValue;
        DragNDrop.currentSlot = this;
    }

    public void SlotEventOrigin()
    {
        DragNDrop.homeSlot = this;
    }
}
