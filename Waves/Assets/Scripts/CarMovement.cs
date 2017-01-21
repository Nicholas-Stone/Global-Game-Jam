using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    Vector3 movement;
    GameObject cop;
    public bool pass = false; // pass intersection

	// Use this for initialization
	void Start () {
        cop = GameObject.FindGameObjectWithTag("cop");
        movement = new Vector3(1, 1, 0);
	}

    // Update is called once per frame
    void Update()
    {
        if (cop.GetComponent<CopControls>().a || pass)
        {
            transform.position = transform.position + movement * Time.deltaTime;
        }
    }
}
