using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	public AudioSource menuSound;

	public void PlayGame(){
		Application.LoadLevel ("Gameplay");
	}
	// Use this for initialization
	void Start () {
		menuSound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Help(){
		Application.LoadLevel ("howTo");
	}

//	public void showLeaderBoard(){
//		LeaderBoardManager.instance.ShowLeaderBoard ();
//	}
}
