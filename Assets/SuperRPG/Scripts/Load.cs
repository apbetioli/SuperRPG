using UnityEngine;
using GameAnalyticsSDK;

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
		GameAnalytics ga = FindObjectOfType<GameAnalytics> ();
		if (ga != null)
			Destroy (ga.gameObject);
		GameManager.Load ();
	}
}
