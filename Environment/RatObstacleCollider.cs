using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatObstacleCollider : MonoBehaviour
{
    public GameObject Cat;
    public GameObject Raccon;
    public static bool ratDied;

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
    public Animator ratAnim;

    private void Awake()
    {
        ratDied = false;
    }
    //while collide with rat the game will be over and the collider will be false of rat and rat dead animation will be played
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        

        Cat.GetComponent<PlayerController>().enabled = false;
        CatAnimator.SetBool("GameOver", true);
        //  mainCamCat.GetComponent<Animator>().enabled = true;

        Raccon.GetComponent<PlayerController>().enabled = false;
        RacconAnimator.SetBool("GameOver", true);
        // mainCamRaccon.GetComponent<Animator>().enabled = true;





        ScoreEnd.GetComponent<LevelDistance>().enabled = false;
        ratDied = true;
        isOver.Gameover = true;
        ratAnim.SetBool("RatIsDead", true);
        hitAudio.Play();
    }
}
