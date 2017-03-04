using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
using GooglePlayGames;

/*
 * Controls the interaction with Google play leaderboard
 */
public class Leaderboard : MonoBehaviour {
	
	void Start() {
		Activate();
		Authenticate ();
	}

	public void Authenticate() {
		#if UNITY_ANDROID
		Social.localUser.Authenticate((auth,msg) => {
			Debug.Log(msg);

			if (auth) {
				Debug.Log ("Authentication successful");
				Debug.Log ("Username: " + Social.localUser.userName + "\nUser ID: " + Social.localUser.id + "\nIsUnderage: " + Social.localUser.underage);
			}
			else {
				Debug.LogWarning ("Authentication failed");
			}
		});	
		#endif
	}
	
	public void ReportScore(int score) {
		#if UNITY_ANDROID
		Social.localUser.Authenticate((auth,msg) => {
			Debug.Log(msg);

			if (auth) {
				Social.ReportScore(score, GPGSIds.leaderboard_super_rpg_masters, success => {
					if(success)
						Debug.Log("Report score ok");
					else
						Debug.LogWarning("Report score failed");
				});
			}
			else {
				Debug.LogWarning("Authentication failed");
			}
		});	
		#endif
	}

	public void Activate() {
		#if UNITY_ANDROID
		PlayGamesPlatform.Activate();
		Debug.Log("Play Game Platform Activated");
		#endif
	}

	public void ShowLeaderboard () {
		#if UNITY_ANDROID
		Social.localUser.Authenticate ((auth,msg) => {
			Debug.Log(msg);

			if (auth) {
				Debug.Log("Showing leaderboard");
				//Social.ShowLeaderboardUI();
				PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_super_rpg_masters);

			} else {
				Debug.LogWarning("Authentication failed");
			}
		});
		#endif
	}

	public void UnlockAchievement(string id) {
		#if UNITY_ANDROID
		Social.localUser.Authenticate ((auth,msg) => {
			Debug.Log(msg);

			if (auth) {
				Social.ReportProgress (id, 100.0f, success => {
					if(!success)
						Debug.LogWarning("Error unlocking achievement");
				});
			} else {
				Debug.LogWarning("Authentication failed");
			}
		});
		#endif
	}
}
