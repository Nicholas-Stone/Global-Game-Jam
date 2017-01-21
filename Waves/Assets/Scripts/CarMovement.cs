using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public Vector3 direction;
    public float speed = 1;
    GameObject cop;
    public bool hit = false; //hit intersection
    public bool stopped = false; // stuck in traffic
    public bool pass = false; // pass intersection
    string turn = "right";

	// Use this for initialization
	void Start () {
        cop = GameObject.FindGameObjectWithTag("cop");
	}

    // Update is called once per frame
    void Update()
    {
        if ((!hit && !stopped) || pass)
        {
            transform.position = transform.position + direction * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "wcar")
        {
            speed = Mathf.Min(speed, col.gameObject.GetComponent<CarMovement>().speed);
        }
    }
}
