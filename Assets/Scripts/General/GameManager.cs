using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	static GameManager instance;
	static Character character;

	void Start(){		
		if(instance != null) {			
			Destroy(this.gameObject);
			return;
		}

		instance = this;
		character = new Character ();

		GameObject.DontDestroyOnLoad( this.gameObject );
	}

	public static GameManager GetInstance() {
		return instance;
	}


	public Character GetPlayer() {
		return character;
	}
}
