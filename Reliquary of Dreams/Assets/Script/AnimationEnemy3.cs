using UnityEngine;
using System.Collections;

public class AnimationEnemy3 : MonoBehaviour {

    //define the varables
    public Animator animatorE3;
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

        animatorE3.SetInteger("e3XSpeed", e3CurrentSpeed);
        animatorE3.SetInteger("e3HP", e3Hp);
        animatorE3.SetBool("e3FacingRight", e3FacingRight);
        animatorE3.SetBool("e3Attack", e3Attack);

    }
}
