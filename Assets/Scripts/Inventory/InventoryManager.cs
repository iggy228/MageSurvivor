using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Item[] startItems;

    public InventorySlot[] inventorySlots;

    public GameObject inventoryItemPrefab;

    /// <summary>
    /// Indicates which inventory slot is selected (index in inventorySlots array).
    /// If number is -1 no slot is selected
    /// </summary>
    int selectedSlot = -1;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeSelectedSlot(0);
        foreach (Item item in startItems)
        {
            AddItem(item);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown(InputKeysNames.Weapon1))
        {
            ChangeSelectedSlot(0);
        }
        else if (Input.GetButtonDown(InputKeysNames.Weapon2))
        {
            ChangeSelectedSlot(1);
        }
        else if (Input.GetButtonDown(InputKeysNames.Weapon3))
        {
            ChangeSelectedSlot(2);
        }
        else if (Input.GetButtonDown(InputKeysNames.Weapon4))
        {
            ChangeSelectedSlot(3);
        }
        else if (Input.GetButtonDown(InputKeysNames.Weapon5))
        {
            ChangeSelectedSlot(4);
        }
    }

    public void ChangeSelectedSlot(int newVal)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }

        inventorySlots[newVal].Select();
        selectedSlot = newVal;
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.itemParent);
        newItemGo.GetComponent<InventoryItem>().InitialiseItem(item);
    }

    public Item GetSelectedItem()
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            return itemInSlot.item;
        }
        return null;
    }
}
