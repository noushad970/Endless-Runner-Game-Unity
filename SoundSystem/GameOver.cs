using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //game over sound system for the game
    
    public bool Gameover=false;
    public static bool GameoverSave = false;
    public GameObject gameOverScore;
    public GameObject ScoreHide;
    public int PreviousScore;
    //public LevelDistance Distance;
    public int coins=0;
    public Text coinTexts;
   
    private void Update()
    {

        if (Gameover)
        {

            // SavePlayer();
            
            coins += CollectableControl.coinCount;
            // PreviousScore = Distance.disRun;
            coinTexts.text = coins.ToString();

           // LoadData();
            StartCoroutine(wait1Sec());
            GameoverSave = true;
            Gameover = false;



        }

        
    }
    
    IEnumerator wait1Sec()
    {
        yield return new WaitForSeconds(3f);
        gameOverScore.SetActive(true);
        ScoreHide.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
       // CollectableControl.coinCount = 0;
        CollectableControl.coinCount = 0;
        CollectableControl.instance.coins = 0;
            InterstitialAdExample.instance.ShowAd();
    }

}
