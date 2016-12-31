using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
	public Item item;

	private Player player;

	void Awake ()
	{
		player = Player.Instance;
	}

	public void DoEquip ()
	{
		if (item == null) {
			Debug.LogError ("No item set to equip");
			return;
		}
		player.DoEquip (item);
	}
}
