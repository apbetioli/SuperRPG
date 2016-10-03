using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Map : MonoBehaviour {
	void OnGUI(){
		GUI.Label(new Rect (0,0,150,20),"Para onde quer ir:");
		if(GUI.Button(new Rect (0,20,100,50),"Ferreiro")) { SceneManager.LoadScene("Scenes/Shop");}
		if(GUI.Button(new Rect (0,70,100,50),"Missão")) { SceneManager.LoadScene("Scenes/EnterQuest");}


		if(Player.GetInstance().GetInventory().Weapon != null)
			GUI.Label(new Rect (400,0,500,20),"Parabéns vc tem "+Player.GetInstance().GetInventory().Weapon.Texto()+", agora vc pode aceitar missões.");
		else
			GUI.Label(new Rect (400,0,500,20),"Você não possui nenhuma arma!");
	}
}
