using UnityEngine;
using System.Collections;

public class EnterQuest : MonoBehaviour {
	void OnGUI(){
		GUI.Label (new Rect (0, 0, 300, 20), "Você está preparado para aceitar uma missão?");
		if(GUI.Button(new Rect (0,20,100,50),"Sim")) { Application.LoadLevel("Scenes/Quest");}
		if(GUI.Button(new Rect (0,70,100,50),"Não")) { Application.LoadLevel("Scenes/Map");}
	}
}
