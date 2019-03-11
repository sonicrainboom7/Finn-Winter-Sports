using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkScript : MonoBehaviour {
    private FireworksGameController controller;
	// Use this for initialization
	void Start () {
        controller = GameObject.Find("GameController").GetComponent<FireworksGameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            controller.EndGame();
        }
    }

}
