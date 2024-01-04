using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject Aj, Josh, Maria, Luna;
    public MainMenuFunction mainMenu;
    public bool aj, josh, luna, maria;


    

    // Update is called once per frame
    void Update()
    {
        
       if(mainMenu.isSelectedAj)
        {
            Aj.SetActive(true);
            Josh.SetActive(false); 
            Maria.SetActive(false);
            Luna.SetActive(false);
        }
        if (mainMenu.isSelectedJosh)
        {
            Aj.SetActive(false);
            Josh.SetActive(true);
            Maria.SetActive(false);
            Luna.SetActive(false);
        }
        if (mainMenu.isSelectedLuna)
        {
            Aj.SetActive(false);
            Josh.SetActive(false);
            Maria.SetActive(false);
            Luna.SetActive(true);
        }
        if (mainMenu.isSelectedMaria)
        {
            Aj.SetActive(false);
            Josh.SetActive(false);
            Maria.SetActive(true);
            Luna.SetActive(false);
        }
    }
}
