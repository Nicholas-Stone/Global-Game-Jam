using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        print("hi");
        if (col.gameObject.tag == "wcar")
        {
            col.gameObject.GetComponentInParent<CarMovement>().pass = GetComponentInParent<CopControls>().w;
            if(!col.gameObject.GetComponentInParent<CarMovement>().pass)
            {
                //get all cars in direction that haven't passed
                GameObject[] allWCar = GameObject.FindGameObjectsWithTag("wcar");
                GetComponentInParent<CopControls>().wcar = Array.FindAll(allWCar, car => !car.GetComponent<CarMovement>().pass);
                //set all cars to stop
                foreach (GameObject car in GetComponentInParent<CopControls>().wcar)
                {
                    car.GetComponent<CarMovement>().stopped = true;
                }
            }
            col.gameObject.GetComponentInParent<CarMovement>().hit = true;
        }
    }
}

//once car arrives at intersection, if set to not pass, car stops, if set to pass, car moves
