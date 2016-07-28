using UnityEngine;
using System.Collections;

public class AnimationEnemy1 : MonoBehaviour {

    //define the varables
    public Animator animator;
    public int e1Speed;

    public int e1Hp;

    bool e1FacingRight = true;

    bool e1Attack = false;

    void Update () {

        //Enemy 3 Methods
        int e1CurrentSpeed = 0;

        if (Input.GetKey(KeyCode.D))
        {
            e1CurrentSpeed = e1Speed;
            e1FacingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            e1CurrentSpeed = -e1Speed;
            e1FacingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.R))
        {
            e1Attack = true;
        }
        else
        {
            e1Attack = false;
        }

        transform.Translate(transform.right * e1CurrentSpeed * Time.deltaTime);

        animator.SetInteger("e1XSpeed", e1CurrentSpeed);
        animator.SetInteger("e1HP", e1Hp);
        animator.SetBool("e1FacingRight", e1FacingRight);
        animator.SetBool("e1Attack", e1Attack);

    }
}
