using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {
	float delay = 0;
	bool hooked;
	GameObject hookedFish;
	public GameObject gameController;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (delay > 0 && gameObject.transform.position.y < 2) {
			delay -= Time.deltaTime;
			transform.Translate(Vector3.up * Time.deltaTime * 3);
		} else {
			transform.Translate(Vector3.down * Time.deltaTime * 2);
		}
		if (Input.GetKeyDown("space") && gameController.GetComponent<IceFishingGameController>().timeRunning){
			delay = 0.2f;
		}
		if (gameObject.transform.position.y < -5)
			delay = 0.1f;
	}
	void OnCollisionEnter (Collision col)
    {
		//Debug.Log("törmäys");
        if(col.gameObject.tag == "Fish" && !hooked)
        {
			hooked = true;
			//Debug.Log("kala");
			col.gameObject.transform.parent.GetComponent<Fish>().hooked = true;
			hookedFish = col.gameObject.transform.parent.gameObject;
		}
		if(col.gameObject.tag == "Top" && hooked)
        {
			hooked = false;
			Debug.Log("pisteitä");
			gameController.GetComponent<IceFishingGameController>().score += hookedFish.GetComponent<Fish>().score;
			Destroy(hookedFish);
			hookedFish = null;
		}
	}
}
