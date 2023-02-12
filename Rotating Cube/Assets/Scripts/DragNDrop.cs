using UnityEngine;
using UnityEngine.UI;

public class DragNDrop : MonoBehaviour
{
    //static reference to the current item we are dragging
    public static Item currentDrag;
    public static SlotHandler currentSlot;
    //the slot from the which the item came from
    public static SlotHandler homeSlot;
    public static int currentDragIndex;
    public Image getComponentImage;
    public static Image dragImage;
    public static int selectedSlotIndex;

    public static void UpdateDrag()
    {
        //sets the sprite following the mouse to the sprite icon of the item
        dragImage.sprite = currentDrag.icon;
    }

    public static void ResetDrag()
    {
        //clears the sprite of the current item
        currentDrag = null;
        //turn off the image following the mouse
        dragImage.gameObject.SetActive(false);
        //clear current slot
        currentSlot = null;
    }

    private void Start()
    {
        dragImage = getComponentImage;        
    }

    private void Update()
    {
        //if we are dragging the item ... if an item is connected
        if (currentDrag != null)
        {
            if (dragImage.gameObject.activeSelf == false)
            {
                dragImage.gameObject.SetActive(true);
                dragImage.transform.position = Input.mousePosition;
            }
        }
    }
}
