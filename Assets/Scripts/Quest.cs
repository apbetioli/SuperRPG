using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {
	void OnGUI(){
		if(GUI.Button(new Rect (0,0,100,50),"Voltar ao mapa")) { Application.LoadLevel("Scenes/Map");}
		GUI.Label (new Rect (0, 50, 150, 20), "Mate os ratos do porão!");
		GUI.Label (new Rect (0, 200, 500, 20), "rato    rato    rato    rato    rato    rato    rato    rato    rato    ");
	}
}
