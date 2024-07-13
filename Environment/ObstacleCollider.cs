using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    
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
    public static bool gameover=false;
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

        gameover = true;

        Debug.Log(gameover);

        ScoreEnd.GetComponent<LevelDistance>().enabled = false;

        isOver.Gameover = true;

        hitAudio.Play();
    }
}
