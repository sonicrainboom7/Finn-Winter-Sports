using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarNightPlayerMovement : MonoBehaviour {
    public float speed;
    public float directionTimer;
    public int maxHp;
    private int hp;
    private float startDirectionTimer;
    private bool moveLeft, moveRight;
    public float drunkenessLevel;
    public SpriteRenderer idle, left, right;
    private SpriteRenderer rend;
    public Text lives;
    private BarNightGameController controllerScript;
    private float walkCycleTimer;
    public AudioClip beerGet;
    public AudioSource beerSource;
    public AudioClip obstacleHit;
    public AudioSource obstacleSource;
    // Use this for initialization
    void Start () {
        startDirectionTimer = directionTimer;
        controllerScript = GameObject.Find("GameController").GetComponent<BarNightGameController>();
        moveRight = false;
        moveLeft = false;
        hp = maxHp;
        lives.text = "Lives : " + hp;
        rend = GameObject.Find("Juoksu_1").GetComponent<SpriteRenderer>();
        walkCycleTimer = 0;
	}

	
	// Update is called once per frame
	void Update () {
        walkCycleTimer += Time.deltaTime;
        if (walkCycleTimer <= 0.3f)
        {
            rend.sprite = left.sprite;
        }
        else if (walkCycleTimer > 0.3f)
        {
            rend.sprite = right.sprite;
        }
        if (walkCycleTimer >= 0.6f)
        {
            walkCycleTimer = 0;
        }
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
            if (beerSource.isPlaying == false)
            {
                beerSource.PlayOneShot(beerGet, 0.5f);
            }
            drunkenessLevel += 0.25f;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Obstacle")
        {
            if (obstacleSource.isPlaying == false)
            {
                obstacleSource.PlayOneShot(obstacleHit, 0.5f);
            }
            hp -= 1;
            lives.text = "Lives : " + hp;
            Destroy(col.gameObject);
            if (hp <= 0)
            {
                controllerScript.GameOver();
                Destroy(gameObject);
            }
        }
    }

}
