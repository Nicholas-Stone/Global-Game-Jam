using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianWalk : MonoBehaviour {

    public string start = "W";
    public Vector3 movement;
    public float speed = 1;
    public static GameObject[] locations;

    private bool notloaded = true;
	// Use this for initialization
	void Start () {
        //   locations = new GameObject[8];
        // for(int i = 0; i < 8; i++)
        //{
        //     locations[i] = GameObject.Find("pplspawn" + i);
        //}
        locations = GameObject.Find("Main Camera").GetComponent<MainLoop>().locations;
        notloaded = false;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + movement * Time.deltaTime * speed;
    }

    public void Transform(int pos)
    {
        if (notloaded)
        {
            locations = GameObject.Find("Main Camera").GetComponent<MainLoop>().locations;
        }
        transform.gameObject.tag = "ppl";
        int type = Random.Range(0, 3);
        switch (pos)
        {
            case 0:
                transform.position = locations[0].transform.position;
                movement = new Vector3(2, -1, 0);
                speed = Random.value + 0.3f;
                GetComponent<SpriteRenderer>().sortingOrder = 7;
                string sprite0 = "Person" + type;
                string animator0 = "Pedestrian" + type + "Front";
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sprite0);
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animator0);
                break;
            case 1:
                transform.position = locations[1].transform.position;
                movement = new Vector3(2, -1, 0);
                speed = Random.value + 0.3f;
                GetComponent<SpriteRenderer>().sortingOrder = 9;
                string sprite1 = "Person" + type;
                string animator1 = "Pedestrian" + type + "Front";
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sprite1);
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animator1);
                break;
            case 2:
                transform.position = locations[2].transform.position;
                movement = new Vector3(-2, -1, 0);
                speed = Random.value + 0.3f;
                GetComponent<SpriteRenderer>().sortingOrder = 7;
                string sprite2 = "Person" + type + "Flipped";
                string animator2 = "Pedestrian" + type + "FrontFlip";
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sprite2);
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animator2);
                break;
            case 3:
                transform.position = locations[3].transform.position;
                movement = new Vector3(-2, -1, 0);
                speed = Random.value + 0.3f;
                GetComponent<SpriteRenderer>().sortingOrder = 9;
                string sprite3 = "Person" + type + "Flipped";
                string animator3 = "Pedestrian" + type + "FrontFlip";
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sprite3);
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animator3);
                break;
            case 4:
                transform.position = locations[4].transform.position;
                movement = new Vector3(2, 1, 0);
                speed = Random.value + 0.3f;
                GetComponent<SpriteRenderer>().sortingOrder = 7;
                string sprite4 = "Person" + type + "Back";
                string animator4 = "Pedestrian" + type + "Back";
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sprite4);
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animator4);
                break;
            case 5:
                transform.position = locations[5].transform.position;
                movement = new Vector3(-2, 1, 0);
                speed = Random.value + 0.3f;
                GetComponent<SpriteRenderer>().sortingOrder = 7;
                string sprite5 = "Person" + type + "BackFlipped";
                string animator5 = "Pedestrian" + type + "BackFlip";
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sprite5);
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animator5);
                break;
            case 6:
                transform.position = locations[6].transform.position;
                movement = new Vector3(2, 1, 0);
                speed = Random.value + 0.3f;
                GetComponent<SpriteRenderer>().sortingOrder = 9;
                string sprite6 = "Person" + type + "Back";
                string animator6 = "Pedestrian" + type + "Back";
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sprite6);
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animator6);
                break;
            case 7:
                transform.position = locations[7].transform.position;
                movement = new Vector3(-2, 1, 0);
                speed = Random.value + 0.3f;
                GetComponent<SpriteRenderer>().sortingOrder = 9;
                string sprite7 = "Person" + type + "BackFlipped";
                string animator7 = "Pedestrian" + type + "BackFlip";
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(sprite7);
                GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(animator7);
                break;
            default:
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "ppl")
        {
            Physics2D.IgnoreCollision(col.collider, GetComponent<Collider2D>());
        }
    }
}
