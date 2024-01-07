using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunction : MonoBehaviour, IDataPersistence
{
    // Start is called before the first frame update

    public GameOver isOver;
    public GameObject highScore;
    public GameObject shop, about, option, quit, startButton, selectMap, selectChar,backFromShop,BackFromSelectChar,AJButton,JoshButton,MariaButton,LunaButton,AJ1,Josh,Luna,Maria;
    public bool isSelectedAj, isSelectedJosh, isSelectedLuna, isSelectedMaria;
    public static bool saveCharacterData=false;
    public static int characterSelection;
    public static int LoadInt=0;

    public void loadData(GameData data)
    {
        // this.coins = data.coins;
        characterSelection = data.SelectedCharacter;



    }
    public void saveData(ref GameData data)
    {
        if(isSelectedAj) {
            data.SelectedCharacter = 1;
        }
        if(isSelectedJosh)
        {
            data.SelectedCharacter = 2;
        }
        if(isSelectedLuna)
        {
            data.SelectedCharacter = 4;
        }
        if(isSelectedMaria)
        {
            data.SelectedCharacter = 3;
        }
        
    }
    // Update is called once per frame
    private void Update()
    {
        Debug.Log(characterSelection);
        if (characterSelection == 1)
        {
            AJ1.SetActive(true);
            Josh.SetActive(false);
            Maria.SetActive(false);
            Luna.SetActive(false);
        }
        if (characterSelection == 2)
        {
            AJ1.SetActive(false);
            Josh.SetActive(true);
            Maria.SetActive(false);
            Luna.SetActive(false);
        }
        if (characterSelection == 4)
        {
            AJ1.SetActive(false);
            Josh.SetActive(false);
            Maria.SetActive(false);
            Luna.SetActive(true);
        }
        if (characterSelection == 3)
        {
            AJ1.SetActive(false);
            Josh.SetActive(false);
            Maria.SetActive(true);
            Luna.SetActive(false);
        }

    }
    private void Start()
    {

        /* */
        if (characterSelection == 1)
        {
            AJ1.SetActive(true);
            Josh.SetActive(false);
            Maria.SetActive(false);
            Luna.SetActive(false);
        }
        if (characterSelection == 2)
        {
            AJ1.SetActive(false);
            Josh.SetActive(true);
            Maria.SetActive(false);
            Luna.SetActive(false);
        }
        if (characterSelection == 4)
        {
            AJ1.SetActive(false);
            Josh.SetActive(false);
            Maria.SetActive(false);
            Luna.SetActive(true);
        }
        if (characterSelection == 3)
        {
            AJ1.SetActive(false);
            Josh.SetActive(false);
            Maria.SetActive(true);
            Luna.SetActive(false);
        }
        //
        shop.SetActive(true);
        option.SetActive(true);
        quit.SetActive(true);
        startButton.SetActive(true);
        about.SetActive(true);
        selectChar.SetActive(false);
        backFromShop.SetActive(false);
        selectMap.SetActive(false);
        AJButton.SetActive(false);
        JoshButton.SetActive(false);
        MariaButton.SetActive(false);
        LunaButton.SetActive(false);
        BackFromSelectChar.SetActive(false);
        selectChar.SetActive(false);
    }
    public void PlayGame()
    {
        CollectableControl.coinCount = 0;
        LevelDistance.disRun = 0;
        isOver.Gameover = false;
        SceneManager.LoadScene(1);
    }
    public void Option()
    {
       //option screen
    }
    public void Shop()
    {


        shop.SetActive(false);
        option.SetActive(false);
        quit.SetActive(false);
        startButton.SetActive(false);
        about.SetActive(false);
        selectChar.SetActive(true);
        selectMap.SetActive(true);
        backFromShop.SetActive(true);
        BackFromSelectChar.SetActive(false);
        

    }
    public void AllCharShow()
    {
        shop.SetActive(false);
        option.SetActive(false);
        quit.SetActive(false);
        startButton.SetActive(false);
        about.SetActive(false);
        selectChar.SetActive(false);
        selectMap.SetActive(false);
        backFromShop.SetActive(false);
        AJButton.SetActive(true) ;
        JoshButton.SetActive(true) ;
        MariaButton.SetActive(true);
        LunaButton.SetActive(true);
        BackFromSelectChar.SetActive(true);
        
    }
    public void ClickOnAj()
    {
        isSelectedAj=true;
        isSelectedJosh = false;
        isSelectedLuna = false;
        isSelectedMaria = false;
        BackAllCharShow();
        AJ1.SetActive(isSelectedAj);
        Josh.SetActive(false) ;
        Luna.SetActive(false) ;
        Maria.SetActive(false) ;
        saveCharacterData = true;
       
    }
    public void ClickOnJosh()
    {
        isSelectedAj = false;
        isSelectedJosh = true;
        isSelectedLuna = false;
        isSelectedMaria = false;
        BackAllCharShow();
        Josh.SetActive(isSelectedJosh);
        Luna.SetActive(false);
        Maria.SetActive(false);
        AJ1.SetActive(false);
        saveCharacterData = true;
       
    }
    public void ClickOnMaria()
    {
        isSelectedAj = false;
        isSelectedJosh = false;
        isSelectedLuna = false;
        isSelectedMaria = true;
        BackAllCharShow();
        Maria.SetActive(isSelectedMaria);
        AJ1.SetActive(false);
        Josh.SetActive(false);
        Luna.SetActive(false);
        saveCharacterData = true;

    }
    public void ClickOnLuna()
    {
        isSelectedAj = false;
        isSelectedJosh = false;
        isSelectedLuna = true;
        isSelectedMaria = false;
        BackAllCharShow();
        Luna.SetActive(isSelectedLuna);
        Maria.SetActive(false);
        AJ1.SetActive(false);
        Josh.SetActive(false );
        saveCharacterData = true;
     

    }
    public void BackAllCharShow()
    {
        shop.SetActive(false);
        option.SetActive(false);
        quit.SetActive(false);
        startButton.SetActive(false);
        about.SetActive(false);
        selectChar.SetActive(true);
        selectMap.SetActive(true);
        backFromShop.SetActive(true);
        AJButton.SetActive(false);
        JoshButton.SetActive(false);
        MariaButton.SetActive(false);
        LunaButton.SetActive(false);
        BackFromSelectChar.SetActive(false);
        
    }
    public void AllMapShow()
    {

    }
    public void ShopBack()
    {


        shop.SetActive(true);
        option.SetActive(true);
        quit.SetActive(true);
        startButton.SetActive(true);
        about.SetActive(true);
        selectChar.SetActive(false);
        backFromShop.SetActive(false);
        selectMap.SetActive(false);
       


    }
    public void About()
    {
        //About screen
    }
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
