using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
   
    public GameObject cat;
    public GameObject racoon;
    public Animator catAnim, racoonAnim;
    public AudioSource catSound;
    public AudioSource racoonSound;

    private void Update()
    {
       
    }
    public void playerJumpCat()
    {
        
            if (!PlayerController.isJumping)
            {
                catSound.Play();
                PlayerController.isJumping = true;
                catAnim.SetBool("Jump", true);
                StartCoroutine(JumpSequenceCat());

            }

        
        if (PlayerController.isJumping)
        {
            if (!PlayerController.ComingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 6, Space.World);
            }
            if (PlayerController.ComingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -6.4f, Space.World);
            }
        }

    }
    IEnumerator JumpSequenceCat()
    {
        yield return new WaitForSeconds(.55f);
        PlayerController.ComingDown = true;
        yield return new WaitForSeconds(.55f);
        PlayerController.isJumping = false;
        PlayerController.ComingDown = false;
        catAnim.SetBool("Jump", false);
        cat.transform.position = new Vector3(cat.transform.position.x, 0, cat.transform.position.z);


    }
    public void playerJumpRacoon()
    {
        
            if (!PlayerController.isJumping)
            {
                catSound.Play();
                PlayerController.isJumping = true;
                catAnim.SetBool("Jump", true);
                StartCoroutine(JumpSequenceRacoon());

            }

        
        if (PlayerController.isJumping)
        {
            if (!PlayerController.ComingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 6, Space.World);
            }
            if (PlayerController.ComingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -6.4f, Space.World);
            }
        }

    }
    IEnumerator JumpSequenceRacoon()
    {
        yield return new WaitForSeconds(.55f);
        PlayerController.ComingDown = true;
        yield return new WaitForSeconds(.55f);
        PlayerController.isJumping = false;
        PlayerController.ComingDown = false;
        racoonAnim.SetBool("Jump", false);
        racoon.transform.position = new Vector3(racoon.transform.position.x, 0, racoon.transform.position.z);


    }
}
