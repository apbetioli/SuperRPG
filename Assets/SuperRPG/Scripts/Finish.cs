using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

	void Update() {
		if (Input.GetMouseButtonDown (0))
			Reboot ();
	}

	public void Reboot ()
	{
		FindObjectOfType<Load> ().Reboot ();
	}
}
