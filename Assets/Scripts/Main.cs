using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
	
	void Awake() {
        Player player = FindObjectOfType<Player>();
        if(player == null)
		    SceneManager.LoadScene("Load", LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
	}
	
    public void LoadCharacter()
    {
        SceneManager.LoadScene("Character");
    }

    public void LoadBasement()
    {
        SceneManager.LoadScene("BasementQuestEnter");
    }

}
