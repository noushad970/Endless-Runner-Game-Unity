using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    //Aj=1,Josh=2,Maria=3,Luna=4
    public int coins, SelectedCharacter,selectedMap;
    public bool isEnableDesertMap, isEnableSubWayMap;
    
    //game data variable name
    public GameData()
    {
        this.coins = 0;
        this.SelectedCharacter = 1;
        this.selectedMap = 1;
        this.isEnableDesertMap = false;
        this.isEnableSubWayMap = false;
    }
}
