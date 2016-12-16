using UnityEngine;

public class Load : MonoBehaviour
{

    private Player player;
    private GameObject Inventory;

    public void Awake()
    {
        player = FindObjectOfType<Player>();
        DontDestroyOnLoad(player);
    }

}
