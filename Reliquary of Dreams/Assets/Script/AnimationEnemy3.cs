using UnityEngine;
using System.Collections;

public class AnimationEnemy3 : MonoBehaviour {

    //define the varables
    public Animator animator;
    public int e3Speed;

    public int e3Hp;

    bool e3FacingRight = true;

    bool e3Attack = false;

    void Update () {

        //Enemy 3 Methods
        int e3CurrentSpeed = 0;

        if (Input.GetKey(KeyCode.D))
        {
            e3CurrentSpeed = e3Speed;
            e3FacingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            e3CurrentSpeed = -e3Speed;
            e3FacingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.R))
        {
            e3Attack = true;
        }
        else
        {
            e3Attack = false;
        }

        transform.Translate(transform.right * e3CurrentSpeed * Time.deltaTime);

        animator.SetInteger("e3XSpeed", e3CurrentSpeed);
        animator.SetInteger("e3HP", e3Hp);
        animator.SetBool("e3FacingRight", e3FacingRight);
        animator.SetBool("e3Attack", e3Attack);

    }
}
