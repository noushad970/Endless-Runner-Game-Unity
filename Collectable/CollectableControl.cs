using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour, IDataPersistence
{
    public static int coinCount;
    public static int TotalcoinCountForMenu;
    public int coins;
    public GameObject coinCountDisplay;
    public GameObject coinEndCountDisplay;
    public PlayerController playerController;

    public void loadData(GameData data)
    {
        this.coins = data.coins;
        TotalcoinCountForMenu = data.coins;
    }
    public void saveData(ref GameData data)
    {
        data.coins += this.coins;
    }
    // Update is called once per frame
    void Update()
    {
       // TotalcoinCountForMenu = coins;
        coins = coinCount;
        if(playerController.gameStart)
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
        coinEndCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}
