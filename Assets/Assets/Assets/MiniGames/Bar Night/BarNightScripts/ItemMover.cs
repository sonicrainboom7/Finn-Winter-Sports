﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMover : MonoBehaviour {
    private float speedModifier;
    private BarNightGameController controllerScript;
    public float lifeTime;
	// Use this for initialization
	void Start () {
        controllerScript = GameObject.Find("GameController").GetComponent<BarNightGameController>();
        speedModifier = controllerScript.speedMod;

    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, -((1.5f * speedModifier) * Time.deltaTime), 0);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
		
	}
}
