using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksParticle : MonoBehaviour {
    public GameObject fireWorksParticle;

	// Use this for initialization
	void Start () {
		
	}
    void OnDestroy()
    {
        Debug.Log("Moro");
        Instantiate(fireWorksParticle, gameObject.transform.position, gameObject.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
