using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	static GameManager instance;

	List<Killable> enemies;

	void Start(){		
		if(instance != null) {			
			Destroy(this.gameObject);
			return;
		}

		instance = this;

		GameObject.DontDestroyOnLoad( this.gameObject );
	}

	public static GameManager GetInstance() {
		return instance;
	}

	public void MakeEnemies(){
		enemies = new List<Killable> ();
		for (int i=0; i<10; i++)
			enemies.Add(new Rat());
	}

	public List<Killable> GetEnemies(){
		return enemies;
	}
}
