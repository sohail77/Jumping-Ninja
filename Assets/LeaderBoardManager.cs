using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LeaderBoardManager : MonoBehaviour {

	public static LeaderBoardManager instance;


	void Awake(){
		if (instance == null)
			instance = this;
	}
	// Use this for initialization
	void Start () {
		PlayGamesPlatform.Activate ();
		Login ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Login(){
		Social.localUser.Authenticate ((bool success) => {
		});
	}

	public void AddScoreToLeaderBoard(){
		Social.ReportScore (ScoreManager.instance.score, LeaderBoard.leaderboard_best_player, (bool success) => {
		});
		
	}

	public void ShowLeaderBoard(){
		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI (LeaderBoard.leaderboard_best_player);
		} else {
			Login ();
		}
	}
}
