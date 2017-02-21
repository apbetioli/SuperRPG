using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class Menu : MonoBehaviour
{
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
		GameManager.Instance.OpenLeaderboard ();
	}
}