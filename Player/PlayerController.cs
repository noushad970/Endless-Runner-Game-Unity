using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



//this script is for player which will control the player movement jump slide etc
public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f;
    public float moveAndroidSpeed = 20f;
    public bool gameStart = false;
    static public bool CanMove = false;
    public static bool isJumping = false;
    public static bool ComingDown = false;
    public GameObject playerObject;
    public Animator animator;

    public ParticleSystem ParticleHitEffect;
    CoinMagnetSystem coinMagnetSystem;

    private float _xMovement;
     float xSpeed = 10f;
    private int slideInput = 0;
    // Assuming you have a reference to the GameObject's Transform

    // touch set up
     float swipeThreshold = 30.0f; // Adjust this value as needed for sensitivity.


    [Header("Another Control")]
    //float newXpos = 0f;
    [HideInInspector]
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;

    private CharacterController m_char;
    private Animator m_animator;
    private float x;
     float speedDodge=20;
    private bool InJump, InRoll;
    public float JumpPower = 10f;
    public float forwardSpeed;
    private float y;
    private float colHeight, colCenterY;
    public static bool twoXScore=false;
    [Header("Jump Power Up")]
    float JumpPowerDuration=13f;
    public ParticleSystem jumpUpParticleLoop;
    [Header("Coin Magnet PowerUp")]
    public ParticleSystem coinMagnetParticleLoop;
    float CoinMagnetPowerDuration = 13f;
    [Header("Score 2X PowerUp")]
    public ParticleSystem twoXScoreParticleLoop;
    float Score2XPowerDuration = 13f;
    [Header("Sound System")]

    public AudioSource slideLeftRightSound;
    public AudioSource slideDownSound;
    public AudioSource powerUpObjectCollideSound;
    public AudioSource CatJumpSound;
    public AudioSource RacconJumpSound;
    // Update is called once per frame
    //wait 6 second for cowndown
    private void Start()
    {

        StartCoroutine(waitfor6Sec());
        m_char = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
        coinMagnetSystem=GetComponent<CoinMagnetSystem>();
        coinMagnetSystem.enabled = false;
        transform.position = Vector3.zero;
        colCenterY = m_char.center.y;
        colHeight = m_char.height;
    }

    private void Awake()
    {
    }
    void Update()
    {
        animator.SetBool("Idle", true);
        if (gameStart)
        {
            sliding();
            jump();
            PlayerInputAndMovement();
            animator.SetBool("Idle", false);
            InputHandling();
            if(ObjectCollider.isJumpPowerUp)
            {
                powerUpObjectCollideSound.Play();
                StartCoroutine(jumpPowerUp());
                ObjectCollider.isJumpPowerUp = false;
            }
            if(ObjectCollider.isCoinMagnetPowerUp)
            {
                powerUpObjectCollideSound.Play();
                StartCoroutine(CoinMagnetPowerUp());
                ObjectCollider.isCoinMagnetPowerUp=false;
            }
            if (ObjectCollider.isScore2XPowerUp)
            {

                powerUpObjectCollideSound.Play();
                StartCoroutine(Score2XPowerUp());
                ObjectCollider.isScore2XPowerUp = false;
            }
            

            Debug.Log("PlayerController Character Value: " + charValue);
        }
        
        
    }
    //if swap left or right in android it will switch the player to that side

    //player will perform a sliding while press down key
    void sliding()
    {

        if (slideInput == 1)
        {   slideDownSound.Play();
            animator.Play("Slide");
            StartCoroutine(disableCharControl());
        }
        slideInput = 0;


    }
    int charValue;
    public void loadData(GameData data)
    {
        charValue = data.SelectedCharacter;
    }

    IEnumerator disableCharControl()
    {

          
       
        m_char.center = new Vector3(0,0.22f,0);
        m_char.height = 0.53f;
        yield return new WaitForSeconds(1f);
        m_char.center = new Vector3(0, 0.56f, 0);
        m_char.height = 1.14f;
    }

    IEnumerator waitfor6Sec()
    {
        yield return new WaitForSeconds(6f);
        gameStart = true;
    }
    IEnumerator IncreaseMoveSpeed()
    {
        moveSpeed += 0.0012f;
        yield return new WaitForSeconds(1f);
    }







    int jumpInput = 0;
    void InputHandling()
    {
        if (SwapManager.swipeRight)
        {
            if (_xMovement == 0)
            {
                slideLeftRightSound.Play();
                _xMovement = 2.5f;
            }
            else if (_xMovement == -2.5f)
            {
                slideLeftRightSound.Play();
                _xMovement = 0f;
            }
        }
        else if (SwapManager.swipeLeft)
        {
            if (_xMovement == 0f)
            {
                slideLeftRightSound.Play();
                _xMovement = -2.5f;
            }
            else if (_xMovement == 2.5f)
            {
                slideLeftRightSound.Play();
                _xMovement = 0f;
            }
        }
        if (SwapManager.swapDown)
        {
            slideInput = 1;
        }
        if (SwapManager.swipeUp)
        {
            jumpInput = 1;
        }

    }

    //another movement method
    private void PlayerInputAndMovement()
    {

        SwipeUp = SwapManager.swipeUp || Input.GetKeyDown(KeyCode.Space);
        SwipeDown = SwapManager.swapDown;


        if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            m_animator.SetLayerWeight(1, 0);

        }


        x = Mathf.Lerp(x, _xMovement, Time.deltaTime * speedDodge);

        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, moveSpeed * Time.deltaTime);

        m_char.Move(moveVector);
        if (moveSpeed >= 13f)
            moveSpeed = 13f;
        else
            StartCoroutine(IncreaseMoveSpeed());
    }

    private void jump()
    {
        if (m_char.isGrounded)
        {

            if (SwipeUp)
            {
                if (MainMenuFunction.characterSelection == 1)
                {
                    CatJumpSound.Play();
                }
                if(MainMenuFunction.characterSelection == 2)
                {
                    RacconJumpSound.Play();
                }
                y = JumpPower;
                m_animator.CrossFadeInFixedTime("Jump", 0.1f);
                InJump = true;
            }
        }
        else
        {
            y -= JumpPower * 2 * Time.deltaTime;
            if (m_char.velocity.y < -0.1f)
            {
                playingAnimation("Falling");
            }
        }
    }
    internal float RollCounter;

    public void playingAnimation(string anim)
    {

        m_animator.Play(anim);
    }

    IEnumerator jumpPowerUp()
    {
        float temps=JumpPower;
        jumpUpParticleLoop.Play();
        ParticleHitEffect.Play();
        JumpPower = 17f;
        yield return new WaitForSeconds(JumpPowerDuration);
        JumpPower=temps;
        jumpUpParticleLoop.Stop();
    }
    IEnumerator CoinMagnetPowerUp()
    {
        coinMagnetSystem.enabled=true;
        coinMagnetParticleLoop.Play();
        ParticleHitEffect.Play();
        yield return new WaitForSeconds(CoinMagnetPowerDuration);
        coinMagnetParticleLoop.Stop();
        
        coinMagnetSystem.enabled = false;

    }
    IEnumerator Score2XPowerUp()
    {
        twoXScore = true;
        twoXScoreParticleLoop.Play();
        ParticleHitEffect.Play();
        yield return new WaitForSeconds(Score2XPowerDuration);
        twoXScoreParticleLoop.Stop();
        twoXScore = false;



    }

}
