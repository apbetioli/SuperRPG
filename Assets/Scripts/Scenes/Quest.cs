using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Quest : MonoBehaviour {


	void Start(){
		GameManager.GetInstance ().MakeEnemies ();
	}

	void OnGUI(){
		if(GUI.Button(new Rect (0,0,100,50),"Voltar ao mapa")) { SceneManager.LoadScene("Scenes/Map");}

		if (GameManager.GetInstance ().GetEnemies ().Count == 0) {
			GUI.Label (new Rect (0, 50, 500, 20), "Parabéns você matou todos os ratos do porão!");
			return;
		}

		if(GUI.Button(new Rect (100,0,100,50),"Atacar")) { Player.GetInstance ().attack (GameManager.GetInstance ().GetEnemies ()[0]);}
		GUI.Label (new Rect (0, 50, 150, 20), "Mate os ratos do porão!");
		string ratos = "";
		for (int i = 0; i < GameManager.GetInstance ().GetEnemies ().Count; i++)
			ratos += "    rato";
		GUI.Label (new Rect (0, 200, 1000, 20), ratos);


		GUI.Label (new Rect (0, 240, 500, 20), "Vida do rato atual: " + GameManager.GetInstance ().GetEnemies ()[0].GetHealth());
		GUI.Label (new Rect (0, 220, 500, 20), "Número de ratos: " + GameManager.GetInstance ().GetEnemies ().Count);

	}
}
