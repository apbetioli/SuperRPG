﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
	public float waitTime = 0f;
	public AudioSource hitSound;

	[HideInInspector]
	public Enemy currentEnemy;

	private Turn[] turns;
	private int currentTurnIndex = 0;

	private Player player;
	private GameManager gameManager;

	void Awake ()
	{
		gameManager = GameManager.Instance;
		if (gameManager != null)
			player = Player.Instance;
	}

	void Start ()
	{
		turns = gameManager.CurrentFloor.turns; 
		NextEnemy ();
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0))
			Attack ();
	}

	public void Attack ()
	{
		if (player.IsDead ())
			return;

		currentEnemy.TakeDamage (player.damage);

		if (hitSound != null)
			hitSound.Play ();

		if (currentEnemy.IsDead ()) {

			player.coins += currentEnemy.coins;

			currentEnemy.Die ();

			if (currentTurnIndex == turns.Length)
				NextFloor ();
			else
				NextEnemy ();
			return;
		}

		StartCoroutine (CoolDown ());
	}

	IEnumerator CoolDown ()
	{
		yield return new WaitForSeconds (waitTime);
		player.TakeDamage (currentEnemy.damage);

		if (player.IsDead ())
			GameManager.GameOver (currentEnemy);
	}

	public void NextFloor ()
	{
		gameManager.NextFloor ();
	}

	private void NextEnemy ()
	{
		Turn currentTurn = turns [currentTurnIndex];

		float rand = Random.Range (0f, 100f) / 100f;

		Enemy chosen = currentTurn.enemies [0];
		float sum = 0f;
		foreach (Enemy enemy in currentTurn.enemies) {
			sum += enemy.probability;
			chosen = enemy;
			if (rand < sum) {
				break;
			}
		}

		currentEnemy = chosen;

		currentTurnIndex++;

		InstantiateEnemy ();
	}

	public void InstantiateEnemy() {
		currentEnemy.transform.position = new Vector3(0, 3, 0);

		if (currentTurnIndex % 2 == 0)
			currentEnemy.transform.localScale = new Vector3 (-10, 10, 10);
		else
			currentEnemy.transform.localScale = new Vector3 (10, 10, 10);
	}

	public string GetTurnDescription ()
	{
		return "Turn " + currentTurnIndex + "/" + turns.Length;
	}
}
