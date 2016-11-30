using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float attack;
	private float defense;
	public float health;
	private float stamina;

	public Player(){
		attack = 5;
		defense = 0;
		health = 100;
		stamina = 10;
	}

	public void TakeDamage(float damage){
		health -= damage;
	}

	public bool IsDead(){
		return health <= 0;
	}
}
