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
    public AudioSource jumpSound;


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
    // Update is called once per frame
    //wait 6 second for cowndown
    private void Start()
    {

        StartCoroutine(waitfor6Sec());
        m_char = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
        transform.position = Vector3.zero;
        colCenterY = m_char.center.y;
        colHeight = m_char.height;
    }

    void Update()
    {
        animator.SetBool("Idle", true);
        if (gameStart)
        {
            //movement();
            //playerJump();
            sliding();
            //rolling();
            jump();
            PlayerInputAndMovement();
            animator.SetBool("Idle", false);
            InputHandling();
            // StartCoroutine(moveX());
        }
    }
    //if swap left or right in android it will switch the player to that side

    //player will perform a sliding while press down key
    void sliding()
    {

        if (slideInput == 1)
        {
            animator.Play("Slide");
            StartCoroutine(disableCharControl());
        }
        slideInput = 0;


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
        moveSpeed += 0.001f;
        yield return new WaitForSeconds(1f);
    }







    int jumpInput = 0;
    void InputHandling()
    {
        if (SwapManager.swipeRight)
        {
            if (_xMovement == 0)
            {
                _xMovement = 2.5f;
            }
            else if (_xMovement == -2.5f)
            {
                _xMovement = 0f;
            }
        }
        else if (SwapManager.swipeLeft)
        {
            if (_xMovement == 0f)
            {
                _xMovement = -2.5f;
            }
            else if (_xMovement == 2.5f)
            {
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
        if (moveSpeed >= 10f)
            moveSpeed = 10f;
        else
            StartCoroutine(IncreaseMoveSpeed());
    }

    private void jump()
    {
        if (m_char.isGrounded)
        {

            if (SwipeUp)
            {
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
}
