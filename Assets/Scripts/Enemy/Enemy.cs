using UnityEngine;
using System.Collections;

public class Enemy : ScriptableObject, Killable {

	int health = 2;
	int damage = 0;

	public void TakesDamage(int damage){
		health -= damage;
	}


	public int GetHealth(){
		return health;
	}

}
