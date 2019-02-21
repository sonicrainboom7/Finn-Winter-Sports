using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SantaControls : MonoBehaviour {
    private float speed;
    public GameObject present;
    public int presentAmount;
    private float time;
    public Text presentAmountText;
    private SantaGameController controllerScript;

	// Use this for initialization
	void Start () {
        controllerScript = GameObject.Find("GameController").GetComponent<SantaGameController>();
        presentAmountText.text = "Presents : " + presentAmount + "/ 30";
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        speed = 1 + (time / 10);
        transform.Translate(0.1f * speed, 0, 0);

        if (Input.GetKeyDown(KeyCode.S) && presentAmount > 0)
        {
            Instantiate(present, transform.position - (transform.up), transform.rotation);
            presentAmount--;
            presentAmountText.text = "Presents : " + presentAmount + " / 30";
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End")
        {
            controllerScript.GameOver();
        }
    }
}
