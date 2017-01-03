using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backManager : MonoBehaviour {

	public AudioSource menuSound;

	public void GoBack(){
		Application.LoadLevel ("MainMenu");
	}

	// Use this for initialization
	void Start () {
		menuSound.Play ();
	}
}
