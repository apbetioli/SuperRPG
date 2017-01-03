using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class GameManager : MonoBehaviour
{
	private int floor = 0;

	private Floors floors;

	public static GameManager Instance {
		get {
			GameManager gameManager = FindObjectOfType<GameManager> ();
			if (gameManager == null)
				Load ();
			return gameManager;
		}
	}

	public void Awake ()
	{
		floors = FindObjectOfType<Floors> ();
	}

	public Floor CurrentFloor {
		get { return floors.floors [floor]; }
	}

	public void NextFloor ()
	{
		GameAnalytics.NewProgressionEvent (GAProgressionStatus.Complete, "floor " + Instance.floor);

		if (floor + 1 == floors.floors.Length) {
			GameWon ();
		} else {
			floor++;
			Shop ();
		}
	}

	public static void Run (Enemy enemy)
	{
		/*
		Player player = Player.Instance;

		Analytics.CustomEvent ("DeathInFloor", new Dictionary<string, object> {
			{ "floor", Instance.floor }
		});

		Analytics.CustomEvent ("GameOver", new Dictionary<string, object> {
			{ "floor", Instance.floor },
			{ "coins", player.coins },
			{ "weapon", player.weapon.name },
			{ "shield", player.shield.name },
			{ "health", player.health },
			{ "maxHealth", player.maxHealth },
			{ "enemy", enemy.name }
		});
		*/

		GameAnalytics.NewProgressionEvent (GAProgressionStatus.Fail, "floor " + Instance.floor, enemy.name);

		SceneManager.LoadScene ("GameOver", LoadSceneMode.Additive);
	}

	public static void Run ()
	{
		GameAnalytics.NewDesignEvent ("Run");

		SceneManager.LoadScene ("GameOver", LoadSceneMode.Additive);
	}

	public static void GameWon ()
	{
		SceneManager.LoadScene ("GameWon", LoadSceneMode.Additive);
	}

	public static void Shop ()
	{
		SceneManager.LoadScene ("Shop");
		HUD ();
	}

	public static void Load ()
	{
		SceneManager.LoadScene ("Load");
	}

	public static void HUD ()
	{
		SceneManager.LoadSceneAsync ("HUD", LoadSceneMode.Additive);
	}

	public static void Battle ()
	{
		GameAnalytics.NewProgressionEvent (GAProgressionStatus.Start, "floor " + Instance.floor);

		SceneManager.LoadScene ("Battle");
		SceneManager.LoadScene ("BattleHUD", LoadSceneMode.Additive);
		HUD ();
	}
}
