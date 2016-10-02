using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
	void OnGUI(){
		GUI.Label(new Rect (0,0,150,20),"Para onde quer ir:");
		if(GUI.Button(new Rect (0,20,100,50),"Ferreiro")) { Application.LoadLevel("Scenes/Shop");}
		if(GUI.Button(new Rect (0,70,100,50),"Missão")) { Application.LoadLevel("Scenes/EnterQuest");}
	}
}
