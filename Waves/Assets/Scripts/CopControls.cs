using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopControls : MonoBehaviour {

    public bool w = true, a = true, s = true, d = true;
    public GameObject[] wcar;
	public GameObject[] acar;
	public GameObject[] scar;
	public GameObject[] dcar;


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
            if (a && acar != null && acar.Length > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in acar)
                {
                    car.GetComponent<CarMovement>().stopped = false;
                }
                //set front car to pass intersection
                acar[acar.Length - 1].GetComponent<CarMovement>().pass = true;
            }
        }
        if (Input.GetKeyDown("s"))
        {
            s = !s;
            if (s && scar != null && scar.Length > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in scar)
                {
                    car.GetComponent<CarMovement>().stopped = false;
                }
                //set front car to pass intersection
                scar[scar.Length - 1].GetComponent<CarMovement>().pass = true;
            }
        }
        if (Input.GetKeyDown("d"))
        {
            d = !d;
            if (d && dcar != null && dcar.Length > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in dcar)
                {
                    car.GetComponent<CarMovement>().stopped = false;
                }
                //set front car to pass intersection
                dcar[dcar.Length - 1].GetComponent<CarMovement>().pass = true;
            }
        }
    }
}
