using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingControls : MonoBehaviour {
    public GameObject firework;
    public Transform player;
    public Transform aim;
    public Slider powerSlider;
    private float power;
    public float maxPower;
    Vector3 dir;
	// Use this for initialization
	void Start () {
        power = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
        dir = player.position - aim.position;

        if (Input.GetMouseButton(0))   //Gather power for shot while holding down left click
        {
            power += Time.deltaTime * 3;
            powerSlider.value = power;
            Debug.Log(powerSlider.value);
            if (power >= maxPower)
            {
                power = maxPower;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Firefireworks();
            power = 0;
            powerSlider.value = power;
        }
        
	}
    void Firefireworks()
    {
        GameObject instFirework = Instantiate(firework, aim.position, Quaternion.FromToRotation(Vector3.up, dir));
        instFirework.GetComponent<Rigidbody>().AddForce(-dir * power,ForceMode.Impulse);
    }
}
