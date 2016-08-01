using UnityEngine;
using System.Collections;

public class AnimationHero : MonoBehaviour {

    //define the varables
    public Animator animator;
    public int speed;

    public AudioClip attackSound;

    public int hp;

    bool facingRight = true;

    public bool attack = false;
    

    void Update () {
        
        //Hero methods
        int currentSpeed = 0;

        if (Input.GetKey(KeyCode.D))
        {
            currentSpeed = speed;
            facingRight = true;
            transform.localScale = new Vector3(1, 1, 1);

        }

        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed = -speed;
            facingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.R))
        {
            attack = true;
            SoundManager.instance.PlaySingle(attackSound);
        }
        else
        {
            //attack = false;
        }

        transform.Translate(transform.right * currentSpeed * Time.deltaTime);

        animator.SetInteger("XSpeed", currentSpeed);
        animator.SetInteger("HP", hp);
        animator.SetBool("FacingRight", facingRight);
        animator.SetBool("Attack", attack);
        

    }
    public void AttackSound()
    {
        animator.SetTrigger("Attack");
        SoundManager.instance.PlaySingle(attackSound);
    }
}
