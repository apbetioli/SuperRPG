using UnityEngine;

public class Load : MonoBehaviour
{
	void Awake ()
	{
		DontDestroyOnLoad (this);
	}

	void Start ()
	{     
		GameManager.Shop ();
	}

	public void Reboot ()
	{
		Destroy (gameObject);
		GameManager.Load ();
	}
}
