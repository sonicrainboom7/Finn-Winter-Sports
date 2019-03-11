using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FireworksGameController : MonoBehaviour {
    public Button leaveGame;
    private FireworksLeaderBoard leaderBoard;
    private ShootingControls scoreScript;
    public GameObject endCanvas;
	// Use this for initialization
	void Start () {
        leaveGame.onClick.AddListener(BackToMenu);
        leaderBoard = GameObject.Find("GameController").GetComponent<FireworksLeaderBoard>();
        scoreScript = GameObject.Find("Player").GetComponent<ShootingControls>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void EndGame()
    {
        Time.timeScale = 0;
        endCanvas.SetActive(true);
        leaderBoard.AddRecord(PlayerPrefs.GetString("Name", "Anonymous"), (scoreScript.shotCount));  //Add the players name and Score to the leaderboard
        leaderBoard.GetHighScores();
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
