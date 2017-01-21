using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopControls : MonoBehaviour {

    public bool w = true, a = true, s = true, d = true;
    public GameObject[] wcar;


    // Use this for initialization
    void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("w"))
        {
            //toggle w direction of intersection
            w = !w;
            if (w && wcar != null && wcar.Length > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in wcar)
                {
                    car.GetComponent<CarMovement>().stopped = false;
                }
                //set front car to pass intersection
                wcar[wcar.Length - 1].GetComponent<CarMovement>().pass = true;
            }
        }
        if (Input.GetKeyDown("a"))
        {
            a = !a;
            print("a");
        }
        if (Input.GetKeyDown("s"))
        {
            s = !s;
            print("s");
        }
        if (Input.GetKeyDown("d"))
        {
            d = !d;
            print("d");
        }
    }
}
