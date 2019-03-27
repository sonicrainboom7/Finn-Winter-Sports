using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaunaPlayer : MonoBehaviour {
    public Transform up, middle, down;
    private SaunaGameController controlScript;
    private float hp;
    public float maxHp;
    private Color c;
    private SpriteRenderer rend;
    // Use this for initialization
    void Start () {
        controlScript = GameObject.Find("GameController").GetComponent<SaunaGameController>();
        rend = GameObject.Find("Hemmo_o2").GetComponent<SpriteRenderer>();
        transform.position = middle.position;
        hp = maxHp;
        c = Color.white;
        rend.material.SetColor("_Color", c);

	}
	
	// Update is called once per frame
	void Update () {

        hp += Time.deltaTime;    // heal over time if not hit

        if (hp >= maxHp)
        {
            hp = maxHp;
        }
        if (hp <= 0)
        {
            hp = 0;
            controlScript.GameOver();
            Destroy(gameObject);
        }

        c = Color.Lerp(Color.red, Color.white, (hp / 100));  //Gradually change color when player is damaged
        rend.material.SetColor("_Color", c);

        if (Input.anyKeyDown) { 
                                                            
            switch (Input.inputString)          //Make the player move between boards based on a keypress and current location
            {

                case "w" :
                    if (transform.position == middle.position)  
                    {
                        transform.position = up.position;
                    } else if (transform.position == down.position)
                    {
                        transform.position = middle.position;
                    }
                    break;
                case "s":

                    if (transform.position == middle.position)
                    {
                        transform.position = down.position;
                    }
                    else if (transform.position == up.position)
                    {
                        transform.position = middle.position;
                    }

                    break;

            }

        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Steam")
        {
            hp -= 25;
        }
    }
}
