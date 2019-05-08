using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceFishingLeaderboard : MonoBehaviour {
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
            if (PlayerPrefs.HasKey(i + "IFHScore"))
            {
               
                if (PlayerPrefs.GetFloat(i + "IFHScore") < newScore)
                {
                    Debug.Log((PlayerPrefs.GetFloat(i + "IFHScore")));
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetFloat(i + "IFHScore");
                    oldName = PlayerPrefs.GetString(i + "IFHScoreName");
                    PlayerPrefs.SetFloat(i + "IFHScore", newScore);
                    PlayerPrefs.SetString(i + "IFHScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                    Debug.Log(newScore);
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
        for (int i = 0; i < 5; i++)
        {
            namesText[i].text = PlayerPrefs.GetString(i + "IFHScoreName") + " : " + PlayerPrefs.GetFloat(i + "IFHScore");
        }
    }
}