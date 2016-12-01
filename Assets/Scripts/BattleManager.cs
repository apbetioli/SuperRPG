using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {

	public GameObject playerGO;
	public GameObject[] enemiesGO;
	private Player player;
	private Queue<Enemy> enemies = new Queue<Enemy>();
	private Enemy currentEnemy;
	private bool winner = false;

	void Awake(){
		player = playerGO.GetComponent<Player> ();
			foreach(GameObject enemyGO in enemiesGO){
				enemies.Enqueue(enemyGO.GetComponent<Enemy> ());
			}
	}
	void Start(){
		
		currentEnemy = enemies.Dequeue();
		Debug.Log ("Quest iniciada");
		Debug.Log ("Player health: " + player.health);
		Debug.Log ("Enemy health: " + currentEnemy.health);
	}

	public void Attack(){
		StartCoroutine (CoolDown ());
	}

	public bool PlayerWin(){
		return winner;
	}

	public bool PlayerDead(){
		winner = false;
		return player.IsDead ();
	}

	IEnumerator CoolDown(){		
		Debug.Log ("Wait x1: " + Time.time);
		currentEnemy.TakeDamage (player.attack);
		Debug.Log ("Enemy health: " + currentEnemy.health);		

		if(enemies.Count == 0 && currentEnemy.IsDead()){
			winner = true;
		 	yield break;
		}

		if(enemies.Count > 0 && currentEnemy.IsDead()){
			currentEnemy = enemies.Dequeue();
			yield break;
		}

		yield return new WaitForSeconds(2);

		Debug.Log ("Wait x2: " + Time.time);
		player.TakeDamage (currentEnemy.attack);
		Debug.Log ("Player health: " + player.health);

		
		
	
	}

}
