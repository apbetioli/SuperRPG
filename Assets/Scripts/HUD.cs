using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	public Text health;
	public Text stamina;
	public Text attack;
	public Text defense;

	public Player player;

	public void Update() {
		health.text = "Health: " + player.health;
		stamina.text = "Stamina: " + player.stamina;
		attack.text = "Attack: " + player.attack;
		defense.text = "Defense: " + player.defense;
	}
}
