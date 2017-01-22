using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour {
	
	private MainLoop ml;

	// Use this for initialization
	void Start () {
		//ml = 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "wcar")
        {
            col.gameObject.GetComponentInParent<CarMovement>().pass = GetComponentInParent<CopControls>().w;
            if(!col.gameObject.GetComponentInParent<CarMovement>().pass)
            {
                //set all cars to stop
                foreach (GameObject car in GetComponentInParent<CopControls>().wcar)
                {
                    car.GetComponent<CarMovement>().stopped = true;
                }
            }
            col.gameObject.GetComponentInParent<CarMovement>().hit = true;
			
        }
		if (col.gameObject.tag == "acar")
        {
            col.gameObject.GetComponentInParent<CarMovement>().pass = GetComponentInParent<CopControls>().a;
            if(!col.gameObject.GetComponentInParent<CarMovement>().pass)
            {
                //set all cars to stop
                foreach (GameObject car in GetComponentInParent<CopControls>().acar)
                {
					print("car");
                    car.GetComponent<CarMovement>().stopped = true;
                }
            }
            col.gameObject.GetComponentInParent<CarMovement>().hit = true;
        }
		if (col.gameObject.tag == "scar")
        {
            col.gameObject.GetComponentInParent<CarMovement>().pass = GetComponentInParent<CopControls>().s;
            if(!col.gameObject.GetComponentInParent<CarMovement>().pass)
            {
                //set all cars to stop
                foreach (GameObject car in GetComponentInParent<CopControls>().scar)
                {
                    car.GetComponent<CarMovement>().stopped = true;
                }
            }
            col.gameObject.GetComponentInParent<CarMovement>().hit = true;
        }
		if (col.gameObject.tag == "dcar")
        {
            col.gameObject.GetComponentInParent<CarMovement>().pass = GetComponentInParent<CopControls>().d;
            if(!col.gameObject.GetComponentInParent<CarMovement>().pass)
            {
                //set all cars to stop
                foreach (GameObject car in GetComponentInParent<CopControls>().dcar)
                {
                    car.GetComponent<CarMovement>().stopped = true;
                }
            }
            col.gameObject.GetComponentInParent<CarMovement>().hit = true;
        }
    }
}

//once car arrives at intersection, if set to not pass, car stops, if set to pass, car moves
