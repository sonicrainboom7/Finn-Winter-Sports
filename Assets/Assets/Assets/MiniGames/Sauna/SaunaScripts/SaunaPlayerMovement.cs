using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaunaPlayerMovement : MonoBehaviour {
    public Transform up, middle, down;
    public float lifeTime;
	// Use this for initialization
	void Start () {
        transform.position = middle.position;
		
	}
	
	// Update is called once per frame
	void Update () {
  
        if (Input.anyKeyDown) { 
                                                            
            switch (Input.inputString)          //Make the player move between boards based on a keypress and current location
            {

                case "w" :
                    if (transform.position == middle.position)  
                    {
                        transform.position = up.position;
                    } else if (transform.position == down.position)
                    {
                        transform.position = middle.position;
                    }
                    break;
                case "s":

                    if (transform.position == middle.position)
                    {
                        transform.position = down.position;
                    }
                    else if (transform.position == up.position)
                    {
                        transform.position = middle.position;
                    }

                    break;

            }

        }
	}
}
