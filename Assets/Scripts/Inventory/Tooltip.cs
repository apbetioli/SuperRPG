using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{

    private ItemDTO itemDTO;
    private string data;
    private GameObject tooltip;

    public void Start()
    {
        tooltip = GameObject.Find("Tooltip");
        tooltip.SetActive(false);
    }

	void Update(){
		if(tooltip.activeSelf){
			tooltip.transform.position = Input.mousePosition;
		}
	}

    public void Activate(ItemDTO itemDTO)
    {
        this.itemDTO = itemDTO;
        ConstructDataString();
        tooltip.SetActive(true);
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        data = "<color=#0473f0><b>"+itemDTO.Title + "</b></color>";
		tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
