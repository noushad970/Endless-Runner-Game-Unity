using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player will not move outside of that boundary. thats mean player movement control sript will not work out of this condition
public class LevelBoundary : MonoBehaviour
{
    public static float Leftside=-3f;
    public static float Rightside=3f;
    public float internalLeftSide;
    public float internalRightSide;
    // Update is called once per frame
    void Update()
    {
        internalLeftSide = Leftside;
        internalRightSide = Rightside;
    }
}
