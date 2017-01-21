using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianWalk : MonoBehaviour {

    public string start = "W";
    public Vector3 movement;
    public float speed = 1;

	// Use this for initialization
	void Start () {
        movement = new Vector3(2, -1, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + movement * Time.deltaTime * speed;
    }
}
