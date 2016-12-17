using UnityEngine;

public class Load : MonoBehaviour
{
    private Player player;

    public void Awake()
    {
        player = FindObjectOfType<Player>();
        DontDestroyOnLoad(player);
    }

}
