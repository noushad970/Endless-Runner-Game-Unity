using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject Aj, Josh, Maria, Luna;
    public MainMenuFunction mainMenu;
    public bool aj, josh, luna, maria;

    



    // Update is called once per frame
    void Start()
    {
        
       if(MainMenuFunction.characterSelection==1)
        {
            Aj.SetActive(true);
            Josh.SetActive(false); 
            Maria.SetActive(false);
            Luna.SetActive(false);
        }
        if (MainMenuFunction.characterSelection == 2)
        {
            Aj.SetActive(false);
            Josh.SetActive(true);
            Maria.SetActive(false);
            Luna.SetActive(false);
        }
        if (MainMenuFunction.characterSelection == 4)
        {
            Aj.SetActive(false);
            Josh.SetActive(false);
            Maria.SetActive(false);
            Luna.SetActive(true);
        }
        if (MainMenuFunction.characterSelection == 3)
        {
            Aj.SetActive(false);
            Josh.SetActive(false);
            Maria.SetActive(true);
            Luna.SetActive(false);
        }
    }
}
