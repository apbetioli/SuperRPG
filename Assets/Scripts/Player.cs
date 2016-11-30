using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float health = 100;
	public float stamina = 10;

	public float attack {
		get {
			return weapon.attackValue;
		}
	}

	public float defense {
		get {
			return shield.defenseValue;
		}
	}

	public Weapon weapon;
	public Shield shield;
	public Hat hat;

	public float GetUsedStamina() {
		return weapon.stamina + shield.stamina + hat.stamina;
	}

	public bool CanEquipWeapon(Weapon weapon) {
		return GetUsedStamina () - this.weapon.stamina - weapon.stamina < stamina;
	}
}
