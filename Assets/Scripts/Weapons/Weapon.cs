using UnityEngine;
using System.Collections;

public abstract class Weapon : Equipable {

	public abstract int Damage();

	public abstract string Texto ();

	public void Equip (Player player){
		player.GetInventory().Weapon = this;
	}
}
