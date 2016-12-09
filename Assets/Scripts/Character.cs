using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    public Text hat;
    public Text shield;
    public Text weapon;
			
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
	
	void Start() {
		SceneManager.LoadSceneAsync("CharacterHUD", LoadSceneMode.Additive);
	}
	
	void Update() {
		hat.text = "Hat: " + player.hat.name;
		shield.text = "Shield: " + player.shield.name;
		weapon.text = "Weapon: " + player.weapon.name; 	
	}
	
	public void Back() {
		SceneManager.LoadScene("Main");
	}

}
