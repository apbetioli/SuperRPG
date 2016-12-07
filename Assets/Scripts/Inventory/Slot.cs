using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{

    public int id;
    private Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (inventory.items[id].ID == -1)
        {
            inventory.items[droppedItem.slot] = new ItemDTO();
            inventory.items[id] = droppedItem.itemDTO;
            droppedItem.slot = id;
        }
        else if (droppedItem.slot != id)
        {
            Transform item = this.transform.GetChild(0);
            item.GetComponent<ItemData>().slot = droppedItem.slot;
            item.transform.SetParent(inventory.slots[droppedItem.slot].transform);
            item.transform.position = inventory.slots[droppedItem.slot].transform.position;

            droppedItem.slot = id;
            droppedItem.transform.SetParent(this.transform);
            droppedItem.transform.position = this.transform.position;

            inventory.items[droppedItem.slot] = item.GetComponent<ItemData>().itemDTO;
            inventory.items[id] = droppedItem.itemDTO;
        }
    }
}
