using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IceFishingGameController : MonoBehaviour {
    public float score;   // Score for this game. being more drunk means quicker points
    private float realTime;
    public bool timeRunning;
    public GameObject endCanvas;
    public Button leaveGame;
    public Text pointsText;
	public Text timeText;
    public GameObject[] spawners;
    private IceFishingLeaderboard leaderBoard;
    // Use this for initialization
    void Start () {
        
        timeRunning = true;
        leaderBoard = GameObject.Find("GameController").GetComponent<IceFishingLeaderboard>();
        leaveGame.onClick.AddListener(BackToMenu);
        realTime = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timeRunning == true)
        {
            realTime += Time.deltaTime;
            pointsText.text = "Points : " + (Mathf.Round(score * 100f) / 100f);
			timeText.text = "Time : " + Mathf.Round(40f-realTime);
        }
		if (realTime > 40 && timeRunning == true) {
			GameOver();
        }
	}
    public void GameOver()
    {
        timeRunning = false;
        for (int i = spawners.Length - 1; i >= 0; i--)
        {
            Destroy(spawners[i].gameObject);
        }
        timeRunning = false;
        endCanvas.SetActive(true);
        leaderBoard.AddRecord(PlayerPrefs.GetString("Name", "Anonymous"), score);  //Add the players name and Score to the leaderboard
        leaderBoard.GetHighScores();


    }
    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
