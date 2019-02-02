using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {
    public float minWait;
    public float maxWait;
    private bool isSpawning;
    private BarNightGameController controllerScript;
    public GameObject[] obstacles;

    void Awake()
    {
        controllerScript = GameObject.Find("GameController").GetComponent<BarNightGameController>();
        isSpawning = false;
    }

    void Update()
    {
        if (controllerScript.timeRunning == true)
        {
            if (!isSpawning)
            {
                float timer = Random.Range(minWait, maxWait);
                Invoke("SpawnObject", timer);
                isSpawning = true;
            }
        }
    }

    void SpawnObject()
    {
        int rand = Random.Range(0, 3);
        Instantiate(obstacles[rand], transform.position, transform.rotation);
        isSpawning = false;
    }

}
