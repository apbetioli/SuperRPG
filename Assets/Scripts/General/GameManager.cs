using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager
{
	private static Player player;

	public static Player Player {
		get {
			if(player == null)
				player = new Player ();
			return player;
		}
	}

}
