using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
	public Item item;
	public AudioSource buySound;
	public AudioSource cantBuySound;

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
		if (player.DoEquip (item)) {
			if (buySound != null)
				buySound.Play ();
		} else {
			if (cantBuySound != null)
				cantBuySound.Play ();
		}
	}
}
