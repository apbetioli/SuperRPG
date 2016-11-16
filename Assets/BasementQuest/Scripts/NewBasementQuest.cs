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
	private bool finishedQuest= false;

	void Start ()
	{
		Time.timeScale = 1;
		GameManager.Player.Weapon = new WoodenSword ();
		remaining = rats.Count;
		InvokeRepeating ("Battle", 0f, secondsToAttack);
	}

	void OnGUI(){
		if (finishedQuest) 
			GUI.Label (new Rect (0, 50, 500, 20), "Parabéns você matou todos os ratos do porão!");	
	}

	public void Battle ()
	{	
		if (remaining == 0) {
			Debug.Log ("Yooo");
			Time.timeScale = 0;
			finishedQuest = true;
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
