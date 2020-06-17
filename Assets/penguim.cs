using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguim : MonoBehaviour
{
    private Rigidbody2D rb;
    public int jumpSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * jumpSpeed);
    }

}
