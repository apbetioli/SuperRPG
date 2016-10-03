using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Quest : MonoBehaviour {
	void OnGUI(){
		if(GUI.Button(new Rect (0,0,100,50),"Voltar ao mapa")) { SceneManager.LoadScene("Scenes/Map");}
		GUI.Label (new Rect (0, 50, 150, 20), "Mate os ratos do porão!");
		GUI.Label (new Rect (0, 200, 500, 20), "rato    rato    rato    rato    rato    rato    rato    rato    rato    ");
	}
}
