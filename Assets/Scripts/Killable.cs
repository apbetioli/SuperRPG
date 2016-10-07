using UnityEngine;
using System.Collections;

public interface Killable {

	int TakeDamage (int damage);

	int GetHealth ();
}
