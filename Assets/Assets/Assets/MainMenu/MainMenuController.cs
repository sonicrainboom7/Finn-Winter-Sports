using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    public Text[] namesText;
    public Text gameName;
    public GameObject mainScreen, leaderboardMenuScreen, leaderboardScreen;
    public Text nameText;
    public InputField playerName;
    public Button nameButton, leaderBoardsButton, backToMenuButton, backFromScores;
    public Button saunaButton, barNightButton, buffetButton, santaButton, fireworksButton;    //Add more buttons here for more games
    public Button saunaLB, barNightLB, buffetLB, santaLB, fireworksLB;    //Add more buttons here for more games
                                                                                              
    void Start() {
        playerName.text = PlayerPrefs.GetString("Name");
        nameButton.onClick.AddListener(AddName);

        leaderBoardsButton.onClick.AddListener(GoToLeaderBoards);
        backToMenuButton.onClick.AddListener(GoToMainMenu);
        backFromScores.onClick.AddListener(GoToLeaderBoards);

        saunaButton.onClick.AddListener(delegate{StartGame(1);});
        barNightButton.onClick.AddListener(delegate { StartGame(2); });
        buffetButton.onClick.AddListener(delegate { StartGame(3); });
        santaButton.onClick.AddListener(delegate { StartGame(4); });
        fireworksButton.onClick.AddListener(delegate { StartGame(5); });

        saunaLB.onClick.AddListener(delegate { GetHighScores(1); });  //defines which scores will be shown on the leaderboard
        barNightLB.onClick.AddListener(delegate { GetHighScores(2); });
        buffetLB.onClick.AddListener(delegate { GetHighScores(3); });
        santaLB.onClick.AddListener(delegate { GetHighScores(4); });
        fireworksLB.onClick.AddListener(delegate { GetHighScores(5); }); ;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void AddName()
    {
        PlayerPrefs.SetString("Name", playerName.text);
        nameText.text = "Name Saved";
    }
    void StartGame(int index)
    {
      SceneManager.LoadScene(index); //Loads game based on index given in Start()
    }
    void GoToLeaderBoards()
    {
        mainScreen.SetActive(false);
        leaderboardMenuScreen.SetActive(true);
        leaderboardScreen.SetActive(false);
    }
    void GoToMainMenu()
    {
        mainScreen.SetActive(true);
        leaderboardMenuScreen.SetActive(false);
    }

    public void GetHighScores(int x)
    {
        leaderboardMenuScreen.SetActive(false);
        leaderboardScreen.SetActive(true);

        switch (x)
        {
            case 1:
                gameName.text = "Sauna";
                    for (int i = 0; i < 5; i++)
                {
                    namesText[i].text = PlayerPrefs.GetString(i + "SaunaHScoreName") + " : " + PlayerPrefs.GetFloat(i + "SaunaHScore");
                }
                break;
            case 2:
                gameName.text = "Bar Night";
                for (int i = 0; i < 5; i++)
                {
                    namesText[i].text = PlayerPrefs.GetString(i + "BarNightHScoreName") + " : " + PlayerPrefs.GetFloat(i + "BarNightHScore");
                }
                break;
            case 3:
                gameName.text = "Christmas Buffet";
                for (int i = 0; i < 5; i++)
                {
                    namesText[i].text = PlayerPrefs.GetString(i + "BuffetHScoreName") + " : " + PlayerPrefs.GetFloat(i + "BuffetHScore");
                }
                break;
            case 4:
                gameName.text = "Santa's Flight";
                for (int i = 0; i < 5; i++)
                {
                    namesText[i].text = PlayerPrefs.GetString(i + "SantaHScoreName") + " : " + PlayerPrefs.GetFloat(i + "SantaHScore");
                }
                break;
            case 5:
                gameName.text = "Fireworks";
                for (int i = 0; i < 5; i++)
                {
                    namesText[i].text = PlayerPrefs.GetString(i + "FwHScoreName") + " : " + PlayerPrefs.GetFloat(i + "FwHScore");
                }
                break;
        }
        

    }
}
