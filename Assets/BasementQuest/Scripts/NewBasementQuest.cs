using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class NewBasementQuest : MonoBehaviour
{
	public float secondsToAttack = 1f;
	public MonoRat monoRatPrefab;
	public int numberOfRats = 4;
	public MonoPlayer monoPlayer;

	private BasementQuestManager questManager;
	private float wait;
	private Player player;

	private List<MonoRat> rats =  new List<MonoRat>();

	void Awake ()
	{		
		questManager = new BasementQuestManager (numberOfRats);	
		player = GameManager.Player;

		int x = 0;
		foreach (Enemy rat in questManager.Enemies) {
			MonoRat monoRat = GameObject.Instantiate (monoRatPrefab);
			monoRat.Rat = rat as Rat;
			monoRat.transform.position = new Vector3 (x, 0, 0);
			rats.Add (monoRat);
			x += 2;
		}	

	}

	void Start ()
	{
		InvokeRepeating ("Battle", 0f, secondsToAttack);

	}

	public void Battle ()
	{	
		monoPlayer.Attack(NextRat());

		/*
		try {
			questManager.Battle (player);
		} catch (Exception ex) {
			Debug.LogError (ex);
		}
		*/
	}

	public MonoRat NextRat() {
		foreach (MonoRat rat in rats) {
			if(!rat.Rat.IsDead()) {
				return rat;
			}
		}
		return null;
	}
}
