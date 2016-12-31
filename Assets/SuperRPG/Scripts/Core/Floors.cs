using UnityEngine;

public class Floors : MonoBehaviour
{
	[HideInInspector]
	public Floor[] floors;

	public void Awake ()
	{
		floors = GetComponentsInChildren<Floor> ();
	}

}