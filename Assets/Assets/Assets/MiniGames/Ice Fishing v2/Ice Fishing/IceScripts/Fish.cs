using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {
	private float speed;
	public float minSpeed;
	public float maxSpeed;
	public float score;
	public bool right = true;
	public bool hooked = false;
	GameObject hook;
	int rotation; // 0 = right, 1 = left, 2 = up
	// Use this for initialization
	void Start () {
		speed = Random.Range(minSpeed,maxSpeed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (hooked) {
			hook = GameObject.Find("Hook");
			if (rotation != 2 && right) {
				rotation = 2;
				transform.Rotate(0, 0, 90, Space.World);
				transform.Translate(Vector3.left * 0.3f);
				gameObject.transform.parent = hook.transform;
				transform.Translate(Vector3.down * 0.8f);
			}
			else if (rotation != 2 && !right) {
				rotation = 2;
				transform.Rotate(0, 0, -90, Space.World);
				transform.Translate(Vector3.left * 0.3f);
				gameObject.transform.parent = hook.transform;
				transform.Translate(Vector3.down * 0.8f);
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
				transform.Rotate(0, 180, 0, Space.World);
			}
			transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
	}
}
