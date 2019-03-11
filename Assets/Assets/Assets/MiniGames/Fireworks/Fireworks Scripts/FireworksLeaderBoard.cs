using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireworksLeaderBoard : MonoBehaviour
{
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
            if (PlayerPrefs.HasKey(i + "FwHScore"))
            {
                if (PlayerPrefs.GetFloat(i + "FwHScore") >= newScore)  // reverse of other leaderboards because fewer shots means better result
                {
                    // new score is lower than the stored score
                    oldScore = PlayerPrefs.GetFloat(i + "FwHScore");
                    oldName = PlayerPrefs.GetString(i + "FwHScoreName");
                    PlayerPrefs.SetFloat(i + "FwHScore", newScore);
                    PlayerPrefs.SetString(i + "FwHScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetFloat(i + "FwHScore", newScore);
                PlayerPrefs.SetString(i + "FwHScoreName", newName);
                newScore = 0;
                newName = "";
            }
        }

    }
    public void GetHighScores()
    {
        for (int i = 0; i < 5; i++)
        {
            namesText[i].text = PlayerPrefs.GetString(i + "FwHScoreName") + " : " + PlayerPrefs.GetFloat(i + "FwHScore");
        }
    }
}