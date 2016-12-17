using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
	public Enemy[] enemies;

	public void Reset() {
		enemies = GetComponentsInChildren<Enemy>();
	}
		
	public void OnEnable() {
		Reset ();
	}
}
