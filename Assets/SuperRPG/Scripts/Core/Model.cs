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
	}

	public void Destroy() {
		Destroy (gameObject);
	}

}
