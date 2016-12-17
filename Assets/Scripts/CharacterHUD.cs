using UnityEngine;
using UnityEngine.UI;

public class CharacterHUD : MonoBehaviour
{
    public Text coins;
    public Text damage;
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

    public void OnGUI()
    {
		coins.text = "Coins: " + player.coins;
		damage.text = "Damage: " + player.damage;
        defense.text = "Defense: " + player.defense;
    }
}
