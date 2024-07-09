using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject cat,racoon;
  //  public MainMenuFunction mainMenu;
    public bool Cat, Racoon;

    


    // Update is called once per frame
    void Start()
    {
        
       if(MainMenuFunction.characterSelection==1)
        {
            cat.SetActive(true);
            racoon.SetActive(false);
        }
        if (MainMenuFunction.characterSelection == 2)
        {
            cat.SetActive(false);
            racoon.SetActive(true);

        }
       
    }
}
