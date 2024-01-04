using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    
    public bool Gameover=false;
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


        }

        
    }
    IEnumerator wait1Sec()
    {
        yield return new WaitForSeconds(3f);
        gameOverScore.SetActive(true);
        ScoreHide.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
    
}
