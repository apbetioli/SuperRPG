using UnityEngine;
using System.Collections;

public class MonoPlayer : MonoBehaviour {

	private float velocity = 1f;
	private Vector3 target;
	private Player player;
	private bool colliding = false;

	void Start() {
		player = GameManager.Player;
		target = transform.position;
	}

	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target, velocity * Time.deltaTime);
	}

	public void Walk(Vector3 target) {
		this.target = target;
	}

	public void Attack(MonoRat rat) {
		if (colliding) {
			Debug.Log ("Attacking " + rat.name);
			player.Attack (rat.Rat);
			Debug.Log ("Player " + player.Health + " - Rat " + rat.Rat.GetHealth());
			if (rat.Rat.IsDead ()) {
				DestroyImmediate (rat.gameObject);
				colliding = false;
			}
			if (player.IsDead())
				DestroyImmediate (this.gameObject);
		} else {
			Walk (rat.transform.position);
		}
	}

	public void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Enemy")) {
			target = transform.position;
			colliding = true;
		}
	}

}
