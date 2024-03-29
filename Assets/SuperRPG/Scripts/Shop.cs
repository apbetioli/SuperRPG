﻿using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	public GameObject prefab;
	public Button[] buttons;

	private GameManager gameManager;

	void Awake ()
	{
		gameManager = GameManager.Instance;
	}

	void Start ()
	{
		FloatingTextController.Initialize ();
		CreateItems ();
	}

	private void CreateItems ()
	{
		Floor floor = gameManager.CurrentFloor;
		Item[] items = floor.items;
	
		for (int i = 0; i < items.Length; i++) {
			Item item = items [i];
			Button button = buttons [i];
			button.GetComponentsInChildren<Text> () [0].text = item.price.ToString ();
			button.GetComponentsInChildren<Text> () [1].text = item.name.ToString() + " ( " + item.Stats () + ")";
			button.GetComponentInChildren<Equip> ().item = item;
			if (item.sprite)
				button.GetComponentInChildren<Image> ().sprite = item.sprite;
			button.transform.parent.gameObject.SetActive (true);
		}
	}

	public void Battle ()
	{
		GameManager.Battle ();
	}

	public void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			FindObjectOfType<Load> ().Reboot ();
			return;
		}
	}

}
