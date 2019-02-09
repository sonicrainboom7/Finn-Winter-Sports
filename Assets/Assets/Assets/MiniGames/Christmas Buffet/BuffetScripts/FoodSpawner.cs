using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float minWait;
    public float maxWait;
    private bool isSpawning;
    private BuffetGameController controllerScript;
    public GameObject food;

    void Awake()
    {
        controllerScript = GameObject.Find("GameController").GetComponent<BuffetGameController>();
        isSpawning = false;
    }

    void Update()
    {
        if (controllerScript.timeRunning == true)
        {

            if (!isSpawning)
            {
                float reducedMinWait = minWait / ((controllerScript.time / 60) + 1);
                float reducedMaxWait = maxWait / ((controllerScript.time / 60) + 1);
                if (reducedMinWait <= 1f)
                {
                    reducedMinWait = 1f;
                }
                if (reducedMaxWait <= 2.5f)
                {
                    reducedMaxWait = 2.5f;
                }
                float timer = Random.Range(reducedMinWait, reducedMaxWait);
                Invoke("SpawnObject", timer);
                isSpawning = true;
            }
        }
    }

    void SpawnObject()
    {
        Instantiate(food, transform.position, transform.rotation);
        isSpawning = false;
    }

}
