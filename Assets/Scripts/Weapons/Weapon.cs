using UnityEngine;
using System.Collections;

public abstract class Weapon : Item {

	public abstract int Damage();

	public abstract string Texto();

	public string Name(){
		return "";
	}

}
