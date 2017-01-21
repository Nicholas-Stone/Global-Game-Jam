using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopControls : MonoBehaviour {

    public bool w = true, a = true, s = true, d = true;
    public GameObject wcar = null;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("w"))
        {
            w = !w;
            if (w && wcar != null)
            {
                wcar.GetComponent<CarMovement>().pass = true;
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
