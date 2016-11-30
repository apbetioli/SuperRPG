using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BasementQuest : MonoBehaviour {
	private BattleManager manager;

	void Start(){
		manager = GameObject.Find ("BattleManager").GetComponent<BattleManager> ();
	}

	void OnGUI(){ 	
		//if (manager.PlayerWin ()) {	
		//	GUI.Label (new Rect (0, 0, 500, 20), "You win!");
		//	return;
		//}
		//if (manager.PlayerDead ()) {
		//	GUI.Label (new Rect (0, 0, 500, 20), "You loose!");
		//	return;
		//}
		if(GUI.Button(new Rect (0,20,100,50),"Attack")) manager.Attack ();
		if(GUI.Button(new Rect (0,80,100,50),"Bag")) { }
		if(GUI.Button(new Rect (0,140,100,50),"Run")) SceneManager.LoadScene("Scenes/BasementQuestEnter");
	}
}
