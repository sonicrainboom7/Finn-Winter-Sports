using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceFishingLeaderboard : MonoBehaviour {
    private float yourScore;
    private float newScore;
    private string newName;
    private float oldScore;
    private string oldName;
    private string[] names;
    public Text[] namesText;
    public Text yourScoreText;
    private void Awake()
    {

    }

    public void AddRecord(string name, float score)
    {
        yourScore = score;
        newScore = score;
        newName = name;
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey(i + "IFHScore"))
            {
               
                if (PlayerPrefs.GetFloat(i + "IFHScore") < newScore)
                {
                    
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetFloat(i + "IFHScore");
                    oldName = PlayerPrefs.GetString(i + "IFHScoreName");
                    PlayerPrefs.SetFloat(i + "IFHScore", newScore);
                    PlayerPrefs.SetString(i + "IFHScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                   
                }
            }
            else
            {
                PlayerPrefs.SetFloat(i + "IFHScore", newScore);
                PlayerPrefs.SetString(i + "IFHScoreName", newName);
                newScore = 0;
                newName = "";
            }
        }

    }
    public void GetHighScores()
    {
        yourScoreText.text = "Your score : " + yourScore;
        for (int i = 0; i < 5; i++)
        {
            namesText[i].text = PlayerPrefs.GetString(i + "IFHScoreName") + " : " + PlayerPrefs.GetFloat(i + "IFHScore");
        }
    }
}