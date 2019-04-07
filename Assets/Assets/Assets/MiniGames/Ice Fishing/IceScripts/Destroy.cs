using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision other){
		Destroy(other.gameObject.transform.parent.gameObject);
		Debug.Log("nakki");
	}
}
