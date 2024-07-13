using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    static public int disRun;
    public int previousScore;
    public static int highScore=0;
    public bool addingDis=false;

    
    public PlayerController playerControllerCat;
    public PlayerController playerControllerRaccon;

    float timer=0.001f;
    public bool gameStart = false;


    

    private void Update()
    {
         
        if (!addingDis && playerControllerCat.gameStart || playerControllerRaccon.gameStart)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
       

    }
    IEnumerator AddingDis()
    {

        if (timer < 0.000001f)
            timer = 0.000001f;
        else
            timer -= 0.000001f;
        if (PauseSystem.instance.isPaused)
        {
            disRun += 0;
        }else if (PlayerController.twoXScore)
        {

            disRun += 2;
        }
        else
        disRun +=1;
       // PlayerPrefs.SetInt("RunInOne", disRun);
        disDisplay.GetComponent<Text>().text = "" + disRun;
        disEndDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(timer);
        addingDis=false;
    }
}
