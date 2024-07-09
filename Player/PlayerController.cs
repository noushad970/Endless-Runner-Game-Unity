using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
<<<<<<< HEAD



//this script is for player which will control the player movement jump slide etc
public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 5f;
=======
//this script is for player which will control the player movement jump slide etc
public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 3f;
>>>>>>> 50cc7bd67b430271e31e30d532d81bc1f54d47fd
    public float moveAndroidSpeed = 20f;
    public bool gameStart = false;
    static public bool CanMove = false;
    public static bool isJumping = false;
    public static bool ComingDown = false;
    public GameObject playerObject;
    public Animator animator;
    public AudioSource jumpSound;


    private float _xMovement;
    public float xSpeed = 10f;
    private int slideInput = 0;
    // Assuming you have a reference to the GameObject's Transform

    // touch set up
    public float swipeThreshold = 30.0f; // Adjust this value as needed for sensitivity.


<<<<<<< HEAD
    [Header("Another Control")]
    //float newXpos = 0f;
    [HideInInspector]
    public bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown;

    private CharacterController m_char;
    private Animator m_animator;
    private float x;
    public float speedDodge;
    private bool InJump, InRoll;
    public float JumpPower = 7f;
    public float forwardSpeed;
    private float y;
    private float colHeight, colCenterY;

=======

    //adding touch settings for android

    private Touch stouch;
    bool hasSwiped = false;

    void TouchHandling()
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
                stouch = t;
            else if (t.phase == TouchPhase.Moved && !hasSwiped)
            {
                float Xswipe = stouch.position.x - t.position.x;
                float Yswipe = stouch.position.y - t.position.y;
                float distance = Mathf.Sqrt((Xswipe * Xswipe)) + Mathf.Sqrt((Yswipe * Yswipe));
                bool isVertical = false;
                if (Mathf.Abs(Xswipe) < Mathf.Abs(Yswipe))
                {
                    isVertical = true;
                }
                if (distance > 5f)
                {
                    if (isVertical)
                    {
                        if (Yswipe < 0)
                        {
                            //will jump
                            jumpInput = 1;
                        }
                        else if (Yswipe > 0)
                        {
                            slideInput = 1;
                        }
                    }
                    else if (!isVertical)
                    {
                        if (Xswipe < 0)
                        {
                            if (_xMovement == 0)
                            {
                                _xMovement = 1.5f;
                            }
                            else if (_xMovement == -1.5f)
                            {
                                _xMovement = 0f;
                            }
                        }
                        else if (Xswipe > 0)
                        {
                            if (_xMovement == 0f)
                            {
                                _xMovement = -1.5f;
                            }
                            else if (_xMovement == 1.5f)
                            {
                                _xMovement = 0f;
                            }
                        }
                    }
                }
            }
        }
    }

>>>>>>> 50cc7bd67b430271e31e30d532d81bc1f54d47fd
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
<<<<<<< HEAD
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
=======
            movement();
            playerJump();
            TouchHandling();
            sliding();
            animator.SetBool("Idle", false);
            InputHandling();
            moveX();
        }
    }
    bool swapleftright;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    //if swap left or right in android it will switch the player to that side

    //player will perform a sliding while press down key
    public void sliding()
>>>>>>> 50cc7bd67b430271e31e30d532d81bc1f54d47fd
    {

        if (slideInput == 1)
        {
<<<<<<< HEAD
            animator.Play("Slide");
=======
            animator.SetTrigger("Slide");
>>>>>>> 50cc7bd67b430271e31e30d532d81bc1f54d47fd
        }
        slideInput = 0;


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
<<<<<<< HEAD
        if (SwapManager.swipeRight)
        {
            if (_xMovement == 0)
            {
                _xMovement = 1.5f;
            }
            else if (_xMovement == -1.5f)
            {
                _xMovement = 0f;
            }
        }
        else if (SwapManager.swipeLeft)
        {
            if (_xMovement == 0f)
            {
                _xMovement = -1.5f;
            }
            else if (_xMovement == 1.5f)
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
=======
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);



>>>>>>> 50cc7bd67b430271e31e30d532d81bc1f54d47fd
        if (moveSpeed >= 10f)
            moveSpeed = 10f;
        else
            StartCoroutine(IncreaseMoveSpeed());
    }

    private void jump()
    {
<<<<<<< HEAD
        if (m_char.isGrounded)
=======
        if ( jumpInput==1)
>>>>>>> 50cc7bd67b430271e31e30d532d81bc1f54d47fd
        {
            
            if (SwipeUp)
            {
<<<<<<< HEAD
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
=======
                jumpSound.Play();
                isJumping = true;
                animator.SetTrigger("Jump");
                StartCoroutine(JumpSequence());

            }

        }
        jumpInput= 0;
        if (isJumping)
        {
            if (!ComingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 6, Space.World);
            }
            if (ComingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -6.4f, Space.World);
>>>>>>> 50cc7bd67b430271e31e30d532d81bc1f54d47fd
            }
        }
    }
    internal float RollCounter;
    
    public void playingAnimation(string anim)
    {

        m_animator.Play(anim);
    }
<<<<<<< HEAD
=======



    void moveX()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_xMovement, transform.position.y, transform.position.z), Time.deltaTime * xSpeed);
    }

    int jumpInput = 0;
    void InputHandling()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_xMovement == 0)
            {
                _xMovement = 1.5f;
            }
            else if (_xMovement == -1.5f)
            {
                _xMovement = 0f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_xMovement == 0f)
            {
                _xMovement = -1.5f;
            }
            else if (_xMovement == 1.5f)
            {
                _xMovement = 0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            slideInput = 1;
        }
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            jumpInput = 1;
        }

    }
>>>>>>> 50cc7bd67b430271e31e30d532d81bc1f54d47fd
}
