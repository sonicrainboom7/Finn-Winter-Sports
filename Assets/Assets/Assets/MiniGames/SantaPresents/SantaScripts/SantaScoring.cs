using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaScoring : MonoBehaviour {
    private SantaGameController controllerScript;
    // Use this for initialization
    void Start () {
        controllerScript = GameObject.Find("GameController").GetComponent<SantaGameController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        Renderer rend = collision.gameObject.GetComponent<Renderer>();
        rend.material.SetColor("_Color",Color.red);
        controllerScript.ScoreIncrease();
        Destroy(collision.gameObject.GetComponent<BoxCollider>());
        Destroy(gameObject);
    }
}
