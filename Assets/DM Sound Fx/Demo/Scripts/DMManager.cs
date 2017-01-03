using UnityEngine;
using System.Collections;

public class DMManager : MonoBehaviour {
	DMScoreManager gameScoreComponent;

	public DMSoundManager soundManager;

	public float jumpForce = 400f;

	private bool isJump;
	private bool isLive;

	//Start position of Player sprite, using for restart game
	private Vector3 defaultDropManPosition = new Vector3(-3.37f, 0.359f, -1f);

	//Sound System
	DMHeroSoundSystem soundSystem;

	//Animator Controller of Drop Man
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		soundSystem = gameObject.GetComponent<DMHeroSoundSystem> ();

		InitGame ();
	}

	public void SetGameScoreComponent(DMScoreManager dmScoreManager) {
		gameScoreComponent = dmScoreManager;
	}

	// Update is called once per frame
	void Update () {
		if (!isJump && isLive) {
			soundSystem.PlayRunSound ();
		}
	}

	//Player start Jump
	public void Jump() {
		isJump = true;
		soundSystem.PlayJumpSound ();
		SetJumpAnimationStatus ();
	}

	//When Player start touch some Collider
	void OnCollisionEnter2D(Collision2D coll) {
		//I using Marker classes for this demo, but is not best way, better if you use Layers or object Tags
		DMMarkerGround groundMarker = coll.gameObject.GetComponent<DMMarkerGround> ();
		DMMarkerDeadZone deadMarker = coll.gameObject.GetComponent<DMMarkerDeadZone> ();
		DMMarkerCoin coinMarker = coll.gameObject.GetComponent<DMMarkerCoin> ();

		if (groundMarker) {
			//If Player now touch Ground: is mean Jump is finish and need play Run sounds
			isJump = false;
			SetJumpAnimationStatus ();
		} else if (coinMarker) {
			//If Player touch Coin: destroy Coin, add new Score, and Play Coin Sound
			Destroy (coll.gameObject);
			if (gameScoreComponent != null) {
				gameScoreComponent.IncreaseScore ();
			}
			soundSystem.PlayCoinSound ();
		} else if (deadMarker && isLive) {
			//If Player touch Object with Dead Marker: change Live Status, Play Die animation, Play Lost Sound
			isLive = false;
			anim.SetTrigger ("Die");
			soundSystem.PlayLostSound ();
			SetLiveAnimationStatus ();
		}
	}
		
	//Set Jump state for Animator
	void SetJumpAnimationStatus () {
		if (anim != null) {
			anim.SetBool ("isJump", isJump);
		}
	}

	//Set Live state for Animator
	void SetLiveAnimationStatus () {
		if (anim != null) {
			anim.SetBool ("isLive", isLive);
		}
	}

	public bool IsJumpNow() {
		return isJump;
	}

	public bool IsLiveNow() {
		return isLive;
	}

	public void ContinueGame() {
		transform.position = defaultDropManPosition;
		InitGame ();
	}


	public void RestartGame() {
		if (gameScoreComponent != null) {
			gameScoreComponent.ClearScore ();
		}
		transform.position = defaultDropManPosition;
		InitGame ();
	}

	//Init Game when Start, Continue, Restart
	void InitGame () {
		isJump = true;
		isLive = true;
		SetLiveAnimationStatus ();
		SetJumpAnimationStatus ();
	}
}
