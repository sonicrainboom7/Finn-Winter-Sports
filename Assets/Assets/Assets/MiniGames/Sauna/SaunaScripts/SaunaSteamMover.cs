using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaunaSteamMover : MonoBehaviour {
    public float speed;
    private SaunaSteamController controlScript;
    private float speedModifier;
    private float constantSpeedMod;
    public float lifeTime;
    // Use this for initialization
    void Start () {
        controlScript = GameObject.Find("GameController").GetComponent<SaunaSteamController>();
        speedModifier = controlScript.speedMod;
        constantSpeedMod = speedModifier;  // this is to make sure the steam doesnt get faster while moving
        
	}
	
	// Update is called once per frame
	void Update () {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += -transform.right * Time.deltaTime * speed * constantSpeedMod;
    }
}
