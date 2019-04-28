using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SantaControls : MonoBehaviour {
    private float speed;
    public GameObject present1, present2, present3, present4; //Art for the present
    private GameObject present;
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
            int rand = Random.Range(1, 4);  //Select art for present randomly
            switch (rand)
            {
                case 1:
                     present = present1;
                    break;

                case 2:
                     present = present2;
                    break;

                case 3:
                     present = present3;
                    break;

                case 4:
                     present = present4;
                    break;
            }

            GameObject instObj = Instantiate(present, transform.position - (transform.up * 1.5f), transform.rotation);
            instObj.GetComponent<Rigidbody>().AddForce(-transform.up * 500);
            presentAmount--;
            presentAmountText.text = "Presents : " + presentAmount + " / 30";
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End")
        {
            controllerScript.GameOver();
            Destroy(gameObject);
        }
    }
}
