using UnityEngine;
using System.Collections;

public class Healing : MonoBehaviour {

	void Start () {
		InvokeRepeating ("Heal", 1F, 1f);	
	}
	
	public void Heal ()
	{
		GameManager.GetInstance().Player.Heal ();
	}

}
