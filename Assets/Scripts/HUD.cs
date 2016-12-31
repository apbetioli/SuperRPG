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
    public Slider healthBar;

    private Player player;
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameManager.Instance;
        player = Player.Instance;
    }

    void Start()
    {
        healthBar.value = CalculateHealth();
    }

    void Update()
    {
        healthBar.value = CalculateHealth();
    }

    public void OnGUI()
    {
        health.text = player.health.ToString() + "/" + player.maxHealth.ToString();

        weapon.text = player.damage.ToString();
        weaponImage.sprite = player.weapon.sprite;

        shield.text = player.defense.ToString();
        shieldImage.sprite = player.shield.sprite;

        coins.text = player.coins.ToString();

		if(gameManager.CurrentFloor != null)
        	floor.text = gameManager.CurrentFloor.name;
    }

    float CalculateHealth()
    {
        return ((float)player.health) / ((float)player.maxHealth);
    }
}
