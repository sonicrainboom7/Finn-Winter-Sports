using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaunaGameController : MonoBehaviour
{
    public Transform steamUp, steamDown, steamMiddle;
    public GameObject steamCloud1;
    public GameObject steamCloud2;
    private GameObject steamCloud;
    public Text timeText;
    private float spawnTimer;
    private float time;
    public float startingTimer;
    public float speedMod;
    private int rand1;
    private int rand2;
    private bool timeRunning;
    public GameObject endCanvas;
    private SaunaLeaderBoard leaderBoard;
    public Button leaveGame;
    public AudioClip hiss;
    public AudioSource hissSource;
    private float saunaHissTimer;
   // public AudioSource audio;
    // Use this for initialization
    void Start()
    {
        leaveGame.onClick.AddListener(BackToMenu);
        leaderBoard = GameObject.Find("GameController").GetComponent<SaunaLeaderBoard>();
        timeRunning = true;
        time = 0;
        spawnTimer = startingTimer;
    }


    IEnumerator TripleSteam()   // adjust these for difficulty
    {
        int randCloud = Random.Range(1, 3);
        switch (randCloud)
        {
            case 1:
                steamCloud = steamCloud1;
                Debug.Log(steamCloud);
                break;
               

            case 2:
                steamCloud = steamCloud2;
                Debug.Log(steamCloud);
                break;

        }
        int rand = Random.Range(1, 7);
        switch (rand) {
            
            case 1:
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                break;

            case 2:
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                break;

            case 3:
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                break;
            case 4:
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                break;
            case 5:
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.8f));
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                break;
            case 6:
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                yield return new WaitForSeconds(Random.Range(0.8f, 1.5f));
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                break;

        

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
        saunaHissTimer += Time.deltaTime;

        if(saunaHissTimer >= 15f)
        {
            hissSource.PlayOneShot(hiss, 0.5f);
            saunaHissTimer = 0;
        }
        
        if (timeRunning == true)
        {
            time += Time.deltaTime;
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)   
            {
                StartCoroutine(TripleSteam());

                startingTimer -= 0.1f;    //make spawning more frequent and faster after each cloud has spawned
                speedMod += 0.2f;
                if (startingTimer <= 1)
                {
                    startingTimer = 1;
                }
                spawnTimer = startingTimer;
                if (speedMod >= 20)
                {
                    speedMod = 20;
                }
            }
        }
            timeText.text = "Time : " + (Mathf.Round(time * 100f) / 100f);
    }
    


    public void GameOver()
    {
        timeRunning = false;
        endCanvas.SetActive(true);
        leaderBoard.AddRecord(PlayerPrefs.GetString("Name", "Anonymous"), (Mathf.Round(time * 100f) / 100f));  //Add the players name and Score to the leaderboard
        leaderBoard.GetHighScores();
        
    }
    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}


