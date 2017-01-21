using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    private Vector3 movement;
	private int speed;
    GameObject cop;
    public bool hit = false; //hit intersection
    public bool stopped = false; // stuck in traffic
    public bool pass = false; // pass intersection
    string turn = "right";

	// Use this for initialization
	void Start () {
        cop = GameObject.FindGameObjectWithTag("cop");
		// Spawn completely off screen
		/*
		this.transform.position = new Vector3(-20f, -20f, 0f);
		speed = 1;
		movement = Vector3.zero;
		*/
		Debug.Log("spawn");
	}
	
	public void TransformCar(string type, char dir, int spd)
	{
		Debug.Log(dir);
		// TODO change car types
		switch(dir)
		{
			case 'W': // W case
				this.transform.position = new Vector3(-15f, 6.5f, 0f);
				movement = new Vector3(2, -1, 0); 
				transform.gameObject.tag = "wcar";
				break;
			case 'A': // A case
				this.transform.position = new Vector3(-10f, -6.5f, 0f);
				movement = new Vector3(2, 1, 0);
				transform.gameObject.tag ="acar";
				break;
			case 'S':
				this.transform.position = new Vector3(15f, -6.5f, 0f);
				movement = new Vector3(-2, 1, 0);
				transform.gameObject.tag = "scar";
				break;
			case 'D':
				this.transform.position = new Vector3(12f, 6.5f, 0f);
				movement = new Vector3(-2, -1, 0);
				transform.gameObject.tag = "dcar";
				break;
			default: // don't do shit
				break;
		}
		speed = spd;
	}

    // Update is called once per frame
    void Update()
    {
        if ((!hit && !stopped) || pass)
        {
            transform.position = transform.position + movement * Time.deltaTime * speed;
        }
		else if(hit)
		{
			GameObject.Find("Main Camera").GetComponent<MainLoop>().Crash();
		}
    }
}
