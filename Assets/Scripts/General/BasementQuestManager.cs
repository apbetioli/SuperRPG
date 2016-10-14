using System;
using System.Collections.Generic;

public class BasementQuestManager
{
	private const int numberOfRats = 10;

	private List<Enemy> enemies;
	private int currentEnemy = 0;

	public BasementQuestManager () {
		SpawnRats();
	}

	private void SpawnRats() {
		enemies = new List<Enemy> ();
		for (int i = 0; i < numberOfRats; i++)
			enemies.Add (new Rat());
	}

	public void Battle(Player player) {
		if (!IsThereEnemiesAlive())
			return;

		Enemy enemy = enemies [currentEnemy];
		player.attack (enemy);
		if (enemy.IsDead ())
			currentEnemy++;
	}

	public bool IsThereEnemiesAlive() {
		return GetNumberOfEnemiesAlive() > 0;
	}

	public int GetCurrentEnemyHealth() {
		return enemies [currentEnemy].GetHealth ();
	}

	public int GetNumberOfEnemiesAlive() {
		return enemies.Count - currentEnemy;
	}
}

