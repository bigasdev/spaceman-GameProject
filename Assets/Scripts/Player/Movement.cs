using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float curSpeed;
    public Rigidbody2D rb;

    public Animator anim;

    private void FixedUpdate()
    {
        // Move senteces
        rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("up", true);
        }
        else
        {
            anim.SetBool("up", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("left", true);
        }
        else
        {
            anim.SetBool("left", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("right", true);
        }
        else
        {
            anim.SetBool("right", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("down", true);
        }
        else
        {
            anim.SetBool("down", false);
        }




    }
}
