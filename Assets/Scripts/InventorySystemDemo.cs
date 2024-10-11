using UnityEngine;

public class InventorySystemDemo : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        inventoryManager.AddItem(itemsToPickup[id]);
    }
}
