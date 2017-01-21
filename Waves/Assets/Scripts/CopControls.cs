using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopControls : MonoBehaviour {

    public bool w, a, s, d;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("w"))
        {
            w = true;
            print("w");
        }
        if (Input.GetKeyDown("a"))
        {
            a = !a;
            print("a");
        }
        if (Input.GetKeyDown("s"))
        {
            s = true;
            print("s");
        }
        if (Input.GetKeyDown("d"))
        {
            d = true;
            print("d");
        }
    }
}
