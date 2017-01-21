using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public Vector3 movement;
    GameObject cop;
    public bool hit = false; //hit intersection
    public bool pass = false; // pass intersection
    string turn = "right";

	// Use this for initialization
	void Start () {
        cop = GameObject.FindGameObjectWithTag("cop");
        //movement = new Vector3(2, -1, 0).normalized;
	}

    // Update is called once per frame
    void Update()
    {
        if (!hit || pass)
        {
            transform.position = transform.position + movement * Time.deltaTime;
        }
    }
}
