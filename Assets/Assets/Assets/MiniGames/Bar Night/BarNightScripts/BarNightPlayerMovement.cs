using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNightPlayerMovement : MonoBehaviour {
    public float speed;
    public float directionTimer;
    public int maxHp;
    private int hp;
    private float startDirectionTimer;
    private bool moveLeft, moveRight;
    public float drunkenessLevel;
    private BarNightGameController controllerScript;
    // Use this for initialization
    void Start () {
        startDirectionTimer = directionTimer;
        controllerScript = GameObject.Find("GameController").GetComponent<BarNightGameController>();
        moveRight = false;
        moveLeft = false;
        hp = maxHp;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(Input.GetAxis("Horizontal") * speed, 0, 0);
        directionTimer -= Time.deltaTime;
        if (directionTimer <= 0)          // choose a direction to which the player will gravitate towards;
        {
            int rand = Random.Range(0, 2);
            switch (rand)
            {

                case 0:
                    moveRight = false;
                    moveLeft = true;
                    directionTimer = startDirectionTimer;
                    break;

                case 1:
                    moveLeft = false;
                    moveRight = true;
                    directionTimer = startDirectionTimer;
                    break;
            }
        }
        if (moveLeft == true)
        {
            this.transform.Translate((-2 * drunkenessLevel) * Time.deltaTime, 0, 0);
        }
        if (moveRight == true)
        {
            this.transform.Translate((2 * drunkenessLevel) * Time.deltaTime, 0, 0);
        }
      
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Beer")
        {
            drunkenessLevel += 0.25f;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Obstacle")
        {
            hp -= 1;
            Destroy(col.gameObject);
            if (hp <= 0)
            {
                controllerScript.GameOver();
                Destroy(gameObject);
            }
        }
    }

}
