//using UnityEngine;
//using System.Collections;
using System;

public class Inventory/* : ScriptableObject */{

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
