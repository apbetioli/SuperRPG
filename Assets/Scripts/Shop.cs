using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
	void OnGUI(){
		if(GUI.Button(new Rect (0,0,100,50),"Voltar ao mapa")) { Application.LoadLevel("Scenes/Map");}
		GUI.Label (new Rect (0, 50, 150, 20), "O que vc quer comprar?");


		if(GUI.Button(new Rect (0,70,200,50),"Espada de madeira")) {}
	}
}
