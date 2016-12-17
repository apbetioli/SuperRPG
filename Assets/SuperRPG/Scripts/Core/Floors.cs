using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;
using System;

public class Floors : MonoBehaviour
{
	public Floor[] floors;

	public void Reset ()
	{
		floors = GetComponentsInChildren<Floor> ();
	}
}