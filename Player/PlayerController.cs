using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//this script is for player which will control the player movement jump slide etc
public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 3f;
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

    // Update is called once per frame
    //wait 6 second for cowndown
    private void Start()
    {

        StartCoroutine(waitfor6Sec());
    }

    void Update()
    {
        animator.SetBool("Idle", true);
        if (gameStart)
        {
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
    {

        if (slideInput == 1)
        {
            animator.SetTrigger("Slide");
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
    void movement()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);



        if (moveSpeed >= 10f)
            moveSpeed = 10f;
        else
            StartCoroutine(IncreaseMoveSpeed());

    }
    void playerJump()
    {
        if ( jumpInput==1)
        {
            if (!isJumping)
            {
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
            }
        }

    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(.55f);
        ComingDown = true;
        yield return new WaitForSeconds(.55f);
        isJumping = false;
        ComingDown = false;
        animator.SetBool("Jump", false);
        playerObject.transform.position = new Vector3(playerObject.transform.position.x, 0, playerObject.transform.position.z);


    }



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
}
