using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DMScoreManager : MonoBehaviour {
	//UI Text where need show Score
	public Text scoreText;
	public string prefixText = "Score";
	private int currentScore;

	// Use this for initialization
	void Start () {
		ClearScore();
	}

	void SetScore () {
		if (scoreText != null) {
			scoreText.text = prefixText + ": " + currentScore;
		} else {
			print ("Hey, set UI element Text Score for Score Manager!");
		}
	}

	public void ClearScore() {
		currentScore = 0;
		SetScore ();
	}

	public void IncreaseScore() {
		currentScore++;
		SetScore ();
	}
}
