using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public Sprite[] w;
    public Sprite[] a;
    public Sprite[] s;
    public Sprite[] d;

    public GameObject crash;

    private Vector3 movement;
	private int speed;
    private MainLoop ml;
    public bool hit = false; //hit intersection
    public bool stopped = false; // stuck in traffic
    public bool pass = false; // pass intersection
    string turn;

	// Use this for initialization
	void Start () {
        crash = GameObject.Find("Crash");
        ml = GameObject.Find("Main Camera").GetComponent<MainLoop>();
	}
	
	public void TransformCar(int type, char dir, int spd)
	{
		// TODO change car types
		switch(dir)
		{
			case 'W': // W case
				this.transform.position = new Vector3(-15f, 7f, 0f);
				movement = new Vector3(2, -1, 0); 
				transform.gameObject.tag = "wcar";
                GetComponent<SpriteRenderer>().sortingOrder = 4;
                GetComponent<SpriteRenderer>().sprite = w[type];
                if (type < 3)
                {
                    GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-2.0f, 0.1f),
                                                                                new Vector2(0.3f, -1f),
                                                                                new Vector2(1.2f, -0.5f),
                                                                                new Vector2(-1.0f, 0.6f)});
                }
                else if(type == 3)
                {
                    GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-2.3f, 0.3f),
                                                                                new Vector2(0.9f, -1.4f),
                                                                                new Vector2(1.6f, -1.1f),
                                                                                new Vector2(-1.6f, 0.6f)});
                }
                else
                {
                    GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-3.6f, 0.9f),
                                                                                new Vector2(1.7f, -1.8f),
                                                                                new Vector2(2.6f, -1.3f),
                                                                                new Vector2(-2.7f, 1.4f)});
                }
                break;
			case 'A': // A case
				this.transform.position = new Vector3(-10.5f, -6f, 0f);
				movement = new Vector3(2, 1, 0);
				transform.gameObject.tag ="acar";
                GetComponent<SpriteRenderer>().sortingOrder = 5;
                GetComponent<SpriteRenderer>().sprite = a[type];
                if (type < 3)
                {
                    GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-1.5f, -0.5f),
                                                                                new Vector2(-0.6f, -0.9f),
                                                                                new Vector2(1.5f, 0.3f),
                                                                                new Vector2(0.7f, 0.6f)});
                }
                else
                {
                    GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-2.4f, -0.9f),
                                                                                new Vector2(-1.4f, -1.5f),
                                                                                new Vector2(2.3f, 0.5f),
                                                                                new Vector2(1.3f, 0.9f)});
                }
                break;
			case 'S':
				this.transform.position = new Vector3(15f, -7f, 0f);
				movement = new Vector3(-2, 1, 0);
				transform.gameObject.tag = "scar";
                GetComponent<SpriteRenderer>().sortingOrder = 3;
                GetComponent<SpriteRenderer>().sprite = s[type];
                if (type < 3)
                {
                    GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-1.6f, 0.1f),
                                                                                new Vector2(0.5f, -1f),
                                                                                new Vector2(1.4f, -0.5f),
                                                                                new Vector2(-0.7f, 0.6f)});
                }
                else
                {
                    this.transform.position = new Vector3(15f, -6.5f, 0f);
                    GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-3.0f, 0.3f),
                                                                                new Vector2(0.4f, -1.4f),
                                                                                new Vector2(1.4f, -0.8f),
                                                                                new Vector2(-1.9f, 1.0f)});
                }
				break;
			case 'D':
				this.transform.position = new Vector3(12f, 6.5f, 0f);
				movement = new Vector3(-2, -1, 0);
				transform.gameObject.tag = "dcar";
                GetComponent<SpriteRenderer>().sortingOrder = 4;
                GetComponent<SpriteRenderer>().sprite = d[type];
                if (type < 3)
                {
                    GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-1.4f, -0.4f),
                                                                                new Vector2(-0.6f, -0.9f),
                                                                                new Vector2(1.6f, 0.2f),
                                                                                new Vector2(0.9f, 0.7f)});
                }
                else if (type == 3)
                {
                    GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-2.4f, -1.0f),
                                                                                new Vector2(-1.5f, -1.5f),
                                                                                new Vector2(2.2f, 0.5f),
                                                                                new Vector2(1.3f, 0.9f)});
                }
                else
                {
                    GetComponent<PolygonCollider2D>().SetPath(0, new Vector2[] {new Vector2(-3.0f, -1.3f),
                                                                                new Vector2(-2.0f, -1.7f),
                                                                                new Vector2(3.6f, 1.1f),
                                                                                new Vector2(2.4f, 1.4f)});
                }
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
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == tag)
        {
            col.gameObject.GetComponent<CarMovement>().stopped = true;
        }
        else if (col.gameObject.tag != tag)
        {
            crash.GetComponent<AudioSource>().Play();
            switch (col.gameObject.tag)
            {
                case "wcar":
                    StartCoroutine(death(col, 'W'));
                    //ml.Despawn('W', col.gameObject);
                    ml.Crash();
                    break;
                case "acar":
                    StartCoroutine(death(col, 'A'));
                    //ml.Despawn('A', col.gameObject);
                    ml.Crash();
                    break;
                case "scar":
                    StartCoroutine(death(col, 'S'));
                    //ml.Despawn('S', col.gameObject);
                    ml.Crash();
                    break;
                case "dcar":
                    StartCoroutine(death(col, 'D'));
                  //  ml.Despawn('D', col.gameObject);
                    ml.Crash();
                    break;
                case "ppl":
                    ml.Despawn('P', col.gameObject);
                    ml.Crash();
                    ml.Crash();
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator death(Collision2D col, char type)
    {
        col.gameObject.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Car");
        yield return new WaitForSeconds(0.5f);
        ml.Despawn(type, col.gameObject);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.GetComponent<CarMovement>().stopped = false;
    }
}
