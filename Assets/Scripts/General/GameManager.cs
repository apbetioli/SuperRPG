using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	private static Player player;

	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{
		player = new Player ();
		GameObject.DontDestroyOnLoad (this.gameObject);
	}

	public static GameManager GetInstance ()
	{
		if (instance == null)
			instance = GameObject.FindObjectOfType<GameManager> ();
		return instance;
	}

	public Player Player {
		get {
			return player;
		}
	}
}
