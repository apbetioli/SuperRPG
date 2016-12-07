using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;
    int slotAmount;

    public List<ItemDTO> items = new List<ItemDTO>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();

        slotAmount = 18;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new ItemDTO());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }

        AddItemDTO(0);
        AddItemDTO(1);
        AddItemDTO(1);
        AddItemDTO(1);
        AddItemDTO(1);
    }


    public void AddItemDTO(int id)
    {
        ItemDTO itemDTOToAdd = database.FetchItemDTOByID(id);

        if (itemDTOToAdd.Stackable && CheckIfItemIsInInventory(itemDTOToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemDTOToAdd;
                    GameObject itemDTOObj = Instantiate(inventoryItem);
                    itemDTOObj.GetComponent<ItemData>().itemDTO = itemDTOToAdd;
                    itemDTOObj.GetComponent<ItemData>().amount = 1;
                    itemDTOObj.GetComponent<ItemData>().slot = i;
                    itemDTOObj.transform.SetParent(slots[i].transform);
                    itemDTOObj.transform.position = Vector2.zero;
                    itemDTOObj.GetComponent<Image>().sprite = itemDTOToAdd.Sprite;
                    itemDTOObj.name = itemDTOToAdd.Title;
                    break;
                }
            }
        }
    }

    bool CheckIfItemIsInInventory(ItemDTO item)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i].ID == item.ID)
                return true;
        return false;
    }
}
