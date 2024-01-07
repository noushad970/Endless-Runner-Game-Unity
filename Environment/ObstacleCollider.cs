using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    //
    public GameObject AJ;
    public GameObject Josh;
    public GameObject Maria;
    public GameObject Luna;
    //
    //public GameObject AJcharModel;
    //public GameObject JoshcharModel;
    //public GameObject MariacharModel;
    //public GameObject LunacharModel;
    //
    public Animator AJAnimator;
    public Animator JoshAnimator;
    public Animator MariaAnimator;
    public Animator LunaAnimator;
    //
    public GameObject mainCamAJ;
    public GameObject mainCamJosh;
    public GameObject mainCamMaria;
    public GameObject mainCamLuna;
    //
    public bool hitSoundPlay = false;
    public AudioSource hitAudio;
    public GameObject ScoreEnd;
    public GameOver isOver;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        AJ.GetComponent<PlayerController>().enabled = false;
        AJAnimator.SetBool("GameOver", true);
        mainCamAJ.GetComponent<Animator>().enabled = true;


        Josh.GetComponent<PlayerController>().enabled = false;
        JoshAnimator.SetBool("GameOver", true);
        mainCamJosh.GetComponent<Animator>().enabled = true;


        Maria.GetComponent<PlayerController>().enabled = false;
        MariaAnimator.SetBool("GameOver", true);
        mainCamMaria.GetComponent<Animator>().enabled = true;


        Luna.GetComponent<PlayerController>().enabled = false;
        LunaAnimator.SetBool("GameOver", true);
        mainCamLuna.GetComponent<Animator>().enabled = true;





        ScoreEnd.GetComponent<LevelDistance>().enabled = false;

        isOver.Gameover = true;

        hitAudio.Play();
    }
}
