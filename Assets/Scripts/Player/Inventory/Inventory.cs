using UnityEngine;
using System.Collections;

public class Inventory : ScriptableObject {

	private Weapon weapon;

	public Weapon Weapon{
		get{ 
			return weapon;
		}

		set{ 
			weapon = value;
		}
	}
}
