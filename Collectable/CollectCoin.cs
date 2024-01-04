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
    // Uncommentable int TotalCoins;

    public int coins=0;

    

    
    private void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        CollectableControl.coinCount++;
        coins++;

        this.gameObject.SetActive(false);
      
        totalcoin.GetComponent<Text>().text = "" + coins;

    }

    // Update is called once per frame

}
