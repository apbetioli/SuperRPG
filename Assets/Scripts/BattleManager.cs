using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {

	private Player player;
	private Enemy enemy;

	public BattleManager(Player player, Enemy enemy){
		this.player = player;
		this.enemy = enemy;
	}

	public void Attack(){
		enemy.TakeDamage (player.attack);
		player.TakeDamage (enemy.attack);

		Debug.Log ("Status pós ataque: " + Time.deltaTime);
		Debug.Log ("Player health: " + player.health);
		Debug.Log ("Enemy health: " + enemy.health);
	}

	public bool PlayerWin(){
		return enemy.IsDead ();
	}

	public bool PlayerDead(){
		return player.IsDead ();
	}
}
