using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {

	public GameObject playerGO;
	public GameObject enemyGO;
	private Player player;
	private Enemy enemy;

	void Start(){
		player = playerGO.GetComponent<Player> ();
		enemy = enemyGO.GetComponent<Enemy> ();
		Debug.Log ("Quest iniciada");
		Debug.Log ("Player health: " + player.health);
		Debug.Log ("Enemy health: " + enemy.health);
	}

	public void Attack(){
		StartCoroutine (CoolDown ());
	}

	public bool PlayerWin(){
		return enemy.IsDead ();
	}

	public bool PlayerDead(){
		return player.IsDead ();
	}

	IEnumerator CoolDown(){		
		Debug.Log ("Wait x1: " + Time.time);
		enemy.TakeDamage (player.attack);
		Debug.Log ("Enemy health: " + enemy.health);

		yield return new WaitForSeconds(2);

		Debug.Log ("Wait x2: " + Time.time);
		player.TakeDamage (enemy.attack);
		Debug.Log ("Player health: " + player.health);
	}
}
