using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellSlotUI : MonoBehaviour, IDropHandler
{
    public GameObject draggableItemPrefab;

    public Image border;

    public Sprite activeBorder;
    public Sprite inactiveBorder;

    private DraggableItem draggableItem;

    private bool active;
    public bool Active
    {
        get { return active; }
        set
        {
            active = value;
            if (active)
            {
                border.sprite = activeBorder;
            }
            else
            {
                border.sprite = inactiveBorder;
            }
        }
    }

    public void SetIcon(Sprite sprite)
    {
        if (sprite == null)
        {
            if (draggableItem != null)
            {
                Destroy(draggableItem.gameObject);
            }
            return;
        }
        if (draggableItem == null)
        {
            draggableItem = Instantiate(draggableItemPrefab, transform).GetComponent<DraggableItem>();
            draggableItem.SetIcon(sprite);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableItem droppedDraggableItem = dropped.GetComponent<DraggableItem>();

        if (draggableItem != null)
        {
            draggableItem.transform.SetParent(droppedDraggableItem.parentAfterDrag);
            draggableItem.transform.position = droppedDraggableItem.positionAfterDrag;
        }

        droppedDraggableItem.positionAfterDrag = transform.position;
        droppedDraggableItem.parentAfterDrag = transform;

        // final step swap references for correct working
        SpellSlotUI swapSlot = droppedDraggableItem.spellSlotUI;
        DraggableItem swapItem = droppedDraggableItem;
        swapSlot.draggableItem = draggableItem;
        draggableItem = swapItem;

    }
}
