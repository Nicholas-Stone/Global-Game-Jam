using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour {
	
	public AudioSource lmao;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnMouseDown()
	{
		if(!lmao.isPlaying)
		{
			SceneManager.LoadScene("Title");
		}
	}
}
