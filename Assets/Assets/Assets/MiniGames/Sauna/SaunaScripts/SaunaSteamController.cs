using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaunaSteamController : MonoBehaviour {
    public Transform steamUp, steamDown, steamMiddle;
    public GameObject steamCloud;
    public Text timeText;
    private float spawnTimer;
    private float time;
    public float startingTimer;
    public float speedMod;
	// Use this for initialization
	void Start () {
        time = 0;
        startingTimer = 4f;
        spawnTimer = startingTimer;
        speedMod = 1;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        spawnTimer -= Time.deltaTime;

        if(spawnTimer <= 0)
        {
            int rand = Random.Range(1,4);  //spawn a steam cloud in a random position
            switch (rand)
            {
                case 1 :
                    Instantiate(steamCloud, steamUp.position, transform.rotation);
                    break;

                case 2 :
                    Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                    break;

                case 3 :
                    Instantiate(steamCloud, steamDown.position, transform.rotation);
                    break;
            }
            startingTimer -= 0.1f;    //make spawning more frequent and faster after each cloud has spawned
            speedMod += 0.1f;
            if (startingTimer <= 0.2f)    
            {
                startingTimer = 0.2f;
            }
            spawnTimer = startingTimer;
        }
        timeText.text = "Time : " + (Mathf.Round(time * 100f) / 100f);
	}
}
