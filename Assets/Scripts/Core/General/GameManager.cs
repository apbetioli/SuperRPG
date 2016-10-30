using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager
{
	private static Player player;

	private static Shop shop;

	public static Player Player {
		get {
			if(player == null)
				player = new Player ();
			return player;
		}
	}

	public static Shop Shop {
		get {
			if(shop == null)
				shop = new Shop ();
			return shop;
		}
	}
}
