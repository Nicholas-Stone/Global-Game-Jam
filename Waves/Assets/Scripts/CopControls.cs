using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopControls : MonoBehaviour {

    public bool w, a, s, d;
	private MainLoop ml;

    public Sprite greenW;
    public Sprite greenA;
    public Sprite greenS;
    public Sprite greenD;
    public Sprite redW;
    public Sprite redA;
    public Sprite redS;
    public Sprite redD;

    public GameObject wSign;
    public GameObject aSign;
    public GameObject sSign;
    public GameObject dSign;
	

    // Use this for initialization
    void Start () {
		ml = GameObject.Find("Main Camera").GetComponent<MainLoop>();
        wSign.GetComponent<SpriteRenderer>().sprite = redW;
        aSign.GetComponent<SpriteRenderer>().sprite = redA;
        sSign.GetComponent<SpriteRenderer>().sprite = redS;
        dSign.GetComponent<SpriteRenderer>().sprite = redD;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown("w"))
        {
            //toggle w direction of intersection
            w = !w;
            if (w)
            {
                wSign.GetComponent<SpriteRenderer>().sprite = greenW;
            }
            else
            {
                wSign.GetComponent<SpriteRenderer>().sprite = redW;
            }
			print(ml.wCars.Count);
            if (w && ml.wCars != null && ml.wCars.Count > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in ml.wCars)
                {
					car.GetComponent<CarMovement>().pass = w;
                    car.GetComponent<CarMovement>().stopped = false;
                }
            }
        }
        if (Input.GetKeyDown("a"))
        {
            a = !a;
            if (a)
            {
                aSign.GetComponent<SpriteRenderer>().sprite = greenA;
            }
            else
            {
                aSign.GetComponent<SpriteRenderer>().sprite = redA;
            }
            if (a && ml.aCars != null && ml.aCars.Count > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in ml.aCars)
                {
					car.GetComponent<CarMovement>().pass = a;
                    car.GetComponent<CarMovement>().stopped = false;
                }
            }
        }
        if (Input.GetKeyDown("s"))
        {
            s = !s;
            if (s)
            {
                sSign.GetComponent<SpriteRenderer>().sprite = greenS;
            }
            else
            {
                sSign.GetComponent<SpriteRenderer>().sprite = redS;
            }
            if (s && ml.sCars != null && ml.sCars.Count > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in ml.sCars)
                {
					car.GetComponent<CarMovement>().pass = s;
                    car.GetComponent<CarMovement>().stopped = false;
                }
            }
        }
        if (Input.GetKeyDown("d"))
        {
            d = !d;
            if (d)
            {
                dSign.GetComponent<SpriteRenderer>().sprite = greenD;
            }
            else
            {
                dSign.GetComponent<SpriteRenderer>().sprite = redD;
            }
			
            if (ml.dCars != null && ml.dCars.Count > 0)
            {
				print("nani");
                // set each car in direction to movings
                foreach (GameObject car in ml.dCars)
                {
					print(d);
					car.GetComponent<CarMovement>().pass = d;
                    car.GetComponent<CarMovement>().stopped = false;
                }
            }
        }
    }
}
