using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingControls : MonoBehaviour {
    public Transform player;
    public Transform aim;
    public float radius;
    Vector3 wPos;
    Vector3 dir;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        wPos = Input.mousePosition;
        dir = wPos - player.position;
        wPos.z = player.position.z - Camera.main.transform.position.z;
        wPos = Camera.main.ScreenToWorldPoint(wPos);
        dir = Vector3.ClampMagnitude(dir, radius);
        aim.position = player.position + dir;
    }
}
