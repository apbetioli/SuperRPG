using UnityEngine;
using System.Collections.Generic;

public class Floor : MonoBehaviour
{
	public Turn[] turns;
	public Item[] items;

	public void Reset ()
	{
		turns = GetComponentsInChildren<Turn> ();
		items = GetComponentsInChildren<Item> (); 
	}

	public void OnEnable() {
		Reset ();
	}
}