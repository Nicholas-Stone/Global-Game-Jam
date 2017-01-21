using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour {
	/* Prefabs */
	public GameObject genericCar;
	
	/* Text */
	
	public GameObject counter;
	public GameObject lvltext;
	public GameObject gameover;
	public GameObject winrar;
	public AudioSource mainAudio;
	public GameObject wButton;
	public GameObject aButton;
	public GameObject sButton;
	public GameObject dButton;
	
	/* Cars */
	private GameObject[] wCars;
	private GameObject[] aCars;
	private GameObject[] sCars;
	private GameObject[] dCars;
	private Vector3 wSpawn = new Vector3(-15f, 6.5f, 0f);
	private Vector3 aSpawn;
	private Vector3 sSpawn;
	private Vector3 dSpawn;
	
	/* Other stuff */
	private string gamestate;
	public int numPassed;
	public int level;

	// Use this for initialization
	void Start () {
		numPassed = 0;
		level = 0;
		gamestate = "start";
		AdvanceLevel();
	}
	
	// Update is called once per frame
	void Update () {
		if(gamestate == "gameover") // gameover state
		{
			
		}
		else if(gamestate == "win")
		{
			// play again? 
		}
		else if(gamestate == "reset")
		{
			// reset stage
		}
		else if(gamestate == "play")
		{
			
		}
	}
	// UI TIMER, COUNTER, CONTROLS
	
	void AdvanceLevel()
	{
		if(level < 0)
		{
			Debug.Log("y u gotta break the game :c");
		}
		if(level < 1) // Go to level 2
		{
			SpawnCar('W', 1);
			SpawnCar('A', 1);
			SpawnCar('S', 1);
			SpawnCar('D', 1);
			// TODO spawn cars, change background, whatever
		}
		else if(level < 2) // Go to level 3
		{
			
		}
		else if(level < 3) // Go to level 4
		{
			
		}
		else if(level < 4) // Go to level 5
		{
			
		}
		else // Go to the Winner screen
		{
			gamestate = "win";
		}
		level++;
	}
	
	void DespawnCar()
	{
		
	}
	
	void SpawnCar(char dir, int spd)
	{
		GameObject car = Instantiate(genericCar);
		car.GetComponent<CarMovement>().TransformCar("type", dir, spd); // TODO CHANGE TYPE
	}
	
	void IncrementScore()
	{
		
	}
	
	/* Public function */
	public void Crash()
	{
		gamestate = "gameover";
	}
	
}
