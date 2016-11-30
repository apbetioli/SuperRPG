using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BasementQuestEnter : MonoBehaviour {
		
	void OnGUI(){ 		
		if(GUI.Button(new Rect (0,20,100,50),"Iniciar quest")) { SceneManager.LoadScene("Scenes/BasementQuest");}
	}
}
