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
		wCars = new List<GameObject>();
		aCars = new List<GameObject>();
		sCars = new List<GameObject>();
		dCars = new List<GameObject>();
		pedestrians = new List<GameObject>();
		lives = 5;
		wSpawn = true;
		aSpawn = true;
		sSpawn = true;
		dSpawn = true;
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
		int i;
		switch(objType)
		{
			case 'W':
				i = wCars.IndexOf(obj);
				Destroy(wCars[i]);
				wCars.RemoveAt(i);
				break;
			case 'A':
				i = aCars.IndexOf(obj);
				Destroy(aCars[i]);
				aCars.RemoveAt(i);
				break;
			case 'S':
				i = sCars.IndexOf(obj);
				Destroy(sCars[i]);
				sCars.RemoveAt(i);
				break;
			case 'D':
				i = dCars.IndexOf(obj);
				Destroy(dCars[i]);
				dCars.RemoveAt(i);
				break;
			case 'P':
				print("KILL");
				i = pedestrians.IndexOf(obj);
				Destroy(pedestrians[i]);
				pedestrians.RemoveAt(i);
				break;
			default:
				break;
		}
	}
	
	void SpawnCar(char dir, int spd)
	{
		GameObject car;
		switch(dir)
		{
			case 'W':
				print(wSpawn);
				if(!wSpawn)
					return;
				car = Instantiate(genericCar);
				wCars.Add(car);
				car.GetComponent<CarMovement>().TransformCar("type", dir, spd); 
				break;
			case 'A':
				print(aSpawn);
				if(!aSpawn)
					return;
				car = Instantiate(genericCar);
				aCars.Add(car);
				car.GetComponent<CarMovement>().TransformCar("type", dir, spd); 
				break;
			case 'S':
				print(sSpawn);
				if(!sSpawn)
					return;
				car = Instantiate(genericCar);
				sCars.Add(car);
				car.GetComponent<CarMovement>().TransformCar("type", dir, spd); 
				break;
			case 'D':
				print(dSpawn);
				if(!dSpawn)
					return;
				car = Instantiate(genericCar);
				dCars.Add(car);
				car.GetComponent<CarMovement>().TransformCar("type", dir, spd); 
				break;
			default:
				break;
		}
		
	}

    void SpawnPeople(int pos)
    {
        GameObject pedestrian = Instantiate(genericPedestrian);
        pedestrian.GetComponent<PedestrianWalk>().Transform(pos); 
		pedestrians.Add(pedestrian);
		
    }

    void IncrementScore()
	{
		
	}
	
	/* Public function */
	public void Crash()
	{
		lives--;
		if(lives < 1)
			gamestate = "gameover";
	}
	
}
