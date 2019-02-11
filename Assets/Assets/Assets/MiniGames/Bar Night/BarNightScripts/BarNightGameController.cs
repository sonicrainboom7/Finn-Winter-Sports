using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarNightGameController : MonoBehaviour {
    private float scoreTime;   // Score for this game. being more drunk means quicker points
    private float realTime;
    public float speedMod;
    public bool timeRunning;
    public GameObject endCanvas;
    public Button leaveGame;
    public Text pointsText;
    public Text lives;
    public GameObject[] spawners;
    private BarNightPlayerMovement playerScript;
    private BarNightLeaderBoard leaderBoard;
    // Use this for initialization
    void Start () {
        timeRunning = true;
        playerScript = GameObject.Find("Player").GetComponent<BarNightPlayerMovement>();
        leaderBoard = GameObject.Find("GameController").GetComponent<BarNightLeaderBoard>();
        leaveGame.onClick.AddListener(BackToMenu);
        realTime = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timeRunning == true)
        {
            realTime += Time.deltaTime;
            speedMod = (realTime / 60) + 1;
            scoreTime += Time.deltaTime * playerScript.drunkenessLevel;
            pointsText.text = "Points : " + (Mathf.Round(scoreTime * 100f) / 100f);
        }
		
	}
    public void GameOver()
    {
        for (int i = spawners.Length - 1; i >= 0; i--)
        {
            Destroy(spawners[i].gameObject);
        }
        timeRunning = false;
        endCanvas.SetActive(true);
        leaderBoard.AddRecord(PlayerPrefs.GetString("Name", "Anonymous"), (Mathf.Round(scoreTime * 100f) / 100f));  //Add the players name and Score to the leaderboard
        leaderBoard.GetHighScores();


    }
    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
