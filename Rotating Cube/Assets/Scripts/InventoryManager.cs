using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    #region References
    //list of items in the inventory
    public List<Item> inventory = new List<Item>();
    //array of the UI image boxes on screen for this inventory
    public Image[] slots = new Image[18];
    //blank item
    public Item empty;
    //reference to the currently selected item
    public Item selectedItem;
    //checks if the dragged item should be swapped with slotted item
    public bool canSwap;
    #endregion

    #region Drag and Drop items
    public void UpdateDisplay()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            //for every slot in the inventory, updates their icons if changed
            slots[i].sprite = inventory[i].icon;
        }
    }

    public void DragDropEvent()
    {
        selectedItem = DragNDrop.currentSlot.parentInventory.inventory[DragNDrop.selectedSlotIndex];
        //if selected slot is not empty
        if (selectedItem.itemName != "Empty")
        {
            //the mouse selects the item it clicks on
            DragNDrop.currentDrag = selectedItem;
            //the item which the mouse is currently holding is the same item from the slot which the mouse selected
            DragNDrop.currentDragIndex = DragNDrop.selectedSlotIndex;
            //the slot in the inventory becomes empty
            inventory[DragNDrop.selectedSlotIndex] = empty;
            //updates the icon of item held (from empty to now holding item)
            UpdateDisplay();
            //updates the icon of the slot which previously held the item (from holding item to empty slot)
            DragNDrop.UpdateDrag();
        }
    }

    public void PlaceItem()
    {
        selectedItem = DragNDrop.currentSlot.parentInventory.inventory[DragNDrop.selectedSlotIndex];
        //if we are dragging an item
        if (DragNDrop.currentDrag != null)
        {
            //if the inventory slot we are placing the dragged item is empty
            if (selectedItem.itemName == "Empty")
            {
                Debug.Log("You placed an item! Great Job!");
                DragNDrop.currentSlot.parentInventory.inventory[DragNDrop.selectedSlotIndex] = DragNDrop.currentDrag;
            }
            //if the slot is not empty
            else
            {
                if (!canSwap)
                {
                    Debug.Log("You cannot place an item there!");
                    //puts the dragged item back to its original slot
                    DragNDrop.homeSlot.parentInventory.inventory[DragNDrop.currentDragIndex] = DragNDrop.currentDrag;
                }
                else
                {
                    Debug.Log("You swapped an item!");
                    //switches the item in selected slot to the dragged item's original slot
                    DragNDrop.homeSlot.parentInventory.inventory[DragNDrop.currentDragIndex] = selectedItem;
                    //then places the dragged item to the selected slot
                    DragNDrop.currentSlot.parentInventory.inventory[DragNDrop.selectedSlotIndex] = DragNDrop.currentDrag;
                }
            }

            DragNDrop.ResetDrag();
            UpdateDisplay();
        }
    }
    #endregion

    #region Pointer/Cursor Events
    public void OnPointerEnter(PointerEventData eventData)
    {
        //lets unity know the cursor has entered the inventory slot
        SlotHandler currentHandler = eventData.pointerCurrentRaycast.gameObject.GetComponent<SlotHandler>();
        currentHandler.SlotEvent();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SlotHandler currentHandler = eventData.pointerCurrentRaycast.gameObject.GetComponent<SlotHandler>();
        currentHandler.SlotEvent();
        currentHandler.SlotEventOrigin();
        DragDropEvent();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //if we drag and drop the dragged item outside of an inventory
        if (eventData.pointerCurrentRaycast.gameObject == null)
        {
            Debug.Log("You cannot place an item there!");

            //puts the dragged item back to its original slot
            DragNDrop.homeSlot.parentInventory.inventory[DragNDrop.currentDragIndex] = DragNDrop.currentDrag;

            //resets displays
            DragNDrop.ResetDrag();
            UpdateDisplay();
        }
        else
        {
            SlotHandler currentHandler = eventData.pointerCurrentRaycast.gameObject.GetComponent<SlotHandler>();
            currentHandler.SlotEvent();
            PlaceItem();
            currentHandler.parentInventory.UpdateDisplay();
        }
    }
    #endregion

    private void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<SlotHandler>().slotValue = i;
            slots[i].GetComponent<SlotHandler>().parentInventory = this;
        }

        UpdateDisplay();
    }
}
