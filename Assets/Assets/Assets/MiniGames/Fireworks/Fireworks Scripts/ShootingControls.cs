using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingControls : MonoBehaviour {
    public GameObject firework;
    public Transform player;
    public Transform aim;
    public Text windSpeedValue;
    public Slider powerSlider;
    private float power;
    public float maxPower;
    public float shotCount;
    private float windSpeed;
    Vector3 dir;
	// Use this for initialization
	void Start () {
        power = 1;
        shotCount = 0;
        windSpeed = Mathf.Round(Random.Range(-10f, 10f));
        
	}

   
	
	// Update is called once per frame
	void Update ()
    {
        dir = player.position - aim.position;
        if (windSpeed <= 0)
        {
            windSpeedValue.text = "Wind direction : <- " + Mathf.Abs(windSpeed);
        }
        else if (windSpeed >= 0)
        {
            windSpeedValue.text = "Wind direction : " + Mathf.Abs(windSpeed) + " ->";
        }
        if (Input.GetMouseButton(0))   //Gather power for shot while holding down left click
        {
            power += Time.deltaTime * 3;
            powerSlider.value = power;
           // Debug.Log(powerSlider.value);
            if (power >= maxPower)
            {
                power = maxPower;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Firefireworks();
            windSpeed = Mathf.Round(Random.Range(-10f, 10f)); // change the power of wind after every shot
            power = 1;
            powerSlider.value = power;
            shotCount++;
        }
        
	}
    void Firefireworks()
    {
        GameObject instFirework = Instantiate(firework, aim.position, Quaternion.FromToRotation(Vector3.up, dir));
        if (windSpeed >= 0)
        {
            instFirework.GetComponent<Rigidbody>().AddForce((-dir * (power + windSpeed)), ForceMode.Impulse);
        } else if (windSpeed <= 0)
        {
            instFirework.GetComponent<Rigidbody>().AddForce((-dir * (power)), ForceMode.Impulse);
            instFirework.GetComponent<Rigidbody>().AddForce(-(transform.right * Mathf.Abs(windSpeed)), ForceMode.Impulse);

        }
        Destroy(instFirework, 5f);
        //Debug.Log((-dir * (power + windSpeed)));
    }
}
