using UnityEngine;
using System.Collections;

public class AnimationEnemy2 : MonoBehaviour {

    //define the varables
    public Animator animatorE2;
    public int e2Speed;

    public int e2Hp;

    bool e2FacingRight = true;

    bool e2Attack = false;

    void Update () {

        //Enemy 3 Methods
        int e2CurrentSpeed = 0;

        if (Input.GetKey(KeyCode.D))
        {
            e2CurrentSpeed = e2Speed;
            e2FacingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            e2CurrentSpeed = -e2Speed;
            e2FacingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.R))
        {
            e2Attack = true;
        }
        else
        {
            e2Attack = false;
        }

        transform.Translate(transform.right * e2CurrentSpeed * Time.deltaTime);

        animatorE2.SetInteger("e2XSpeed", e2CurrentSpeed);
        animatorE2.SetInteger("e2HP", e2Hp);
        animatorE2.SetBool("e2FacingRight", e2FacingRight);
        animatorE2.SetBool("e2Attack", e2Attack);

    }
}
