using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text health;
	
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

    public void OnGUI()
    {
        health.text = "Health: " + player.health;
    }
}
