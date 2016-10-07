using UnityEngine;
using System.Collections;

public class WoodenSword : Weapon {
	
	public override int Damage() {
		return 5;
	}

	public override string Texto() {
		return "uma Espada de madeira";
	}
}
