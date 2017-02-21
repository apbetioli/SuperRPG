using UnityEngine;

public class Load : MonoBehaviour
{
	void Awake ()
	{
		DontDestroyOnLoad (this);
	}

	void Start ()
	{     
		GameManager.Menu ();
	}

	public void Reboot ()
	{
		Destroy (gameObject);
		GameManager.Load ();
	}
}
