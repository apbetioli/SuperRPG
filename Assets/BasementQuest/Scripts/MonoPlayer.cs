using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class MonoPlayer : MonoBehaviour {

	public float velocity = 1f;
	public Slider playerHealthBar;

	private Vector3 target;
	private Player player;
	private bool colliding = false;

	void Start() {
		player = GameManager.Player;
		playerHealthBar.maxValue = player.Health;
		playerHealthBar.value = player.Health;
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
			rat.EnableHealthBar ();
			Debug.Log ("Attacking " + rat.name);
			player.Attack (rat.Rat);
			Debug.Log ("Player " + player.Health + " - Rat " + rat.Rat.GetHealth());
			RefreshHealthBar ();
			rat.RefreshHealthBar ();
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

	public bool IsDead() {
		return player.IsDead ();
	}

	private void RefreshHealthBar(){
		playerHealthBar.value = player.Health;
	}
}
