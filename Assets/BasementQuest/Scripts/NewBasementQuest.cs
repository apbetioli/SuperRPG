using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class NewBasementQuest : MonoBehaviour
{
	public float secondsToAttack = 1f;

	public MonoPlayer player;
	public List<MonoRat> rats =  new List<MonoRat>();

	private int remaining;

	void Start ()
	{
		Time.timeScale = 1;
		GameManager.Player.Weapon = new WoodenSword ();
		remaining = rats.Count;
		InvokeRepeating ("Battle", 0f, secondsToAttack);
	}

	public void Battle ()
	{	
		if (remaining == 0) {
			Debug.Log ("Yooo");
			Time.timeScale = 0;
			return;
		}
		if (player.IsDead ()) {
			Debug.Log ("Noooo");
			Time.timeScale = 0;
			return;
		}

		foreach (MonoRat rat in rats) {
			if (!rat.IsDead ()) {				
				player.Attack (rat);
				if (rat.IsDead ())
					remaining--;
				break;
			}
		}
	}

}
