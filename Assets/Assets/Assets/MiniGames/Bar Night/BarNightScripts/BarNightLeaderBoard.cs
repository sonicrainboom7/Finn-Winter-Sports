﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarNightLeaderBoard : MonoBehaviour
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
            if (PlayerPrefs.HasKey(i + "BarNightHScore"))
            {
                if (PlayerPrefs.GetFloat(i + "BarNightHScore") < newScore)
                {
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetFloat(i + "BarNightHScore");
                    oldName = PlayerPrefs.GetString(i + "BarNightHScoreName");
                    PlayerPrefs.SetFloat(i + "BarNightHScore", newScore);
                    PlayerPrefs.SetString(i + "BarNightHScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetFloat(i + "BarNightHScore", newScore);
                PlayerPrefs.SetString(i + "BarNightHScoreName", newName);
                newScore = 0;
                newName = "";
            }
        }

    }
    public void GetHighScores()
    {
        for (int i = 0; i < 5; i++)
        {
            namesText[i].text = PlayerPrefs.GetString(i + "BarNightHScoreName") + " : " + PlayerPrefs.GetFloat(i + "BarNightHScore");
        }
    }
}