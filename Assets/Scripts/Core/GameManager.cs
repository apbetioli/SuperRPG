using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private int floor = 0;

	private Floors floors;

	public static GameManager Instance {
		get {
			GameManager gameManager = FindObjectOfType<GameManager> ();
			if (gameManager == null) 
				Load();
			return gameManager;
		}
	}

	public void Awake() {
		floors = FindObjectOfType<Floors> ();
	}

	public Floor CurrentFloor {
		get { return floors.floors [floor]; }
	}

	public void NextFloor() {
		if (floor+1 == floors.floors.Length) {
			GameWon();
		} else {
			floor++;
			Shop();
		}
	}

	public static void GameOver() {
		SceneManager.LoadScene ("GameOver");
	}

	public static void GameWon() {
		SceneManager.LoadScene ("GameWon");
	}

	public static void Shop() {
		SceneManager.LoadScene ("Shop");
	}

	public static void Load() {
		SceneManager.LoadScene ("Load");
	}

	public static void HUD() {
		SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive);
	}

	public static void Battle() {
		SceneManager.LoadScene("Battle");
	}
}
