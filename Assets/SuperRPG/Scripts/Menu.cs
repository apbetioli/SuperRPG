using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

using UnityEngine.SocialPlatforms;

public class Menu : MonoBehaviour
{
	public Text status;

	public void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Exit ();
			return;
		}
	}

	public void StartGame ()
	{
		GameManager.Shop ();
	}

	public void Exit ()
	{
		Debug.Log ("Fechar jogo!");
		Application.Quit ();
	}

	public void Credits ()
	{
		Debug.Log ("Creditos!");
	}

	public void Leaderboard ()
	{
		Social.localUser.Authenticate(success => {
			if (success) {
				Debug.Log ("Authentication successful");
				status.text = "Username: " + Social.localUser.userName + "\nUser ID: " + Social.localUser.id + "\nIsUnderage: " + Social.localUser.underage;
			}
			else {
				Debug.LogWarning ("Authentication failed");
			}
		});
	}
}