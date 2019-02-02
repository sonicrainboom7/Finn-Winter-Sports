using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaunaGameController : MonoBehaviour
{
    public Transform steamUp, steamDown, steamMiddle;
    public GameObject steamCloud;
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
    // Use this for initialization
    void Start()
    {
        leaveGame.onClick.AddListener(BackToMenu);
        leaderBoard = GameObject.Find("GameController").GetComponent<SaunaLeaderBoard>();
        timeRunning = true;
        time = 0;
        spawnTimer = startingTimer;
    }


    IEnumerator TripleSteam()
    {
        rand1 = Random.Range(1, 7);
        switch (rand1)
        {
            case 1:
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                yield return new WaitForSeconds(0.3f);
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                yield return new WaitForSeconds(0.2f);
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                break;

            case 2:
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                yield return new WaitForSeconds(0.2f);
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                yield return new WaitForSeconds(0.3f);
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                break;

            case 3:
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                yield return new WaitForSeconds(0.3f);
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                yield return new WaitForSeconds(0.4f);
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                break;
            case 4:
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                yield return new WaitForSeconds(0.3f);
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                yield return new WaitForSeconds(0.4f);
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                break;
            case 5:
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                yield return new WaitForSeconds(0.1f);
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                yield return new WaitForSeconds(0.2f);
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                break;
            case 6:
                Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                yield return new WaitForSeconds(0.1f);
                Instantiate(steamCloud, steamDown.position, transform.rotation);
                yield return new WaitForSeconds(0.3f);
                Instantiate(steamCloud, steamUp.position, transform.rotation);
                break;



        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (timeRunning == true)
        {
            time += Time.deltaTime;
            spawnTimer -= Time.deltaTime;


            if (spawnTimer <= 0)
            {
                rand1 = Random.Range(1, 4);  //spawn a steam cloud in a random position
                rand2 = Random.Range(1, 3);
                switch (rand1)
                {
                    case 1:

                        if (time >= 30 && time < 60)
                        {
                            Instantiate(steamCloud, steamUp.position, transform.rotation);
                            switch (rand2)
                            {
                                case 1:
                                    Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                                    break;

                                case 2:
                                    Instantiate(steamCloud, steamDown.position, transform.rotation);
                                    break;

                            }
                        }
                        else if (time >= 60)
                        {
                            StartCoroutine(TripleSteam());
                        }
                        else
                        {
                            Instantiate(steamCloud, steamUp.position, transform.rotation);
                        }

                        break;



                    case 2:

                        if (time >= 30 && time < 60)
                        {
                            Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                            switch (rand2)
                            {
                                case 1:
                                    Instantiate(steamCloud, steamUp.position, transform.rotation);
                                    break;

                                case 2:
                                    Instantiate(steamCloud, steamDown.position, transform.rotation);
                                    break;

                            }
                        }
                        else if (time >= 60)
                        {
                            StartCoroutine(TripleSteam());
                        }
                        else
                        {
                            Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                        }
                        break;

                    case 3:

                        if (time >= 30 && time < 60)
                        {
                            Instantiate(steamCloud, steamDown.position, transform.rotation);
                            switch (rand2)
                            {
                                case 1:
                                    Instantiate(steamCloud, steamMiddle.position, transform.rotation);
                                    break;

                                case 2:
                                    Instantiate(steamCloud, steamUp.position, transform.rotation);
                                    break;

                            }
                        }
                        else if (time >= 60)
                        {
                            StartCoroutine(TripleSteam());
                        }
                        else
                        {
                            Instantiate(steamCloud, steamDown.position, transform.rotation);
                        }
                        break;
                }
                startingTimer -= 0.1f;    //make spawning more frequent and faster after each cloud has spawned
                speedMod += 0.2f;
                if (startingTimer <= 0.7f)
                {
                    startingTimer = 0.7f;
                }
                spawnTimer = startingTimer;
                if (speedMod >= 12)
                {
                    speedMod = 12;
                }
            }
            timeText.text = "Time : " + (Mathf.Round(time * 100f) / 100f);
        }
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


