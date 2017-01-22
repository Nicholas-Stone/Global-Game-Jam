using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public Sprite w;
    public Sprite a;
    public Sprite s;
    public Sprite d;

    private Vector3 movement;
	private int speed;
    private MainLoop ml;
    public bool hit = false; //hit intersection
    public bool stopped = false; // stuck in traffic
    public bool pass = false; // pass intersection
    string turn = "right";

	// Use this for initialization
	void Start () {
        ml = GameObject.Find("Main Camera").GetComponent<MainLoop>();
	}
	
	public void TransformCar(string type, char dir, int spd)
	{
		// TODO change car types
		switch(dir)
		{
			case 'W': // W case
				this.transform.position = new Vector3(-15f, 7f, 0f);
				movement = new Vector3(2, -1, 0); 
				transform.gameObject.tag = "wcar";
                GetComponent<SpriteRenderer>().sortingOrder = 0;
                GetComponent<SpriteRenderer>().sprite = w;
                GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-1.9f, 0.2f),
                                                                            new Vector2(0.4f, -1f),
                                                                            new Vector2(1.3f, -0.5f),
                                                                            new Vector2(-0.9f, 0.8f)});
				break;
			case 'A': // A case
				this.transform.position = new Vector3(-10.5f, -6f, 0f);
				movement = new Vector3(2, 1, 0);
				transform.gameObject.tag ="acar";
                GetComponent<SpriteRenderer>().sortingOrder = 0;
                GetComponent<SpriteRenderer>().sprite = a;
                GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-1.6f, -0.4f),
                                                                            new Vector2(-0.6f, -0.9f),
                                                                            new Vector2(1.3f, 0.1f),
                                                                            new Vector2(0.2f, 0.7f)});
				break;
			case 'S':
				this.transform.position = new Vector3(15f, -7f, 0f);
				movement = new Vector3(-2, 1, 0);
				transform.gameObject.tag = "scar";
                GetComponent<SpriteRenderer>().sortingOrder = 4;
                GetComponent<SpriteRenderer>().sprite = s;
                GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-1.6f, 0.1f),
                                                                            new Vector2(0.4f, -1f),
                                                                            new Vector2(1.3f, -0.5f),
                                                                            new Vector2(-0.7f, 0.6f)});
				break;
			case 'D':
				this.transform.position = new Vector3(12f, 6.5f, 0f);
				movement = new Vector3(-2, -1, 0);
				transform.gameObject.tag = "dcar";
                GetComponent<SpriteRenderer>().sortingOrder = 4;
                GetComponent<SpriteRenderer>().sprite = d;
                GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-1.6f, -0.4f),
                                                                            new Vector2(-0.6f, -0.9f),
                                                                            new Vector2(1.3f, 0.1f),
                                                                            new Vector2(0.2f, 0.7f)});
				break;
			default:
				break;
		}
		speed = spd;
	}

    // Update is called once per frame
    void Update()
    {
        if ((!hit && !stopped) || pass)
        {
            transform.position = transform.position + movement * Time.deltaTime * speed;
        }
		else if(hit)
		{
			GameObject.Find("Main Camera").GetComponent<MainLoop>().Crash();
		}
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<CarMovement>().stopped = true;
    }
}
