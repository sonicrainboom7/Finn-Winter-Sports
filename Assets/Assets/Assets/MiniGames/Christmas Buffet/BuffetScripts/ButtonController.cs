using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    string input;
    string lowerCase;
    private bool holdingA, holdingS, holdingD;
	// Use this for initialization
	void Start () {
        holdingA = false;
        holdingS = false;
        holdingD = false;
	}
	
	// Update is called once per frame
	void Update () {
        holdingA = false;
        holdingS = false;
        holdingD = false;

        if (Input.GetKey(KeyCode.A))
        {
            holdingA = true;
            holdingS = false;
            holdingD = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            holdingA = false;
            holdingS = true;
            holdingD = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
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
                    Debug.Log("Tuhottiin A");
                    break;
                }
                break;

            case "S":
                if (holdingS == true)
                {
                    Destroy(other.gameObject);
                    Debug.Log("Tuhottiin S");
                    break;
                }
                break;

            case "D":
                if (holdingD == true)
                {
                    Destroy(other.gameObject);
                    Debug.Log("Tuhottiin D");
                    break;
                }
                break;
                
        }
    }
}
