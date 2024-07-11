using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public GameObject normalMapMusic1;
    public GameObject DesertMapMusic, SubwayMapMusic;
    // Start is called before the first frame update
    void Awake()
    {
        
        if (MainMenuFunction.mapSelection == 3 )
        {
            normalMapMusic1.SetActive(false);
            DesertMapMusic.SetActive(true);
            SubwayMapMusic.SetActive(false);
        }
        else if (MainMenuFunction.mapSelection == 4)
        {
            normalMapMusic1.SetActive(false);
            DesertMapMusic.SetActive(false);
            SubwayMapMusic.SetActive(true);
        }
        else
        {
            normalMapMusic1.SetActive(true);
            DesertMapMusic.SetActive(false);
            SubwayMapMusic.SetActive(false);
        }
    }

    
}
