using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Quest : MonoBehaviour {

	EnemyManager manager;
	Character player;

	void Start(){		
		manager = new EnemyManager(typeof( Rat), 10);
		player = GameManager.GetInstance ().GetPlayer ();
	}

	void OnGUI(){
		if(GUI.Button(new Rect (0,0,100,50),"Voltar ao mapa")) { SceneManager.LoadScene("Scenes/Map");}

		if (manager.GetEnemies().Count == 0) {
			GUI.Label (new Rect (0, 50, 500, 20), "Parabéns você matou todos os ratos do porão!");
			return;
		}

		GUI.Label (new Rect (300, 0, 500, 20), "Sua vida: " + player.GetHealth());


		if(GUI.Button(new Rect (100,0,100,50),"Atacar")) {player.attack (manager.GetNextEnemy());}
		GUI.Label (new Rect (0, 50, 150, 20), "Mate os ratos do porão!");
		string ratos = "";
		for (int i = 0; i < manager.GetEnemies().Count; i++)
			ratos += "    rato";
		GUI.Label (new Rect (0, 200, 1000, 20), ratos);


		GUI.Label (new Rect (0, 240, 500, 20), "Vida do rato atual: " + manager.GetNextEnemy().GetHealth());
		GUI.Label (new Rect (0, 220, 500, 20), "Número de ratos: " + manager.GetEnemies().Count);

	}
}
