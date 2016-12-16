using UnityEngine;
using UnityEngine.SceneManagement;

public class Equip : MonoBehaviour
{
    public Weapon weapon;

    private Player player;

    void Awake()
    {
        //FindPlayer();
    }

    public void Start()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        player = FindObjectOfType<Player>();
        if (player == null)
        {
            Debug.LogError("Player not found");
            this.enabled = false;
        }
    }

    public void DoEquip()
    {
        if (player.CanEquipWeapon(weapon))
        {
            player.weapon = weapon;
            DontDestroyOnLoad(weapon);
        }
    }
}
