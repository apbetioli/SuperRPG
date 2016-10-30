using UnityEngine;
using System.Collections;

public class WoodenSword : Weapon {
	
	public int Damage() {
		return 5;
	}

	public string Name(){
		return "Wooden Sword";
	}

	public string Texto() {
		return "uma Espada de madeira";
	}
}
