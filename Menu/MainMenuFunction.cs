using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//this script will add with an empty gameobject named MainMenu
public class MainMenuFunction : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update

    public GameOver isOver;
    public GameObject highScore;
    public GameObject shop,  quit, startButtonDay, selectMap, selectChar,backFromShop,BackFromSelectChar,CatButton,RacconButton,racoon,cat,dayMapButton,NightMapButton,DesertMapButton,subwayMapButton,aboutButton;
    public bool isSelectedCat, isSelectedRacoon,isSelectedNightMap,isSelectedDayMap, isSelectedDesertMap,isSelectedSubwayMap;
    public static bool saveCharacterData=false,saveMap=false;
    public static int characterSelection,mapSelection;
    public static int LoadInt=0;
    public static bool saveAfterBuyData=false;
    public GameObject HowToPlayScreen;
    bool isBuyedDesertMap;
    bool isBuyedSubwayMaps;
    int totalcoin;
    public GameObject isLockedDesertMap,isLockedSubwayMap;
    public GameObject confirmDesertMapBuyPanel, confirmSubwayMapBuyPanel, panel,notEnoughCoinPanel;
    public Button okButton, yesButtonDesert, yesButtonSubway, NoButtonSubway,NoButtonDesert;
    //load data will load the previous data
    public void loadData(GameData data)
    {
        // this.coins = data.coins;
        characterSelection = data.SelectedCharacter;

        mapSelection = data.selectedMap;
        isBuyedDesertMap = data.isEnableDesertMap;
        isBuyedSubwayMaps = data.isEnableSubWayMap;
        totalcoin = data.coins;
        isBuyedDesertMap=data.isEnableDesertMap;


    }
    //save data will save all the saved data while open or exit the app
    int mapval = 0;
    public void saveData(ref GameData data)
    {
        if(isSelectedCat) {
            data.SelectedCharacter = 1;
        }
        if(isSelectedRacoon)
        {
            data.SelectedCharacter = 2;
        }
        if(isSelectedNightMap)
        {
            data.selectedMap = 2;
        }
        if(isSelectedDayMap)
        {
            data.selectedMap = 1;
        }
        if (isSelectedDesertMap && isBuyedDesertMap)
        {
            data.selectedMap = 3;

            data.isEnableDesertMap = true;
            data.coins = totalcoin;
        }
        if(isSelectedSubwayMap && isBuyedSubwayMaps)
        {
            data.selectedMap = 4;
            data.isEnableSubWayMap= true;
            data.coins = totalcoin;
        }
        mapval = data.selectedMap;


    }
    // Update is called once per frame
    private void Update()
    {
        Debug.Log("Selected Map Value: " + mapval);
        ///those code will execute the player and map according to player choice
        if (isBuyedSubwayMaps && isLockedSubwayMap != null)
        {
            Destroy(isLockedSubwayMap);
        }
        if (isBuyedDesertMap && isLockedDesertMap != null)
        {
            Destroy(isLockedDesertMap);
        }
        if (isSelectedCat)
        {
            characterSelection = 1;
        }
        if (isSelectedRacoon)
        {
            characterSelection = 2;
        }
        if (isSelectedNightMap)
        {
            mapSelection = 2;
        }
        if (isSelectedDayMap)
        {
            mapSelection = 1;
        }
        if (isSelectedDesertMap)
        {
            mapSelection = 3;
        }
        if (isSelectedSubwayMap)
        {
            mapSelection = 4;
        }
        if (characterSelection == 1)
        {
            cat.SetActive(true);
            racoon.SetActive(false);
            
        }
        if (characterSelection == 2)
        {
            cat.SetActive(false);
            racoon.SetActive(true);
        }
        



    }
    private void Start()
    {
        //this code will execute while the game will start. as a menu
        okButton.onClick.AddListener(OnclickOkButton);
        NoButtonSubway.onClick.AddListener(OnclickOkButton);
        NoButtonDesert.onClick.AddListener(OnclickOkButton);
        yesButtonDesert.onClick.AddListener(OnclickYesDesertButton);
        yesButtonSubway.onClick.AddListener(OnclickYesSubwayButton);
        cat.SetActive(true);
        HowToPlayScreen.SetActive(false);
        if (characterSelection == 1)
        {
            cat.SetActive(true);
            racoon.SetActive(false);
            
        }
        if (characterSelection == 2)
        {
            cat.SetActive(false);
            racoon.SetActive(true);
        }
       
        //
        shop.SetActive(true);
        aboutButton.SetActive(true);
        // option.SetActive(true);
        quit.SetActive(true);
        if(mapSelection==1)
        {
            startButtonDay.SetActive(true);
          //  startButtonNight.SetActive(false);
        }
        if(mapSelection==2)
        {
            startButtonDay.SetActive(true);
          //  startButtonNight.SetActive(true);
        }
        if (mapSelection == 3)
        {
            startButtonDay.SetActive(true);
            //  startButtonNight.SetActive(true);
        }
        if (mapSelection == 4)
        {
            startButtonDay.SetActive(true);
            //  startButtonNight.SetActive(true);
        }
        //about.SetActive(true);
        selectChar.SetActive(false);
        backFromShop.SetActive(false);
        selectMap.SetActive(false);
        cat.SetActive(false);
        racoon.SetActive(false);
        BackFromSelectChar.SetActive(false);
        selectChar.SetActive(false);

    }
    //this method will start the game
    public void PlayGame()
    {
        CollectableControl.coinCount = 0;
        LevelDistance.disRun = 0;
        isOver.Gameover = false;
        SceneManager.LoadScene(1);
    }
   //this method will open the shop system
    public void Shop()
    {


        shop.SetActive(false);
        //option.SetActive(false);
        quit.SetActive(false);
        aboutButton.SetActive(false);
        // startButtonDay.SetActive(false);
        if (mapSelection == 1)
        {
            startButtonDay.SetActive(false);
        }
        if (mapSelection == 2)
        {
            startButtonDay.SetActive(false);
        }
        if (mapSelection == 3)
        {
            startButtonDay.SetActive(false);
        }
        if (mapSelection == 4)
        {
            startButtonDay.SetActive(false);
        }
        selectChar.SetActive(true);
        selectMap.SetActive(true);
        backFromShop.SetActive(true);
        BackFromSelectChar.SetActive(false);
        HowToPlayScreen.SetActive(false);

    }
    //all the character will shown with this method
    public void AllCharShow()
    {
        shop.SetActive(false);
        quit.SetActive(false);
        aboutButton.SetActive(false);
        if (mapSelection == 1)
        {
            startButtonDay.SetActive(false);
        }
        if (mapSelection == 2)
        {
            startButtonDay.SetActive(false);
        }
        if (mapSelection == 3)
        {
            startButtonDay.SetActive(false);
        }
        if (mapSelection == 4)
        {
            startButtonDay.SetActive(false);
        }
        // about.SetActive(false);
        selectChar.SetActive(false);
        selectMap.SetActive(false);
        backFromShop.SetActive(false);
        CatButton.SetActive(true) ;
        RacconButton.SetActive(true) ;
        BackFromSelectChar.SetActive(true);
        HowToPlayScreen.SetActive(false);

    }
    //select the cat character for game run
    public void ClickOnCat()
    {
        isSelectedCat=true;
        isSelectedRacoon = false;
        BackAllCharShow();
        cat.SetActive(isSelectedCat);
        racoon.SetActive(false);
        saveCharacterData = true;


       
    }
    //select the Racoon character for game run
    public void ClickOnRacoon()
    {
        isSelectedRacoon = true;
        isSelectedCat = false;
        BackAllCharShow();
        racoon.SetActive(isSelectedRacoon);
       
        cat.SetActive(false);
        saveCharacterData = true;
       
    }
    //this code will open all the map or theme available
    public void ClickOnDayMap()
    {
        isSelectedDayMap = true;
        isSelectedNightMap = false;
        isSelectedDesertMap = false;
        isSelectedSubwayMap = false;
        BackAllCharShow();
        dayMapButton.SetActive(false);
        NightMapButton.SetActive(false);
        DesertMapButton.SetActive(false);
        subwayMapButton.SetActive(false);
        saveMap =true;
        

    }
    //this code will select the night map
    public void ClickOnNightMap()
    {
        isSelectedDayMap = false;
        isSelectedNightMap = true;
        isSelectedDesertMap = false;
        isSelectedSubwayMap = false;
        BackAllCharShow();

        dayMapButton.SetActive(false);
        NightMapButton.SetActive(false);

        DesertMapButton.SetActive(false);
        subwayMapButton.SetActive(false);
        saveMap =true;


    }
    //this code will select the night map
    public void ClickOnDesertMap()
    {
        if(isBuyedDesertMap)
        {
            isSelectedDayMap = false;
            isSelectedNightMap = false;
            isSelectedDesertMap = true;
            isSelectedSubwayMap = false;
            BackAllCharShow();

            dayMapButton.SetActive(false);
            NightMapButton.SetActive(false);
            DesertMapButton.SetActive(false);
            subwayMapButton.SetActive(false);
            saveMap = true;
        }
        else
        {
            panel.SetActive(true);
            if(totalcoin>=5000)
            {

                
                confirmDesertMapBuyPanel.SetActive(true);
                confirmSubwayMapBuyPanel.SetActive(false);
                
            }
            else
            {
                Debug.Log("Dont have Enough Coins");
                notEnoughCoinPanel.SetActive(true);

                confirmDesertMapBuyPanel.SetActive(false);
                confirmSubwayMapBuyPanel.SetActive(false);

            }
        }


    }
    void OnclickYesDesertButton()
    {
        totalcoin -= 5000;
        isBuyedDesertMap = true;
        isSelectedDayMap = false;
        isSelectedNightMap = false;
        isSelectedDesertMap = true;
        isSelectedSubwayMap = false;
       

        //dayMapButton.SetActive(false);
        //NightMapButton.SetActive(false);
        //DesertMapButton.SetActive(false);
        //subwayMapButton.SetActive(false);
        saveMap = true;
        //all confirm and ok panel should be disable
        notEnoughCoinPanel.SetActive(false);
        panel.SetActive(false);
        confirmDesertMapBuyPanel.SetActive(false);
        confirmSubwayMapBuyPanel.SetActive(false);
        if (isLockedDesertMap != null)
        {
            Destroy(isLockedDesertMap);
        }
    }
    //
    public void ClickOnSubwayMap()
    {
        Debug.Log("IsBuyedSubwayMap: " + isBuyedSubwayMaps);
        if (isBuyedSubwayMaps)
        {

            isSelectedDayMap = false;
            isSelectedNightMap = false;
            isSelectedDesertMap = false;
            isSelectedSubwayMap = true;
            BackAllCharShow();

            dayMapButton.SetActive(false);
            NightMapButton.SetActive(false);
            DesertMapButton.SetActive(false);
            subwayMapButton.SetActive(false);
            saveMap = true;
        }
        else
        {
            panel.SetActive(true);
            if (totalcoin >= 10000)
            {


                confirmDesertMapBuyPanel.SetActive(false);
                confirmSubwayMapBuyPanel.SetActive(true);

            }
            else
            {
                Debug.Log("Dont have Enough Coins");
                notEnoughCoinPanel.SetActive(true);

                confirmDesertMapBuyPanel.SetActive(false);
                confirmSubwayMapBuyPanel.SetActive(false);

            }
        }


    }
    void OnclickYesSubwayButton()
    {
        totalcoin -= 10000;
        isBuyedSubwayMaps = true;
        isSelectedDayMap = false;
        isSelectedNightMap = false;
        isSelectedDesertMap = false;
        isSelectedSubwayMap = true;


        //dayMapButton.SetActive(false);
        //NightMapButton.SetActive(false);
        //DesertMapButton.SetActive(false);
        //subwayMapButton.SetActive(false);
        saveMap = true;
        //all confirm and ok panel should be disable
        notEnoughCoinPanel.SetActive(false);
        panel.SetActive(false);
        confirmDesertMapBuyPanel.SetActive(false);
        confirmSubwayMapBuyPanel.SetActive(false);
        if (isLockedSubwayMap != null)
        {
            Destroy(isLockedSubwayMap);
        }
    }
    //
    /*
    public void ClickOnSubwayMap()
    {
        if(isBuyedSubwayMap)
        {


           // saveAfterBuyData = true;
            isSelectedDayMap = false;
            isSelectedNightMap = false;
            isSelectedDesertMap = false;
            isSelectedSubwayMap = true;
            BackAllCharShow();

            dayMapButton.SetActive(false);
            NightMapButton.SetActive(false);
            DesertMapButton.SetActive(false);
            subwayMapButton.SetActive(false);
            saveMap = true;
        }
        else
        {
            panel.SetActive(true);
            if (totalcoin >= 10000)
            {
                confirmDesertMapBuyPanel.SetActive(false);
                confirmSubwayMapBuyPanel.SetActive(true);
                
                
            }
            else
            {
               
                notEnoughCoinPanel.SetActive(true);
                confirmDesertMapBuyPanel.SetActive(false);
                confirmSubwayMapBuyPanel.SetActive(false);
                Debug.Log("Dont have Enough Coins");
            }
        }

        
        
    }
    void onClickYesSubwayButton()
    {
        totalcoin -= 10000;
        //saveAfterBuyData =true;
        
        isBuyedSubwayMap = true;
        isSelectedDayMap = false;
        isSelectedNightMap = false;
        isSelectedDesertMap = false;
        isSelectedSubwayMap = true;
        //BackAllCharShow();

        //dayMapButton.SetActive(false);
        //NightMapButton.SetActive(false);
        //DesertMapButton.SetActive(false);
        //subwayMapButton.SetActive(false);
        saveMap = true;

        //all confirm and ok panel should be disable
        notEnoughCoinPanel.SetActive(false);
        panel.SetActive(false);
        confirmDesertMapBuyPanel.SetActive(false);
        confirmSubwayMapBuyPanel.SetActive(false);
        if (isLockedSubwayMap != null)
        {
            Destroy(isLockedSubwayMap);
        }
    }
    */
    void OnclickOkButton()
    {
        panel.SetActive(false);
        confirmDesertMapBuyPanel.SetActive(false);
        confirmSubwayMapBuyPanel.SetActive(false);
        notEnoughCoinPanel.SetActive(false);
    }

    //this method will go back from  all characters screen
    public void BackAllCharShow()
    {
        shop.SetActive(false);
      //  option.SetActive(false);
        quit.SetActive(false);
      //  startButtonDay.SetActive(false);
        if (mapSelection == 1)
        {
            startButtonDay.SetActive(false);
           // startButtonNight.SetActive(false);
        }
        if (mapSelection == 2)
        {
            startButtonDay.SetActive(false);
           // startButtonNight.SetActive(false);
        }
        if (mapSelection == 3)
        {
            startButtonDay.SetActive(false);
            // startButtonNight.SetActive(false);
        }
        if (mapSelection == 4)
        {
            startButtonDay.SetActive(false);
            // startButtonNight.SetActive(false);
        }
        //  about.SetActive(false);
        selectChar.SetActive(true);
        selectMap.SetActive(true);
        backFromShop.SetActive(true);
        CatButton.SetActive(false);
        RacconButton.SetActive(false);
        BackFromSelectChar.SetActive(false);
        HowToPlayScreen.SetActive(false);
        aboutButton.SetActive(false);

    }
    public void ClickOnAboutMenuScreen()
    {
        HowToPlayScreen.SetActive(true);
        backFromShop.SetActive(true);
        aboutButton.SetActive(false);

    }
    //this method will go back from  all map screen
    public void BackAllMapShow()
    {
        shop.SetActive(false);
        //  option.SetActive(false);
        quit.SetActive(false);
        //  startButtonDay.SetActive(false);
        if (mapSelection == 1)
        {
            startButtonDay.SetActive(false);
           // startButtonNight.SetActive(false);
        }
        if (mapSelection == 2)
        {
            startButtonDay.SetActive(false);
           // startButtonNight.SetActive(false);
        }
        if (mapSelection == 3)
        {
            startButtonDay.SetActive(false);
            // startButtonNight.SetActive(false);
        }
        if (mapSelection == 4)
        {
            startButtonDay.SetActive(false);
            // startButtonNight.SetActive(false);
        }
        //  about.SetActive(false);
        selectChar.SetActive(true);
        selectMap.SetActive(true);
        backFromShop.SetActive(true);
        CatButton.SetActive(false);
        RacconButton.SetActive(false);
        BackFromSelectChar.SetActive(false);
        dayMapButton.SetActive(false);
        NightMapButton.SetActive(false);
        DesertMapButton.SetActive (false);
        subwayMapButton.SetActive(false);
        HowToPlayScreen.SetActive(false);
        aboutButton.SetActive(false);

    }
    // all available map will be shown
    public void AllMapShow()
    {
        shop.SetActive(false);
        //  option.SetActive(false);
        quit.SetActive(false);
        startButtonDay.SetActive(false);
       // startButtonNight.SetActive(false);
        // about.SetActive(false);
        selectChar.SetActive(false);
        selectMap.SetActive(false);
        backFromShop.SetActive(false);
        dayMapButton.SetActive(true);
        NightMapButton.SetActive(true);
        subwayMapButton.SetActive(true);
        DesertMapButton.SetActive(true);
        BackFromSelectChar.SetActive(true);
        HowToPlayScreen.SetActive(false);
        aboutButton.SetActive(false);

    }
    //back from shop
    public void ShopBack()
    {


        shop.SetActive(true);
        // option.SetActive(true);
        quit.SetActive(true);
        // startButtonDay.SetActive(true);
        if (mapSelection == 1)
        {
            startButtonDay.SetActive(true);
            // startButtonNight.SetActive(false);
        }
        if (mapSelection == 2)
        {
            startButtonDay.SetActive(true);
            //startButtonNight.SetActive(true);
        }
        if (mapSelection == 3)
        {
            startButtonDay.SetActive(true);
            //startButtonNight.SetActive(true);
        }
        if (mapSelection == 4)
        {
            startButtonDay.SetActive(true);
        }
        //  about.SetActive(true);
        selectChar.SetActive(false);
        backFromShop.SetActive(false);
        selectMap.SetActive(false);
        HowToPlayScreen.SetActive(false);
        aboutButton.SetActive(true);


    }
    //will quite the application
    public void Quit()
    {
       // isOver.SavePlayer();
        Application.Quit();
    }

    //Game Data system
    public void onClickNewGame()
    {
        DataPersistanceManager.instance.newGame();
    }

    public void onClickSaveGame()
    {
        DataPersistanceManager.instance.saveGame();
    }

    public void onClickLoadGame()
    {
        DataPersistanceManager.instance.loadGame();
    }
}
