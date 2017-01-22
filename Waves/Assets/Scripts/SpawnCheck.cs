using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheck : MonoBehaviour {
	
	public char spawnPoint;
	private MainLoop ml;

	// Use this for initialization
	void Start () {
		ml = GameObject.Find("Main Camera").GetComponent<MainLoop>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		switch(spawnPoint)
		{
			case 'W':
				if(other.gameObject.tag == "car")
					ml.wSpawn = false; 
				break;
			case 'A':
				if(other.gameObject.tag == "car")
					ml.aSpawn = false;
				break;
			case 'S':
				if(other.gameObject.tag == "car")
					ml.sSpawn = false;
				break;
			case 'D':
				if(other.gameObject.tag == "car")
					ml.dSpawn = false;
				break;
			default:
				break;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		switch(spawnPoint)
		{
			case 'W':
				if(other.gameObject.tag == "wcar")
					ml.wSpawn = true; 
				break;
			case 'A':
				if(other.gameObject.tag == "acar")
					ml.aSpawn = true;
				break;
			case 'S':
				if(other.gameObject.tag == "scar")
					ml.sSpawn = true;
				break;
			case 'D':
				if(other.gameObject.tag == "dcar")
					ml.dSpawn = true;
				break;
			default:
				break;
		}
	}
}
