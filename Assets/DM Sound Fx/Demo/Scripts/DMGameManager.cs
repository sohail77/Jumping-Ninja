using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DMGameManager: MonoBehaviour {

	public GameObject menuCanvas;

	public GameObject gameCanvas;

	// Use this for initialization
	void Start () {
	
	}

	public void StartGame() {
		if (menuCanvas != null && gameCanvas != null) {
			menuCanvas.SetActive (false);
			gameCanvas.SetActive (true);
		}
	}

	public void BackToMenu() {
		if (menuCanvas != null && gameCanvas != null) {
			menuCanvas.SetActive (true);
			gameCanvas.SetActive (false);
		}
	}
}
