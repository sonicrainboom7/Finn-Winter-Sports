using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SantaGameController : MonoBehaviour {
    private float score;
    public GameObject gameEnd;
    private SantaLeaderBoard leaderBoard;
    public Button leaveGame;
	// Use this for initialization
	void Start () {
        leaderBoard = GameObject.Find("GameController").GetComponent<SantaLeaderBoard>();
        leaveGame.onClick.AddListener(BackToMenu);
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GameOver()
    {
        gameEnd.SetActive(true);
        leaderBoard.AddRecord(PlayerPrefs.GetString("Name", "Anonymous"), score);  //Add the players name and Score to the leaderboard
        leaderBoard.GetHighScores();
        Time.timeScale = 0;
    }
    public void ScoreIncrease()
    {
        score += 1;
    }
    void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
