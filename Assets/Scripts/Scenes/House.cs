using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class House : MonoBehaviour {
	void OnGUI(){
		GUI.Label (new Rect (0, 0, 300, 20), "Você está preparado para aceitar uma missão?");
		if(GUI.Button(new Rect (0,20,100,50),"Sim")) { SceneManager.LoadScene("Scenes/BasementQuest");}
		if(GUI.Button(new Rect (0,70,100,50),"Não")) { SceneManager.LoadScene("Scenes/Map");}
	}
}
