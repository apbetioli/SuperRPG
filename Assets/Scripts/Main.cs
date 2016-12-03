using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
	
	void Awake() {
		SceneManager.LoadScene("Load", LoadSceneMode.Additive);
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
