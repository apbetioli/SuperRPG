using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{

    public ItemDTO itemDTO;
    public int amount;
    public int slot;
    private Vector2 offset;
    private Inventory inventory;
    private Tooltip tooltip;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        tooltip = inventory.GetComponent<Tooltip>();
    }


    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if (itemDTO != null)
        {
            // offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - offset;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (itemDTO != null)
        {
            this.transform.position = eventData.position - offset;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(inventory.slots[slot].transform);
        this.transform.position = inventory.slots[slot].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (itemDTO != null)
        {
            offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        tooltip.Activate(itemDTO);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        tooltip.Deactivate();
    }
}
