using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//attach with power up header

public class PowerUpGenerator : MonoBehaviour
{
    public GameObject jumpPowerUpObject, Score2XPowerUpObject, CoinMegnetPowerUpObject;

    private void Start()
    {
        jumpPowerUpObject.SetActive(false);
        Score2XPowerUpObject.SetActive(false);
        CoinMegnetPowerUpObject.SetActive(false);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        int randomNum = 2;//Random.Range(1,4);
        int randomXPosForPowerUp = Random.Range(1, 4);
        Debug.Log("other.tag: " + other.tag + " this Tag: " + this.tag);
        if (other.tag == "Player" && randomNum==1)
        {
            jumpPowerUpObject.SetActive(true);
            if (randomXPosForPowerUp == 1)
            {
                jumpPowerUpObject.transform.position = new Vector3(-2.5f,jumpPowerUpObject.transform.position.y,jumpPowerUpObject.transform.position.z);
            }
            else if(randomXPosForPowerUp == 2)
            {
                jumpPowerUpObject.transform.position = new Vector3(0f, jumpPowerUpObject.transform.position.y, jumpPowerUpObject.transform.position.z);
            }
            else if(randomXPosForPowerUp==3)
            {
                jumpPowerUpObject.transform.position = new Vector3(2.5f, jumpPowerUpObject.transform.position.y, jumpPowerUpObject.transform.position.z);
            }
        }
         if (other.tag == "Player" && randomNum == 2)
        {
            CoinMegnetPowerUpObject.SetActive(true);
            if (randomXPosForPowerUp == 1)
            {
                CoinMegnetPowerUpObject.transform.position = new Vector3(-2.5f, CoinMegnetPowerUpObject.transform.position.y, jumpPowerUpObject.transform.position.z);
            }
            else if (randomXPosForPowerUp == 2)
            {
                CoinMegnetPowerUpObject.transform.position = new Vector3(0f, CoinMegnetPowerUpObject.transform.position.y, jumpPowerUpObject.transform.position.z);
            }
            else if (randomXPosForPowerUp == 3)
            {
                CoinMegnetPowerUpObject.transform.position = new Vector3(2.5f, CoinMegnetPowerUpObject.transform.position.y, jumpPowerUpObject.transform.position.z);
            }
        }
         if (other.tag == "Player" && randomNum == 3)
        {
            Score2XPowerUpObject.SetActive(true);
            if (randomXPosForPowerUp == 1)
            {
                Score2XPowerUpObject.transform.position = new Vector3(-2.5f, Score2XPowerUpObject.transform.position.y, jumpPowerUpObject.transform.position.z);
            }
            else if (randomXPosForPowerUp == 2)
            {
                Score2XPowerUpObject.transform.position = new Vector3(0f, Score2XPowerUpObject.transform.position.y, jumpPowerUpObject.transform.position.z);
            }
            else if (randomXPosForPowerUp == 3)
            {
                Score2XPowerUpObject.transform.position = new Vector3(2.5f, Score2XPowerUpObject.transform.position.y, jumpPowerUpObject.transform.position.z);
            }
        }

    }
}
