using UnityEngine;

public class Load : MonoBehaviour
{
	private Player player;
	private GameManager gameManager;
	private Floors floors;

	void Awake ()
	{
		DontDestroyOnLoad (this);

		player = FindObjectOfType<Player> ();
		DontDestroyOnLoad (player);

		gameManager = FindObjectOfType<GameManager> ();
		DontDestroyOnLoad (gameManager);

		floors = FindObjectOfType<Floors> ();
		DontDestroyOnLoad (floors);
	}

	void Start ()
	{     
		GameManager.Shop ();
	}

	public void Reboot ()
	{
		Destroy (player.gameObject);
		Destroy (gameManager.gameObject);
		Destroy (floors.gameObject);
		Destroy (gameObject);
		GameManager.Load ();
	}
}
