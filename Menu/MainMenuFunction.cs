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
    public GameObject shop,  quit, startButtonDay, selectMap, selectChar,backFromShop,BackFromSelectChar,CatButton,RacconButton,racoon,cat,dayMapButton,NightMapButton,DesertMapButton,aboutButton;
    public bool isSelectedCat, isSelectedRacoon,isSelectedNightMap,isSelectedDayMap, isSelectedDesertMap;
    public static bool saveCharacterData=false,saveMap=false;
    public static int characterSelection,mapSelection;
    public static int LoadInt=0;
    public GameObject HowToPlayScreen;

    //load data will load the previous data
    public void loadData(GameData data)
    {
        // this.coins = data.coins;
        characterSelection = data.SelectedCharacter;

        mapSelection = data.selectedMap;


    }
    //save data will save all the saved data while open or exit the app

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
        if (isSelectedDesertMap)
        {
            data.selectedMap = 3;
        }


    }
    // Update is called once per frame
    private void Update()
    {
        ///those code will execute the player and map according to player choice
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
        BackAllCharShow();
        dayMapButton.SetActive(false);
        NightMapButton.SetActive(false);
        DesertMapButton.SetActive(false);
        saveMap =true;
        

    }
    //this code will select the night map
    public void ClickOnNightMap()
    {
        isSelectedDayMap = false;
        isSelectedNightMap = true;
        isSelectedDesertMap = false;
        BackAllCharShow();

        dayMapButton.SetActive(false);
        NightMapButton.SetActive(false);

        DesertMapButton.SetActive(false);
        saveMap =true;


    }
    //this code will select the night map
    public void ClickOnDesertMap()
    {
        isSelectedDayMap = false;
        isSelectedNightMap = false;
        isSelectedDesertMap = true;
        BackAllCharShow();

        dayMapButton.SetActive(false);
        NightMapButton.SetActive(false);
        DesertMapButton.SetActive(false);
        saveMap = true;


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
