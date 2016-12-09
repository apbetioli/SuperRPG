using UnityEngine;
using UnityEngine.SceneManagement;

public class BasementQuestEnter : MonoBehaviour
{
	
	void Awake() {
		SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
	}
	
    public void EnterQuest()
    {
        SceneManager.LoadScene("BasementQuest");
    }
}
