using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Shop : MonoBehaviour {

	void OnGUI(){
		if(GUI.Button(new Rect (0,0,100,50),"Voltar ao mapa")) { SceneManager.LoadScene("Scenes/Map");}
		 
		if (GameManager.Player.Weapon.GetType() == typeof(Fist)) {
			GUI.Label (new Rect (0, 50, 150, 20), "O que você quer comprar?");
			if (GUI.Button (new Rect (0, 70, 200, 50), "Espada de madeira"))
				GameManager.Player.Weapon = new WoodenSword();			
		}else
			GUI.Label (new Rect (0, 50, 300, 20), "Desculpe, hoje não tenho mais nada para você!");
	}
}
