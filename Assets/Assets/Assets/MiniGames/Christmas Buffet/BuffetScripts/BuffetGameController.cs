using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffetGameController : MonoBehaviour {
    public bool timeRunning;
    public float time;
    public float speedMod;
	// Use this for initialization
	void Start () {
        timeRunning = true;
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeRunning == true)
        {
            time += Time.deltaTime;
            speedMod = (time / 60) + 1;
        }
    }
}
