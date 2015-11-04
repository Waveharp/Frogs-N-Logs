using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

	private bool gameStarted = false;

	[SerializeField]
	private Text gameStateText;

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private BirdMovement birdMovement;

	[SerializeField]
	private FollowCamera followCamera;

	private float restartDelay = 3f;
	private float restartTimer;
	private PlayerMovement playerMovement;
	private PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;

		playerMovement = player.GetComponent<PlayerMovement> ();
		playerHealth = player.GetComponent<PlayerHealth> ();

		// prevent player and bird from moving at start of game
		playerMovement.enabled = false;
		birdMovement.enabled = false;

		// prevent follow camera from moving at start of game
		followCamera.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		// if game is not started and player presses space...
		if (gameStarted == false && Input.GetKeyUp (KeyCode.Space)) {

			// ...start the game
			StartGame();
		}

		// if player is dead...
		if (playerHealth.alive == false) {

			// ...end the game
			EndGame();

			// increment a timer to count up to restarting
			restartTimer = restartTimer + Time.deltaTime;

			// and if it reaches the restart delay
			if (restartTimer >= restartDelay) {


				// reload the currently loaded level
				Application.LoadLevel (Application.loadedLevel);
			}

		}
	
	}

	private void StartGame() {

		// set the game state
		gameStarted = true;

		// set "space to start" text to invisible when game starts
		gameStateText.color = Color.clear;

		// enable game components
		playerMovement.enabled = true;
		birdMovement.enabled = true;
		followCamera.enabled = true;
	}

	private void EndGame() {

		// set game state
		gameStarted = false;

		// show game over text
		gameStateText.color = Color.white;
		gameStateText.text = "Game Over!";

		// remove player from game
		player.SetActive (false);
	}
}
