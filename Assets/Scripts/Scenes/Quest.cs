using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Quest : MonoBehaviour {

	EnemyManager enemyManager;
	QuestManager questManager;

	void Start(){		
		enemyManager = new EnemyManager(typeof( Rat), 10);
		questManager = new QuestManager (enemyManager, GameManager.GetInstance().GetPlayer());	
	}

	void OnGUI(){
		if(GUI.Button(new Rect (0,0,100,50),"Voltar ao mapa")) { SceneManager.LoadScene("Scenes/Map");}

		if (enemyManager.GetEnemies().Count == 0) {
			GUI.Label (new Rect (0, 50, 500, 20), "Parabéns você matou todos os ratos do porão!");
			return;
		}

		GUI.Label (new Rect (300, 0, 500, 20), "Sua vida: " + GameManager.GetInstance().GetPlayer().GetHealth());

		questManager.StartQuest();
		string ratos = "";
		for (int i = 0; i < enemyManager.GetEnemies().Count; i++){
			string add = "    rato";
			if (i + 1 == enemyManager.GetEnemies ().Count)
				add = "    rato--ó/";
			ratos += add;
		}
		GUI.Label (new Rect (0, 200, 1000, 20), ratos);


		if(enemyManager.GetNextEnemy()!=null)
			GUI.Label (new Rect (0, 240, 500, 20), "Vida do rato atual: " + enemyManager.GetNextEnemy().GetHealth());
		GUI.Label (new Rect (0, 220, 500, 20), "Número de ratos: " + enemyManager.GetEnemies().Count);

	}
}
