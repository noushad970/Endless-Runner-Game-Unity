using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//this script will added with coin prefab.

public class CollectCoin : MonoBehaviour
{
   // public Text highScore;
    public GameObject totalcoin;
    public LevelDistance HighScore;
   // public int totalCoin;
    public AudioSource coinFX;
    
  

    public int coins=0;

    

    //when a coin will hit a player it will increase the coin by 1
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
