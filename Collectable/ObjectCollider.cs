using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;
//attach with specific object
public class ObjectCollider : MonoBehaviour
{
    public static bool isJumpPowerUp=false;
    public static bool isCoinMagnetPowerUp=false;

    public static bool isScore2XPowerUp = false;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("other.tag: " + other.tag + " this Tag: " + this.tag);
        if (other.tag=="Player" && this.tag=="JumpPowerUp")
        {
            isJumpPowerUp = true;
            Destroy(gameObject);
        }
        if (other.tag == "Player" && this.tag == "CoinMagnet")
        {
            isCoinMagnetPowerUp = true;
            Destroy(gameObject);
        }
        if (other.tag == "Player" && this.tag == "Score2XPowerUp")
        {
            isScore2XPowerUp = true;
            Destroy(gameObject);
        }

    }
}
