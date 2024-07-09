using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour, IDataPersistence
{
    public static int coinCount;
    public static int TotalcoinCountForMenu;//this value should changed when I give reward to any player from mainmenu;
    public int coins;
    public GameObject coinCountDisplay;
    public GameObject coinEndCountDisplay;
    public PlayerController playerControllerCat;
    public PlayerController playerControllerRaccon;
    public Button getCoinsButton;
    private void Start()
    {
        getCoinsButton.onClick.AddListener(rewarded);
    }
    //game data will load here
    public void loadData(GameData data)
    {
        this.coins = data.coins;
        TotalcoinCountForMenu = data.coins;
    }
    //game data will save here
    public void saveData(ref GameData data)
    {
        data.coins += this.coins;
    }
    void rewarded()
    {
        RewardedAdExample.instance.ShowAd();
       // coinCount += 100;
        TotalcoinCountForMenu += 100;
    }
    
    // Update is called once per frame
    //this code will shown the coins and high scores on the main menu screen
    void Update()
    {
        // TotalcoinCountForMenu = coins;
        Debug.Log(TotalcoinCountForMenu);
        coins = coinCount;
        if(playerControllerCat.gameStart || playerControllerRaccon.gameStart)
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
        coinEndCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}
