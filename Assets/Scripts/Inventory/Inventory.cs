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

    public List<InventoryItem> items = new List<InventoryItem>();
    public List<GameObject> slots = new List<GameObject>();

    private Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player not found");
            this.enabled = false;
        }
    }
    void Start()
    {
        database = GetComponent<ItemDatabase>();

        slotAmount = 18;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new InventoryItem());
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<Slot>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }
    }


    public void AddItem(int id)
    {

        InventoryItem itemToAdd = database.FetchItemDTOByID(id);

        if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
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
                    items[i] = itemToAdd;
                    GameObject itemDTOObj = Instantiate(inventoryItem);
                    itemDTOObj.GetComponent<ItemData>().item = itemToAdd;
                    itemDTOObj.GetComponent<ItemData>().amount = 1;
                    itemDTOObj.GetComponent<ItemData>().slot = i;
                    itemDTOObj.transform.SetParent(slots[i].transform);
                    itemDTOObj.transform.position = slots[i].transform.position;
                    itemDTOObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemDTOObj.name = itemToAdd.Title;
                    break;
                }
            }
        }
    }

    bool CheckIfItemIsInInventory(InventoryItem item)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i].ID == item.ID)
                return true;
        return false;
    }
}
