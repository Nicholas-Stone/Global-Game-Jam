﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour {
	
	private MainLoop ml;

	// Use this for initialization
	void Start () {
		ml = GameObject.Find("Main Camera").GetComponent<MainLoop>(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "wcar")
        {
            col.gameObject.GetComponentInParent<CarMovement>().pass = col.gameObject.GetComponentInParent<CarMovement>().pass || GetComponentInParent<CopControls>().w;
            col.gameObject.GetComponentInParent<CarMovement>().hit = true;
			
        }
		if (col.gameObject.tag == "acar")
        {
            col.gameObject.GetComponentInParent<CarMovement>().pass = col.gameObject.GetComponentInParent<CarMovement>().pass || GetComponentInParent<CopControls>().a;
            col.gameObject.GetComponentInParent<CarMovement>().hit = true;
        }
		if (col.gameObject.tag == "scar")
        {
            col.gameObject.GetComponentInParent<CarMovement>().pass = col.gameObject.GetComponentInParent<CarMovement>().pass || GetComponentInParent<CopControls>().s;
            col.gameObject.GetComponentInParent<CarMovement>().hit = true;
        }
		if (col.gameObject.tag == "dcar")
        {
            col.gameObject.GetComponentInParent<CarMovement>().pass = col.gameObject.GetComponentInParent<CarMovement>().pass || GetComponentInParent<CopControls>().d;
            col.gameObject.GetComponentInParent<CarMovement>().hit = true;
        }
    }
}

//once car arrives at intersection, if set to not pass, car stops, if set to pass, car moves
