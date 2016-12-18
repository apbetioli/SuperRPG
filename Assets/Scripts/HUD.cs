using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	public Text health;
    public Text coins;
    public Text damage;
    public Text defense;
	public Text weapon;
	public Text shield;
	public Text floor;
	
	private Player player;
	private GameManager gameManager;

    void Awake()
    {
		gameManager = GameManager.Instance;
		player = Player.Instance;
    }

    public void OnGUI()
    {
		coins.text = "Coins: " + player.coins;
		damage.text = "Damage: " + player.damage;
        defense.text = "Defense: " + player.defense;
		weapon.text = "Weapon: " + player.weapon.name;
		shield.text = "Shield: " + player.shield.name;
		health.text = "Health: " + player.health + "/" + player.maxHealth;
		floor.text = "Floor: " + gameManager.CurrentFloor.name;
    }
}
