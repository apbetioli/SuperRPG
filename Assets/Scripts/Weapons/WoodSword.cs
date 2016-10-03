using UnityEngine;
using System.Collections;

public class WoodSword : ScriptableObject, Weapon {
	
	public int Damage(){
		return 1;
	}

	public void Equip (Player player){
		player.GetInventory().Weapon = this;
	}

	public string Texto(){
		return "uma Espada de madeira";
	}
}
