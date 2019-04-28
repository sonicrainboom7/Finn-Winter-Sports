using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    string input;
    string lowerCase;
    public AudioSource eating;
    private bool holdingA, holdingS, holdingD;
    private GameObject rHand, lHand;
    private Vector3 defaultHandPos;
    public GameObject aTrigger, sTrigger, dTrigger;
	// Use this for initialization
	void Start () {
        defaultHandPos = new Vector3(0, -8, 0);
        rHand = GameObject.Find("R.Hand");
        lHand = GameObject.Find("L.Hand");
        holdingA = false;
        holdingS = false;
        holdingD = false;
	}
	
	// Update is called once per frame
	void Update () {
        rHand.transform.position = defaultHandPos;
        lHand.transform.position = defaultHandPos;
        holdingA = false;
        holdingS = false;
        holdingD = false;

        if (Input.GetKey(KeyCode.A))
        {
            if (lHand.transform.position == defaultHandPos && rHand.transform.position == defaultHandPos)
            {
                lHand.transform.position = aTrigger.transform.position - new Vector3(0, 1.5f, 1);
            }
            holdingA = true;
            holdingS = false;
            holdingD = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (rHand.transform.position == defaultHandPos && lHand.transform.position == defaultHandPos)
            {
                rHand.transform.position = sTrigger.transform.position - new Vector3(0, 1.5f, 1);
            }
            holdingA = false;
            holdingS = true;
            holdingD = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (rHand.transform.position == defaultHandPos && lHand.transform.position == defaultHandPos)
            {
                rHand.transform.position = dTrigger.transform.position - new Vector3(0, 1.5f, 1);
            }
            holdingA = false;
            holdingS = false;
            holdingD = true;
        }

    }
    private void OnTriggerStay(Collider other)
    {
       
        switch (other.gameObject.tag)
        {
            case "A":
                if (holdingA == true)
                {
                    Destroy(other.gameObject);
                    eating.Play();
                    break;
                }
                break;

            case "S":
                if (holdingS == true)
                {
                    Destroy(other.gameObject);
                    eating.Play();
                    break;
                }
                break;

            case "D":
                if (holdingD == true)
                {
                    Destroy(other.gameObject);
                    eating.Play();
                    break;
                }
                break;
                
        }
    }
}
