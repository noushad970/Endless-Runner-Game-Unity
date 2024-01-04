using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{
   // public Text highScore;
    public GameObject totalcoin;
    public LevelDistance HighScore;
   // public int totalCoin;
    public AudioSource coinFX;
    int TotalCoins;

    public static int coins=0;
    
    //private void Start()
    //{
    //    if (PlayerPrefs.HasKey("Coinsum"))
    //    {
    //        coins = PlayerPrefs.GetInt("Coinsum");
    //    }
    //    else
    //    {
    //        PlayerPrefs.SetInt("Coinsum", coins);
    //        PlayerPrefs.Save();
    //    }
    //    totalcoin.GetComponent<Text>().text =""+ coins;
    //}
    //private void Update()
    //{
    //    totalcoin.GetComponent<Text>().text = "" + coins;
    //}
    private void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        CollectableControl.coinCount++;
        coins++;

        this.gameObject.SetActive(false);
        PlayerPrefs.SetInt("Coinsum", coins);
        PlayerPrefs.Save();
        // TotalCoins += coins;
       // totalcoin.GetComponent<Text>().text = "" + coins;

    }

    // Update is called once per frame
    
}
