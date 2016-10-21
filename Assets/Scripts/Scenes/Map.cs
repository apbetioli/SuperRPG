using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Map : MonoBehaviour {
	
	void OnGUI(){
		GUI.Label(new Rect (0,0,150,20),"Para onde quer ir:");
		if(GUI.Button(new Rect (0,20,100,50),"Ferreiro")) { SceneManager.LoadScene("Scenes/Shop");}
		if(GUI.Button(new Rect (0,70,100,50),"Missão")) { SceneManager.LoadScene("Scenes/House");}


		if(GameManager.Player.Weapon.GetType() == typeof(Fist))
			GUI.Label(new Rect (400,0,1000,30),"Você não possui armas, porém pode bater com suas próprias mãos, cuidado para não se machucar!");
		else if (GameManager.Player.Weapon != null)
			GUI.Label(new Rect (400,0,1000,30),"Você tem "+GameManager.Player.Weapon.Texto()+", agora pode matar monstros gigantes. ;)");		
		else
			GUI.Label(new Rect (400,0,500,30),"Você não possui nenhuma arma!");

		GUI.Label(new Rect (400,35,500,30),"Sua vida atual: " + GameManager.Player.Health);
	}
}
