using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuffetGameController : MonoBehaviour {
    public GameObject lHand, rHand;
    public bool timeRunning;
    public float time;
    public float speedMod;
    public GameObject endCanvas;
    public Text timer;
    public Text lives;
    public Button leaveGame;
    private BuffetLeaderBoard leaderBoard;
    public GameObject[] spawners;
    public int hp;
	// Use this for initialization
	void Start () {
        timeRunning = true;
        time = 0;
        leaveGame.onClick.AddListener(BackToMenu);
        leaderBoard = GameObject.Find("GameController").GetComponent<BuffetLeaderBoard>();
    }
	
	// Update is called once per frame
	void Update () {
        if (timeRunning == true)
        {
            time += Time.deltaTime;
            speedMod = (time / 45) + 2;
            timer.text = "Time : " + (Mathf.Round(time * 100f) / 100f);
            lives.text = "Lives : " + hp;
            if(hp <= 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        lHand.SetActive(false);
        rHand.SetActive(false);
        for (int i = spawners.Length - 1; i >= 0; i--)
        {
            Destroy(spawners[i].gameObject);
        }
        timeRunning = false;
        endCanvas.SetActive(true);
        leaderBoard.AddRecord(PlayerPrefs.GetString("Name", "Anonymous"), (Mathf.Round(time * 100f) / 100f));  //Add the players name and Score to the leaderboard
        leaderBoard.GetHighScores();

    }
    void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
