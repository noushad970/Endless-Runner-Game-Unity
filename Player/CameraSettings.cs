using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public Animator HitEffectAnim;

    // Update is called once per frame
    void Update()
    {
        if (ObstacleCollider.gameover)
        {
            HitEffectAnim.enabled = (true);
            ObstacleCollider.gameover = false;
        }
    }
}
