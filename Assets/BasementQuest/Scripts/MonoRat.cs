using UnityEngine;
using System.Collections;

public class MonoRat : MonoBehaviour
{

	private Rat rat;

	public void Awake() {
		rat = new Rat ();
	}

	public bool IsDead() {
		return rat.IsDead ();
	}

	public Rat Rat {
		set { 
			rat = value;
		}

		get { 
			return rat;
		}
	}
}
