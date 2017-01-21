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
        if (col.gameObject.tag == "car")
            col.gameObject.GetComponent<CarMovement>().pass = true;
    }
}
