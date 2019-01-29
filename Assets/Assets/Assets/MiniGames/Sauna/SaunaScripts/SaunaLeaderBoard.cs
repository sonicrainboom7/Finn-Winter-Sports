using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaunaLeaderBoard : MonoBehaviour {
    private float newScore;
    private string newName;
    private float oldScore;
    private string oldName;
    private string[] names;
    public Text[] namesText;
    private void Awake()
    {
        
    }

    public void AddRecord(string name, float score)
    {
        newScore = score;
        newName = name;
        for (int i = 0; i < 5; i++)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetFloat(i + "HScore") < newScore)
                {
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetFloat(i + "HScore");
                    oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetFloat(i + "HScore", newScore);
                    PlayerPrefs.SetString(i + "HScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetFloat(i + "HScore", newScore);
                PlayerPrefs.SetString(i + "HScoreName", newName);
                newScore = 0;
                newName = "";
            }
        }

    }
    public void GetHighScores()
    {
        for (int i = 0; i < 5; i++)
        {
            namesText[i].text = PlayerPrefs.GetString(i + "HScoreName") + " : " + PlayerPrefs.GetFloat(i + "HScore");
        }
    }
}
