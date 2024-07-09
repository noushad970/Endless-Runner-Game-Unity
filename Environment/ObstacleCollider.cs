using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    //
    /* public GameObject AJ;
     public GameObject Josh;
     public GameObject Maria;
     public GameObject Luna;

     public Animator AJAnimator;
     public Animator JoshAnimator;
     public Animator MariaAnimator;
     public Animator LunaAnimator;
     
    public GameObject mainCamAJ;
    public GameObject mainCamJosh;
    public GameObject mainCamMaria;
    public GameObject mainCamLuna;
    */
    public GameObject Cat;
    public GameObject Raccon;

    
    public Animator CatAnimator;
    public Animator RacconAnimator;
    //
    public GameObject mainCamCat;
    public GameObject mainCamRaccon;
    //
    public bool hitSoundPlay = false;
    public AudioSource hitAudio;
    public GameObject ScoreEnd;
    public GameOver isOver;
    //while player collide with an object it will be game over
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Collider>().enabled = false;

        Cat.GetComponent<PlayerController>().enabled = false;
        CatAnimator.SetBool("GameOver", true);
      //  mainCamCat.GetComponent<Animator>().enabled = true;

        Raccon.GetComponent<PlayerController>().enabled = false;
        RacconAnimator.SetBool("GameOver", true);
       // mainCamRaccon.GetComponent<Animator>().enabled = true;





        ScoreEnd.GetComponent<LevelDistance>().enabled = false;

        isOver.Gameover = true;

        hitAudio.Play();
    }
}
