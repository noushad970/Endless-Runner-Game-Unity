using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour, IDataPersistence
{
    public static CollectableControl instance;
    public static int coinCount;//this value is used by coins to get the total coins
    public static int TotalcoinCountForMenu;//this value should changed when I give reward to any player from mainmenu;
    public int coins;//this value will be added with total coins
    public GameObject coinCountDisplay;
    public GameObject coinEndCountDisplay;
    public PlayerController playerControllerCat;
    public PlayerController playerControllerRaccon;
    public Button getCoinsButton;
    private void Awake()
    {
        instance= this;
    }
    private void Start()
    {
        if (getCoinsButton != null)
        {

            getCoinsButton.onClick.AddListener(rewarded);
        }
    }
    //game data will load here
    public void loadData(GameData data)
    {
        coins = data.coins;
        TotalcoinCountForMenu = data.coins;
        Debug.Log("coins: " + coins + " coinCount: " + coinCount + " TotalcoinCountForMenu: " + TotalcoinCountForMenu + " coinCountDisplay: " + coinCountDisplay + " coinCountEndDisplay: " + coinEndCountDisplay + " ");
        Debug.Log("Data.Coins: " + data.coins);    
    }
    //game data will save here
    public void saveData(ref GameData data)
    {
        data.coins += coins;
        if(RewardedAdExample.isRewarded)
        {
            data.coins += 5000;
        }
    }
    void rewarded()
    {
        RewardedAdExample.instance.ShowAd();
      
        
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
