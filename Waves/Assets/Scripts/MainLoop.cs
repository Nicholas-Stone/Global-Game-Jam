using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour {
	/* Prefabs */
	public GameObject genericCar;
    public GameObject genericPedestrian;

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
	public List<GameObject> wCars;
	public List<GameObject> aCars;
	public List<GameObject> sCars;
	public List<GameObject> dCars;
	public bool wSpawn, aSpawn, sSpawn, dSpawn;
	
	/* Other stuff */
	private List<GameObject> pedestrians;
	private string gamestate;
	public int numPassed;
	public int level;
	private int lives;

	// Use this for initialization
	void Start () {
		numPassed = 0;
		level = 0;
		gamestate = "start";
		AdvanceLevel();
		lives = 5;
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

        if(Random.value < 0.01 && Random.value > 0.5)
        {
            switch(Random.Range(0, 4))
            {
                case 0:
                    SpawnCar('W', 1);
                    break;
                case 1:
                    SpawnCar('A', 1);
                    break;
                case 2:
                    SpawnCar('S', 1);
                    break;
                case 3:
                    SpawnCar('D', 1);
                    break;
                default:
                    SpawnCar('W', 1);
                    break;
            }
        }

        switch (Random.Range(0, 1000))
        {
            case 0:
                SpawnPeople(0);
                break;
            case 1:
                SpawnPeople(1);
                break;
            case 2:
                SpawnPeople(2);
                break;
            case 3:
                SpawnPeople(3);
                break;
            case 4:
                SpawnPeople(4);
                break;
            case 5:
                SpawnPeople(5);
                break;
            case 6:
                SpawnPeople(6);
                break;
            case 7:
                SpawnPeople(7);
                break;
            default:
                break;
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
	
	public void Despawn(char objType, GameObject obj)
	{
		// TODO add a despawn area
	}
	
	void SpawnCar(char dir, int spd)
	{
		switch(dir)
		{
			case 'W':
			case 'A':
			case 'S':
			case 'D':
			default:
				break;
		}
		GameObject car = Instantiate(genericCar);
		car.GetComponent<CarMovement>().TransformCar("type", dir, spd); // TODO CHANGE TYPE
	}

    void SpawnPeople(int pos)
    {
        GameObject pedestrian = Instantiate(genericPedestrian);
        pedestrian.GetComponent<PedestrianWalk>().Transform(pos); // TODO CHANGE TYPE
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
