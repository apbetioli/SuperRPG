using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
//using GooglePlayGames;

/*
 * Controls the interaction with Google play leaderboard
 */
public class Leaderboard : MonoBehaviour {

	private bool authenticated;

	public void OnEnable() {
		//PlayGamesPlatform.Activate();
    }

    public void Authenticate() {
        Social.localUser.Authenticate(success => {
			authenticated = success;

            if (success) {
                Debug.Log ("Authentication successful");
                Debug.Log ("Username: " + Social.localUser.userName + "\nUser ID: " + Social.localUser.id + "\nIsUnderage: " + Social.localUser.underage);
            }
            else {
                Debug.LogWarning ("Authentication failed");
            }
        });
    }
    
    public void ReportScore(int score) {
		if (!authenticated)
			return;

        Social.ReportScore(score, GPGSIds.leaderboard_super_rpg_masters, success => {
			if(!success)
				Debug.LogWarning("Error reporting score");
		});
    }

    public bool ShowLeaderboard () {
		if (!authenticated) {
			Debug.LogWarning ("Not authenticated.");
			Authenticate ();
			return false;
		}
		
		Social.ShowLeaderboardUI();
		//PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_super_rpg_masters);
		return true;
    }

	public void UnlockAchievement(string id) {
		if (!authenticated)
			return;
		
		Social.ReportProgress (id, 100.0f, success => {
			if(!success)
				Debug.LogWarning("Error unlocking achievement");
		});
	}
}
