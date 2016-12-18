using UnityEngine;
using System.Collections.Generic;

public class Floor : MonoBehaviour
{
	[HideInInspector]
	public Turn[] turns;
	[HideInInspector]
	public Item[] items;

	public void Awake ()
	{
		turns = GetComponentsInChildren<Turn> ();
		items = GetComponentsInChildren<Item> (); 
	}

}