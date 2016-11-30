using UnityEngine;
using System.Collections;

public class Equip : MonoBehaviour {

	public Player player;
	public Weapon weapon;

	public void DoEquip() {
		if (player.CanEquipWeapon (weapon)) {
			player.weapon = weapon;
		}
	}
}
