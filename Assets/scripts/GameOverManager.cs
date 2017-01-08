using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

	public static GameOverManager instance;
	private GameObject gameOverPanel;
	private Animator gameOverAnim;
	private Button retryBtn,MenuBtn;
	private Text score;

	private GameObject scoreText;
	public Text highScore;

	void Awake(){
		makeInstance ();
		InitializeVariable ();
	}

	public void makeInstance(){
		if (instance == null)
			instance = this;
	}

	public void showGameOverPanel(){
		scoreText.SetActive (false);
		gameOverPanel.SetActive (true);
		ScoreManager.instance.GetHighScore ();
		score.text = "Score:\n" + "" + ScoreManager.instance.GetScore ();
		highScore.text ="High Score:\n" +  PlayerPrefs.GetInt ("highScore").ToString ();
		LeaderBoardManager.instance.AddScoreToLeaderBoard ();
		gameOverAnim.Play("GameOverPanel fadeIn");
		AdManager.instance.ShowAd ();

	}

	void InitializeVariable(){
		gameOverPanel = GameObject.Find ("GameOverPanel Holder");
		gameOverAnim = gameOverPanel.GetComponent<Animator> ();
		retryBtn = GameObject.Find ("RetryButton").GetComponent<Button>();
		MenuBtn = GameObject.Find ("MenuButton").GetComponent<Button> ();

		retryBtn.onClick.AddListener (() => PlayAgain ());
		MenuBtn.onClick.AddListener (() => Menu ());

		scoreText = GameObject.Find ("ScoreText");
		score = GameObject.Find ("Text").GetComponent<Text> ();

		gameOverPanel.SetActive (false);
	}

	public void PlayAgain(){
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void Menu(){
		Application.LoadLevel ("MainMenu");
	}
}
