using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	static Player instance;
	protected Inventory inventory;

	void Start(){		
		if(instance != null) {			
			Destroy(this.gameObject);
			return;
		}

		instance = this;
		inventory = ScriptableObject.CreateInstance("Inventory") as Inventory;
		GameObject.DontDestroyOnLoad( this.gameObject );
	}

	public static Player GetInstance() {
		return instance;
	}

	public Inventory GetInventory(){
		return inventory;
	}
}
