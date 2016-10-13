using System;
using UnityEngine;

public class QuestManager
{
	
	public float secondsToAttack = 2;
	EnemyManager enemyManager;
	Character player;
	float wait;

	public QuestManager (EnemyManager enemyManager, Character player)
	{
		this.enemyManager = enemyManager;
		this.player = player;
		wait = secondsToAttack;
	}

	public void StartQuest ()
	{	
		while (enemyManager.GetNextEnemy () != null && wait <= Time.deltaTime) {
			player.attack (enemyManager.GetNextEnemy ());
			wait = secondsToAttack;
		}
		wait -= Time.deltaTime;
	}
}


