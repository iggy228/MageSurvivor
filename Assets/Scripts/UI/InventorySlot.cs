using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Transform itemParent;

    public Image image;
    public Sprite selectedBorderSprite;
    public Sprite notSelectedBorderSprite;

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        image.sprite = selectedBorderSprite;
    }

    public void Deselect()
    {
        image.sprite = notSelectedBorderSprite;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (itemParent.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = itemParent;
        }
    }
}
