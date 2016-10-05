using UnityEngine;
using System.Collections;

public interface Killable{

	void TakesDamage (int damage);

	int GetHealth ();
}
