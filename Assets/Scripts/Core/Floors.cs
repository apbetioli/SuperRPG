using UnityEngine;

public class Floors : MonoBehaviour
{
	public Floor[] floors;

	public void Reset ()
	{
		floors = GetComponentsInChildren<Floor> ();
	}

	public void OnEnable() {
		Reset ();
	}
}