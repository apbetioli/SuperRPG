using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Model : MonoBehaviour {

	private Animator animator;

	public void Awake() {
		animator = GetComponent<Animator> ();
	}

	public void Hit() {
		animator.SetTrigger ("Hit");
	}

	public void Die() {
		animator.SetTrigger ("Death");
		Destroy ();
	}

	public void Destroy() {
		DestroyImmediate (gameObject);
	}

}
