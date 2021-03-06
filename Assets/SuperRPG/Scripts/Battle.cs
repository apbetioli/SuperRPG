﻿using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
	public Text currentEnemyText;
	public Text turnText;
	public Text damageText;
	public Text defenseText;
	public Text coinsText;
	public Text healthText;
	public Slider healthBar;

	private BattleManager manager;

	void Awake ()
	{
		manager = FindObjectOfType<BattleManager> ();
	}

	void OnGUI ()
	{
		if (manager.currentEnemy != null) {
			currentEnemyText.text = manager.currentEnemy.name;
			damageText.text = manager.currentEnemy.damage.ToString ();
			defenseText.text = manager.currentEnemy.defense.ToString ();
			coinsText.text = manager.currentEnemy.coins.ToString ();
			healthText.text = manager.currentEnemy.health.ToString () + "/" + manager.currentEnemy.maxHealth.ToString ();
			healthBar.value = CalculateHealth ();
		}

		turnText.text = manager.GetTurnDescription ();
	}

	public void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			GameManager.Run ();
			return;
		}
	}

	public void Run ()
	{
		GameManager.Run ();
	}

	private float CalculateHealth ()
	{
		return  ((float)manager.currentEnemy.health) / ((float)manager.currentEnemy.maxHealth);
	}

}
