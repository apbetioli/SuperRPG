using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Text health;
    public Text stamina;
    public Text attack;
    public Text defense;
	
	private Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player not found");
            this.enabled = false;
        }
    }

    public void Update()
    {
        health.text = "Health: " + player.health;
        stamina.text = "Stamina: " + player.GetUsedStamina() + " / " + player.stamina;
        attack.text = "Attack: " + player.attack;
        defense.text = "Defense: " + player.defense;
    }
}
