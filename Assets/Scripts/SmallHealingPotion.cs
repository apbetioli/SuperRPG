using UnityEngine;
public class SmallHealingPotion : Item
{

    public int healingRecovery;
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

    public void Purchase()
    {
		player.lifePotions.Enqueue(this);
    }

}
