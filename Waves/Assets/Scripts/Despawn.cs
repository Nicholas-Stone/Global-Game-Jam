using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour {
	private MainLoop ml;

	// Use this for initialization
	void Start () {
		ml = GameObject.Find("Main Camera").GetComponent<MainLoop>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		// TODO despawn car or despawn pedestrians
		if(col.gameObject.tag == "wcar")
			ml.Despawn('W', col.gameObject);
		if(col.gameObject.tag == "acar")
			ml.Despawn('A', col.gameObject);
		if(col.gameObject.tag == "scar")
			ml.Despawn('S', col.gameObject);
		if(col.gameObject.tag == "dcar")
			ml.Despawn('D', col.gameObject);
		if(col.gameObject.tag == "pedestrian")
			ml.Despawn('P', col.gameObject);
	}
}
