﻿/// <summary>
/// Ss_ game manager.
/// This class is a control flow construct of when the game is active an not active, and works by having the player click on the play the minigame 
/// and the enemy spawner does not kick in until the player clicks ploay and then a 5 second wait time begins. 
/// </summary>

using UnityEngine;
using System.Collections;

public class ss_GameManager : MonoBehaviour {

	public GameObject playButton;
	public GameObject playerShip;

	// references to our Enemies' Spawners. 
	public GameObject enemy1Spawner;  
	public GameObject enemy2Spawner;  
	public GameObject enemy3Spawner;  

	public GameObject GO_GameOver; // reference to the Game Over Screen image.

	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,

	}

	GameManagerState GMState;

	// Use this for initialization
	void Start () {
		GMState = GameManagerState.Opening;
	}
	
//Function to update the game manager state.
	void UpdateGameManagerState()
	{
		switch(GMState)
		{
		case GameManagerState.Opening:
		//Hide Game Over Screen.
			GO_GameOver.SetActive(false);

		//Set play button visible (ative)
			playButton.SetActive(true);

			break;
		case GameManagerState.Gameplay:
		//Hide the play button on the GamePlay state.
		playButton.SetActive(false);

		//Set the Player visible (active) and Initialize the player lives.
			playerShip.GetComponent<ss_PlayerControl>().Init();

			//Starts for all 3 enemy spawners
			enemy1Spawner.GetComponent<ss_Enemy1Spawner>().ScheduledEnemySpawner(); 
			enemy2Spawner.GetComponent<ss_Enemy2Spawner>().ScheduledEnemySpawner(); 
			enemy3Spawner.GetComponent<ss_Enemy3Spawner>().ScheduledEnemySpawner(); 

			break;
		case GameManagerState.GameOver:
			//Stops all 3 enemy Spawners .
			enemy1Spawner.GetComponent<ss_Enemy1Spawner>().UnscheduledEnemySpawner();
			enemy2Spawner.GetComponent<ss_Enemy2Spawner>().UnscheduledEnemySpawner();
			enemy3Spawner.GetComponent<ss_Enemy3Spawner>().UnscheduledEnemySpawner();

			//Display GameOver Screen.
			GO_GameOver.SetActive(true);

		/*Change Game Manager state to Opening State after any number of seconds to
			Replay the game continously. */
			Invoke("ChangeToOpeningState", 3f);
			break;
		}
	}

	//Function to set the game manager state.
	public void SetGameManagerState(GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState();
	}
	/*Our play button will call this fucntion whne the user clicks the button.*/
	public void StartGamePlay()
	{
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState();
	}

	//Function to change game manager state to Opening State.
	public void ChangeToOpeningState()
	{
		SetGameManagerState(GameManagerState.Opening);

	}

}
