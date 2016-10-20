using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager
{
	private static GameManager instance;
	private static Player player;

	public static GameManager GetInstance ()
	{
		if (instance == null)
			instance = new GameManager ();
		return instance;
	}

	public Player Player {
		get {
			if(player == null)
				player = new Player ();
			return player;
		}
	}

}
