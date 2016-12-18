﻿using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
	public GameObject buttonAndTextPrefab;

	private Canvas canvas;
	private GameManager gameManager;

    void Awake()
	{
		gameManager = GameManager.Instance;
		canvas = FindObjectOfType<Canvas> ();
	}

	void Start() {
		LoadScenes ();
		CreateItems ();
	}

	private void CreateItems() {
		Floor floor = gameManager.CurrentFloor;
		Item[] items = floor.items;
		for (int i = 0; i < items.Length; i++) {
			Item item = items [i];

			GameObject bat = GameObject.Instantiate (buttonAndTextPrefab);
			bat.GetComponentInChildren<Text>().text = item.name + " $" + item.price + "";
			bat.GetComponentInChildren<Equip> ().item = item;
			if(item.sprite)
				bat.GetComponentInChildren<Image> ().sprite = item.sprite;
			bat.transform.SetParent(canvas.transform);
			bat.transform.localPosition = new Vector3(100, 200-i*50, 0);
		}
	}

	private void LoadScenes() {
		GameManager.HUD ();
    }

    public void LoadBasement()
    {
		GameManager.Battle ();
    }

}