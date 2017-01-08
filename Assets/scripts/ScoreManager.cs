using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int score;
	public Text scoreText;

	void Awake(){
		makeInstance ();
	}

	public void makeInstance(){
		if (instance == null)
			instance = this;
	}

	public void IncrementScore(){
		score++;
		scoreText.text = "" + score;
	}

	public int GetScore(){
		return this.score;
	}

	public void GetHighScore(){
		PlayerPrefs.SetInt ("score", score);
		if (PlayerPrefs.HasKey ("highScore")) {
			if (score > PlayerPrefs.GetInt ("highScore")) {
				PlayerPrefs.SetInt ("highScore", score);

			}
		} 
		else {
			PlayerPrefs.SetInt ("highScore", score);
		}
	}
}

