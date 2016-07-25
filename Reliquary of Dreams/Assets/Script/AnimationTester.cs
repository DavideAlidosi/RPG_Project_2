using UnityEngine;
using System.Collections;

public class AnimationTester : MonoBehaviour {

    public Animator animator;
    public int speed;

    bool facingRight = true;

	void Update () {

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

        transform.Translate(transform.right * currentSpeed * Time.deltaTime); //Definisco il movimento per il tempo

        animator.SetInteger("XSpeed", currentSpeed);
        animator.SetBool("FacingRight", facingRight);

    }
}
