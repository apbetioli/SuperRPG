using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
	[HideInInspector]
	public Enemy[] enemies;

	public void Awake() {
		enemies = GetComponentsInChildren<Enemy>();
	}
		
}
