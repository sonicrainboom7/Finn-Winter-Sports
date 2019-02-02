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
            if (PlayerPrefs.HasKey(i + "SaunaHScore"))
            {
                if (PlayerPrefs.GetFloat(i + "SaunaHScore") < newScore)
                {
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetFloat(i + "SaunaHScore");
                    oldName = PlayerPrefs.GetString(i + "SaunaHScoreName");
                    PlayerPrefs.SetFloat(i + "SaunaHScore", newScore);
                    PlayerPrefs.SetString(i + "SaunaHScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetFloat(i + "SaunaHScore", newScore);
                PlayerPrefs.SetString(i + "SaunaHScoreName", newName);
                newScore = 0;
                newName = "";
            }
        }

    }
    public void GetHighScores()
    {
        for (int i = 0; i < 5; i++)
        {
            namesText[i].text = PlayerPrefs.GetString(i + "SaunaHScoreName") + " : " + PlayerPrefs.GetFloat(i + "SaunaHScore");
        }
    }
}
