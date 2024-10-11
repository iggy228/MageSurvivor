using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector]
    public Transform parentAfterDrag;
    [HideInInspector]
    public Vector2 positionAfterDrag;

    [SerializeField]
    private Image icon;

    public SpellSlotUI spellSlotUI;

    private void Awake()
    {
        if (icon == null)
        {
            icon = GetComponent<Image>();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        positionAfterDrag = transform.position;
        // should be canvas
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        // turn off raycasting for icon
        icon.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        transform.position = positionAfterDrag;

        // turn on raycasting for icon
        icon.raycastTarget = true;
    }

    public void SetIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
