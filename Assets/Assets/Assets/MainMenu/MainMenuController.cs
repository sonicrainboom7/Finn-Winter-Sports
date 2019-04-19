using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Text[] namesText;
    public Text howToPlayText;
    public Text howToPlayGameName;
    public Text gameName;
    public GameObject mainScreen, leaderboardMenuScreen, leaderboardScreen, howToPlayMenuScreen, howToPlayScreen;
    public Text nameText;
    public InputField playerName;
    public Button nameButton, leaderBoardsButton, backToMenuButton, backFromScores, howToPlayButton, backFromHowToPlayButton, backFromGuides;
    public Button saunaButton, barNightButton, buffetButton, santaButton, fireworksButton;    //Add more buttons here for more games
    public Button saunaLB, barNightLB, buffetLB, santaLB, fireworksLB;    //Add more buttons here for more games
    public Button saunaHtP, barNightHtP, buffetHtP, santaHtP, fireworksHtP; // Add more buttons here for more games

    void Start()
    {
        playerName.text = PlayerPrefs.GetString("Name");
        nameButton.onClick.AddListener(AddName);

        howToPlayButton.onClick.AddListener(GoToHowToPlay);
        backFromGuides.onClick.AddListener(GoToHowToPlay);
        backFromHowToPlayButton.onClick.AddListener(BackFromHowToPlay);
        leaderBoardsButton.onClick.AddListener(GoToLeaderBoards);
        backToMenuButton.onClick.AddListener(GoToMainMenu);
        backFromScores.onClick.AddListener(GoToLeaderBoards);


        saunaButton.onClick.AddListener(delegate { StartGame(1); });
        barNightButton.onClick.AddListener(delegate { StartGame(2); });
        buffetButton.onClick.AddListener(delegate { StartGame(3); });
        santaButton.onClick.AddListener(delegate { StartGame(4); });
        fireworksButton.onClick.AddListener(delegate { StartGame(5); });

        saunaLB.onClick.AddListener(delegate { GetHighScores(1); });  //defines which scores will be shown on the leaderboard
        barNightLB.onClick.AddListener(delegate { GetHighScores(2); });
        buffetLB.onClick.AddListener(delegate { GetHighScores(3); });
        santaLB.onClick.AddListener(delegate { GetHighScores(4); });
        fireworksLB.onClick.AddListener(delegate { GetHighScores(5); });

        saunaHtP.onClick.AddListener(delegate { GetHowToPlay(1); });  //defines which guide will be shown
        barNightHtP.onClick.AddListener(delegate { GetHowToPlay(2); });
        buffetHtP.onClick.AddListener(delegate { GetHowToPlay(3); });
        santaHtP.onClick.AddListener(delegate { GetHowToPlay(4); });
        fireworksHtP.onClick.AddListener(delegate { GetHowToPlay(5); }); ;
    }

    // Update is called once per frame
    void Update()
    {

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
    // code to deactivate canvases and activate others for going from menu to menu
    void GoToHowToPlay()
    {
        mainScreen.SetActive(false);
        howToPlayScreen.SetActive(false);
        howToPlayMenuScreen.SetActive(true);

    }
    void BackFromHowToPlay()
    {
        mainScreen.SetActive(true);
        howToPlayMenuScreen.SetActive(false);
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
        howToPlayScreen.SetActive(false);
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

    public void GetHowToPlay(int y)
    {
        howToPlayMenuScreen.SetActive(false);
        howToPlayScreen.SetActive(true);

        switch (y)
        {
            case 1:
                howToPlayGameName.text = "How To Play " + "Sauna";
                howToPlayText.text = "Move between planks with W and S to Dodge steamClouds!";
                break;
            case 2:
                howToPlayGameName.text = "How To Play " + "Bar Night";
                howToPlayText.text = "Dodge objects by moving with A and D while you are continually swaying left or right from drinking too much!";
                break;
            case 3:
                howToPlayGameName.text = "How To Play " + "Christmas Buffet";
                howToPlayText.text = "Make sure A, S or D is being pressed while food is coming into the marked spot to eat it!";
                break;
            case 4:
                howToPlayGameName.text = "How To Play " + "Santa's Flight";
                howToPlayText.text = "Drop presents into chimneys with S";
                break;
            case 5:
                howToPlayGameName.text = "How To Play " + "Fireworks";
                howToPlayText.text = "Aim with the mouse and hold Left Click to gather power for a shot and try to hit the target";
                break;
        }
    }
}
