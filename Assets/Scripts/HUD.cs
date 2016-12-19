using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	public Text health;
	public Text coins;
	public Text weapon;
	public Image weaponImage;
	public Text shield;
	public Image shieldImage;
	public Text floor;
	
	private Player player;
	private GameManager gameManager;

	void Awake ()
	{
		gameManager = GameManager.Instance;
		player = Player.Instance;
	}

	public void OnGUI ()
	{
		health.text = "Health: " + player.health + "/" + player.maxHealth;
		coins.text = "Coins: $" + player.coins;

		weapon.text = player.weapon.name + " (" + player.damage + ")";
		weaponImage.sprite = player.weapon.sprite;

		shield.text = player.shield.name + " (" + player.defense + ")";
		shieldImage.sprite = player.shield.sprite;

		floor.text = gameManager.CurrentFloor.name;
	}
}
