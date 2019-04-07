using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausehandler : MonoBehaviour {
    public Button unPause;
    public Button leave;
    public GameObject player;
    public GameObject pauseCanvas;
	// Use this for initialization
	void Start () {
        
        unPause.onClick.AddListener(UnPause);
        leave.onClick.AddListener(LeaveGame);
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("escape") && Time.timeScale == 1)
        {
            Pause();
        }
		
	}
    void Pause()
    {
        if (player != null)
        {
            player.SetActive(false);  // if the player has controls that work during pause, this makes sure they wont work
        }
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
    }
    void UnPause()
    {
        if (player.activeInHierarchy == false)
        {
           
            player.SetActive(true);
        }
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
    }
    void LeaveGame()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(0);
    }
}
