using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Shop : MonoBehaviour {
	private GameObject player;

	void OnGUI(){
		if(GUI.Button(new Rect (0,0,100,50),"Voltar ao mapa")) { SceneManager.LoadScene("Scenes/Map");}

		if (Player.GetInstance ().GetInventory ().Weapon == null) {
			GUI.Label (new Rect (0, 50, 150, 20), "O que você quer comprar?");
			if (GUI.Button (new Rect (0, 70, 200, 50), "Espada de madeira")) {
				Weapon s = ScriptableObject.CreateInstance("WoodSword") as WoodSword;
				s.Equip (Player.GetInstance ());
			}
		}else
			GUI.Label (new Rect (0, 50, 300, 20), "Desculpe, hoje não tenho mais nada para você!");


	}
}
