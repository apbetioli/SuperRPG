using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class BasementQuest : MonoBehaviour
{
	public float secondsToAttack = 1f;

	private BasementQuestManager questManager;
	private float wait;
	private Player player;

	void Awake ()
	{		
		questManager = new BasementQuestManager ();	
		player = GameManager.Player;
	}

	void Start ()
	{
		InvokeRepeating ("Battle", 0f, secondsToAttack);
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (0, 0, 100, 50), "Voltar ao mapa")) {
			SceneManager.LoadScene ("Scenes/Map");
		}

		if (!questManager.IsThereEnemiesAlive ()) {
			GUI.Label (new Rect (0, 50, 500, 20), "Parabéns você matou todos os ratos do porão!");
			return;
		}

		if (!player.IsDead ())
			GUI.Label (new Rect (300, 0, 500, 20), "Sua vida: " + player.Health);
		else
			GUI.Label (new Rect (300, 0, 500, 20), "Que pena, você está morto");
		
		string ratos = "";
		for (int i = 0; i < questManager.GetNumberOfEnemiesAlive (); i++) {
			string add = "    rato";
			if (i + 1 == questManager.GetNumberOfEnemiesAlive ())
				add = "    rato--ó/";
			ratos += add;
		}
		GUI.Label (new Rect (0, 200, 1000, 20), ratos);


		if (questManager.IsThereEnemiesAlive ())
			GUI.Label (new Rect (0, 240, 500, 20), "Vida do rato atual: " + questManager.GetCurrentEnemyHealth ());
		
		GUI.Label (new Rect (0, 220, 500, 20), "Número de ratos: " + questManager.GetNumberOfEnemiesAlive ());

	}

	public void Battle ()
	{	
		Debug.Log ("Battle");

		try {
			questManager.Battle (player);
		} catch (Exception ex) {
			Debug.LogError (ex);
		}
	}
}
