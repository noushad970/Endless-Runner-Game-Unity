using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoinAndHighScore : MonoBehaviour
{
    public Text totalcoin;
    public Text highScore;
    

    

    private void Start()
    {
        

        totalcoin.GetComponent<Text>().text = "" + CollectableControl.TotalcoinCountForMenu;

        //highScore
        if (PlayerPrefs.HasKey("HighScores"))
        {
            LevelDistance.highScore = PlayerPrefs.GetInt("HighScores");
        }
        else
        {
            PlayerPrefs.SetInt("HighScores", LevelDistance.highScore);
            PlayerPrefs.Save();
        }
        highScore.GetComponent<Text>().text = LevelDistance.highScore.ToString();
    }
    private void Update()
    {

        if (LevelDistance.disRun > PlayerPrefs.GetInt("HighScores"))
        {

            LevelDistance.highScore = LevelDistance.disRun;
        }
        PlayerPrefs.SetInt("HighScores", LevelDistance.highScore);
        PlayerPrefs.Save();
        highScore.GetComponent<Text>().text = LevelDistance.highScore.ToString();
    }
}

