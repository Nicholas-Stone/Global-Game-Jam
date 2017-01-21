using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopControls : MonoBehaviour {

    public bool w = true, a = true, s = true, d = true;
    public GameObject[] wcar;
	public GameObject[] acar;
	public GameObject[] scar;
	public GameObject[] dcar;

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
            if (w && wcar != null && wcar.Length > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in wcar)
                {
                    car.GetComponent<CarMovement>().stopped = false;
                }
                //set front car to pass intersection
                wcar[wcar.Length - 1].GetComponent<CarMovement>().pass = true;
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
            if (a && acar != null && acar.Length > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in acar)
                {
                    car.GetComponent<CarMovement>().stopped = false;
                }
                //set front car to pass intersection
                acar[acar.Length - 1].GetComponent<CarMovement>().pass = true;
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
            if (s && scar != null && scar.Length > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in scar)
                {
                    car.GetComponent<CarMovement>().stopped = false;
                }
                //set front car to pass intersection
                scar[scar.Length - 1].GetComponent<CarMovement>().pass = true;
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
            if (d && dcar != null && dcar.Length > 0)
            {
                // set each car in direction to movings
                foreach (GameObject car in dcar)
                {
                    car.GetComponent<CarMovement>().stopped = false;
                }
                //set front car to pass intersection
                dcar[dcar.Length - 1].GetComponent<CarMovement>().pass = true;
            }
        }
    }
}
