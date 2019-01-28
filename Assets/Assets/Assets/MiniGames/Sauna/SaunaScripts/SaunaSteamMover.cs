﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaunaSteamMover : MonoBehaviour {
    public float speed;
    private SaunaSteamController controlScript;
    private float speedModifier;
    public float lifeTime;
    // Use this for initialization
    void Start () {
        controlScript = GameObject.Find("GameController").GetComponent<SaunaSteamController>();
        speedModifier = controlScript.speedMod;
	}
	
	// Update is called once per frame
	void Update () {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += -transform.right * Time.deltaTime * speed * speedModifier;
    }
}
