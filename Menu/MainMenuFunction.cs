using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunction : MonoBehaviour
{
    // Start is called before the first frame update

    public GameOver isOver;
    public GameObject highScore;
    public GameObject shop, about, option, quit, startButton, selectMap, selectChar,backFromShop,BackFromSelectChar,AJButton,JoshButton,MariaButton,LunaButton,AJ,Josh,Luna,Maria;
    public bool isSelectedAj, isSelectedJosh, isSelectedLuna, isSelectedMaria;
    // Update is called once per frame
    private void Start()
    {
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
        AJ.SetActive(isSelectedAj);
        Josh.SetActive(false) ;
        Luna.SetActive(false) ;
        Maria.SetActive(false) ;
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
        AJ.SetActive(false);
    }
    public void ClickOnMaria()
    {
        isSelectedAj = false;
        isSelectedJosh = false;
        isSelectedLuna = false;
        isSelectedMaria = true;
        BackAllCharShow();
        Maria.SetActive(isSelectedMaria);
        AJ.SetActive(false);
        Josh.SetActive(false);
        Luna.SetActive(false);
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
        AJ.SetActive(false);
        Josh.SetActive(false );

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
