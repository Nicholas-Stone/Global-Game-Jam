using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    public float wTime = 0, aTime = 0, sTime = 0, dTime = 0;

    /* Score */
    public int numPassed;
    public GameObject one;
    public GameObject ten;
    public GameObject hundred;

    /* fade */
    private bool beginFade = false;
    public Texture2D fade;
    private float alpha = 0.0f;

    /* Honking */
    public GameObject honk;
    public float wHonk = 0, aHonk = 0, sHonk = 0, dHonk = 0;

    /* Other stuff */
    public GameObject[] locations;
    public GameObject lose;
    private List<GameObject> pedestrians;
	private string gamestate;
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
		lives = 10;
		wSpawn = true;
		aSpawn = true;
		sSpawn = true;
		dSpawn = true;
        AdvanceLevel();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Logo");
        }

        if (Random.value < 0.01 && Random.value > 0.8)
        {
            honk.GetComponent<AudioSource>().Play();
        }

        if (gamestate == "gameover") // gameover state
		{
            beginFade = true;
            StartCoroutine(loadLose());
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

        if(Random.value < 0.1 && Random.value > 0.5)
        {
            switch(Random.Range(0, 4))
            {
                case 0:
                    if (Time.time > wTime + 2.0f)
                        SpawnCar('W', 1);
                    wTime = Time.time;
                    break;
                case 1:
                    if (Time.time > aTime + 2.0f)
                        SpawnCar('A', 1);
                    aTime = Time.time;
                    break;
                case 2:
                    if (Time.time > sTime + 2.0f)
                        SpawnCar('S', 1);
                    sTime = Time.time;
                    break;
                case 3:
                    if (Time.time > dTime + 2.0f)
                        SpawnCar('D', 1);
                    dTime = Time.time;
                    break;
                default:
                    break;
            }
        }

        switch (Random.Range(0, 750))
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
	
    void OnGUI()
    {
        if (beginFade)
        {
            alpha += 0.5f * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = -1000;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fade);
        }
    }

    IEnumerator loadLose()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Gameover");
    }
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
            wTime = Time.time;
            aTime = Time.time;
            sTime = Time.time;
            dTime = Time.time;
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
                int wtype = Random.Range(0, 5);
                print(wSpawn);
				if(!wSpawn)
					return;
				car = Instantiate(genericCar);
				wCars.Add(car);
				car.GetComponent<CarMovement>().TransformCar(wtype, dir, spd); 
				break;
			case 'A':
                int atype = Random.Range(0, 4);
                print(aSpawn);
				if(!aSpawn)
					return;
				car = Instantiate(genericCar);
				aCars.Add(car);
				car.GetComponent<CarMovement>().TransformCar(atype, dir, spd); 
				break;
			case 'S':
                int stype = Random.Range(0, 4);
                print(sSpawn);
				if(!sSpawn)
					return;
				car = Instantiate(genericCar);
				sCars.Add(car);
				car.GetComponent<CarMovement>().TransformCar(stype, dir, spd); 
				break;
			case 'D':
                int dtype = Random.Range(0, 5);
                print(dSpawn);
				if(!dSpawn)
					return;
				car = Instantiate(genericCar);
				dCars.Add(car);
				car.GetComponent<CarMovement>().TransformCar(dtype, dir, spd); 
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

    public void IncrementScore()
	{
        numPassed++;
        updateNumber(one, numPassed % 10);
        updateNumber(ten, (numPassed / 10) % 10);
        updateNumber(hundred, numPassed / 100);
    }

    void updateNumber(GameObject obj, int num)
    {
        Sprite[] nums = Resources.LoadAll<Sprite>("TextNumbers");
        obj.GetComponent<SpriteRenderer>().sprite = nums[num];
    }
	
	/* Public function */
	public void Crash()
	{
        string life = "Lives (" + (lives / 2) + ")";
        GameObject carLife = GameObject.Find(life);
        if(carLife != null)
            Destroy(carLife);
		lives--;
		if(lives < 1)
			gamestate = "gameover";
	}
}
