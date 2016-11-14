using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonoRat : MonoBehaviour
{
	public Slider enemyHealthBar;
	private Rat rat;

	public void Awake() {
		rat = new Rat ();
		enemyHealthBar.maxValue = rat.GetHealth ();
		enemyHealthBar.value = rat.GetHealth ();
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

	public void EnableHealthBar(){
		enemyHealthBar.gameObject.SetActive (true);
	}

	public void RefreshHealthBar(){
		enemyHealthBar.value = rat.GetHealth();
	}
}
