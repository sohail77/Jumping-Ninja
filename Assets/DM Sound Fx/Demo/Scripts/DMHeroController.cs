using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DMHeroController : MonoBehaviour {
	//Game Object for Player Control
//	public GameObject dropMan;
	public DMManager dropManager;

	//Sound System on Scene for play sounds
	public DMSoundManager soundSystemObject;

	//Control Button status
	public Text gameButtonText;

	//Text for show current score
	public Text scoreText;

	//UI images what show how many life have player. Depend from size this array game know maximum life.
	public Image[] lifeImages;

	//Speed of moving objects in scene
	public float speedOfObjects = 3f;

	//Minimum pause for game random generate new object
	public int minimumTimeDelayForGenerateObject = 100;
	//Maximum time for generate randon object
	int maximumTimeDelayForGenerateObject;

	public GameObject[] enemies;

	public GameObject[] coins;

	private int timeToGenerateNewObject;

	private Vector3 birthPositionOfBonus;
	private Vector3 birthPositionOfEnemy;

	//Number of lifes
	private int currentLifes;

	//Value in Percent (0 ... 100) for get bonus. Default 60%
	public float chanceToGenerateGoodBonus = 60f;

	// Use this for initialization
	void Start () {
		maximumTimeDelayForGenerateObject = minimumTimeDelayForGenerateObject * 2;
		//First object game create after short time
		timeToGenerateNewObject = minimumTimeDelayForGenerateObject;

		DMScoreManager scoreManager = gameObject.GetComponent<DMScoreManager> ();

		if (dropManager != null && scoreManager) {
			dropManager.SetGameScoreComponent (scoreManager);
		}

		birthPositionOfBonus = new Vector3 (10f, 0.5f, 0f);
		birthPositionOfEnemy = new Vector3 (10f, -1.2f, -1f);

		InitGame ();
	}

	//Set Button Text depend from Player State
	void SetTitleOfButton() {
		if (dropManager != null) {
			if (!dropManager.IsLiveNow ()) {
				if (currentLifes > 0) {
					//Player dead, but have life
					gameButtonText.text = "Continue";
				} else {
					//Player dead and not have more lifes
					gameButtonText.text = "Restart";
				}
			} else {
				//Player live
				gameButtonText.text = "Jump";
			}

		}
	}
		
	void FixedUpdate () {
		SetTitleOfButton ();

		if (Input.GetAxis ("Jump") > 0) {
			ControlButtonPressed ();
		}

		//Decrement time for generate new object, if value less than 0, than create new object
		if (--timeToGenerateNewObject < 0) {
			//Set New Range for create new object
			timeToGenerateNewObject = Random.Range (minimumTimeDelayForGenerateObject, maximumTimeDelayForGenerateObject);

			if (Random.Range (0, 100) < chanceToGenerateGoodBonus) {
				//If random number more than chanceToGenerateGoodBonus, than create bonus
				if (coins != null && coins.Length > 0) {
					Instantiate (coins [Random.Range (0, coins.Length)], birthPositionOfBonus, Quaternion.identity);
					soundSystemObject.PlaySurpriseSound ();
				}
			} else {
				//If random number less or equal 4, than create enemy
				if (enemies != null && enemies.Length > 0) {
					Instantiate (enemies [Random.Range (0, enemies.Length)], birthPositionOfEnemy, Quaternion.identity);
					soundSystemObject.PlayAttentionSound ();
				}
			}
		}
	}

	//Button pressed, do some action depend from Player state
	public void ControlButtonPressed() {
		if (dropManager != null) {
			if (dropManager.IsLiveNow ()) {
				//If Player Live, than Jump
				Jump ();
			} else if (currentLifes > 0) {
				//Player Dead, but have life, can Continue
				dropManager.ContinueGame ();
				lifeImages [currentLifes - 1].enabled = false;
				currentLifes--;
			} else {
				//Player dead and not have life more, Restart Game
				InitGame ();
			}
		}
	}

	//Player Jump
	public void Jump() {
		if (dropManager != null) {
			if (!dropManager.IsJumpNow () && dropManager.IsLiveNow ()) {
				dropManager.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, dropManager.jumpForce));
				dropManager.Jump ();
			}
		} else {
			print ("Hey you need set DropMan prefab");
		}
	}

	//Initial Drop Man parameters when start/restart game
	public void InitGame() {
		if (lifeImages != null && lifeImages.Length > 0) {
			for (int i = 0; i < lifeImages.Length; i++) {
				lifeImages [i].enabled = true;
			}
			currentLifes = lifeImages.Length;
		} else {
			currentLifes = 0;
			print ("Hey, have problem with initialize of number lifes");
		}

		if (dropManager != null) {
			dropManager.RestartGame ();
		}
	}
}
