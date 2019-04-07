using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {
	private float speed;
	public float minSpeed;
	public float maxSpeed;
	public bool right = true;
	public bool hooked = false;
	int rotation; // 0 = right, 1 = left, 2 = up
	// Use this for initialization
	void Start () {
		speed = Random.Range(minSpeed,maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		if (hooked) {
			if (rotation != 2) {
				rotation = 2;
				transform.Rotate(0, 0, 90, Space.World);
			}
		} else if (right) {
			if (rotation != 0) {
				rotation = 0;
				transform.Rotate(0, 0, 0, Space.World);
			}
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		} else if (!right) { // left
			if (rotation != 1) {
				rotation = 1;
				transform.Rotate(0, 0, 180, Space.World);
			}
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
	}
}
