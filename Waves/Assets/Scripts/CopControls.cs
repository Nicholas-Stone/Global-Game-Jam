using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopControls : MonoBehaviour {

    public bool w = true, a = true, s = true, d = true;
    public List<GameObject> wcar;
	public List<GameObject> acar;
	public List<GameObject> scar;
	public List<GameObject> dcar;

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
		MainLoop ml = GameObject.Find("Main Camera").GetComponent<MainLoop>();
        wSign.GetComponent<SpriteRenderer>().sprite = redW;
        aSign.GetComponent<SpriteRenderer>().sprite = redA;
        sSign.GetComponent<SpriteRenderer>().sprite = redS;
        dSign.GetComponent<SpriteRenderer>().sprite = redD;
		wcar = ml.wCars;
		acar = ml.aCars;
		scar = ml.sCars;
		dcar = ml.dCars;
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
            if (w && wcar != null && wcar.Count > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in wcar)
                {
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
            if (a && acar != null && acar.Count > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in acar)
                {
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
            if (s && scar != null && scar.Count > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in scar)
                {
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
            if (d && dcar != null && dcar.Count > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in dcar)
                {
                    car.GetComponent<CarMovement>().stopped = false;
                }
            }
        }
    }
}
