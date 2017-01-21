using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    Vector3 movement;

	// Use this for initialization
	void Start () {
        movement = new Vector3(1, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + movement * Time.deltaTime;
	}
}
