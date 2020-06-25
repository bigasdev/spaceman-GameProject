using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wandering : MonoBehaviour
{
    public int speed = 20;

    private float wanderTimer = 0;
    public float endtime, finishtime;
    SpriteRenderer pRenderer;

    private void Start()
    {
        pRenderer = GetComponent<SpriteRenderer>();
    }
    public void FixedUpdate()
    {
        wanderTimer += Time.deltaTime;

        if (wanderTimer > 0 && wanderTimer < endtime)
        {
            transform.position += transform.TransformDirection(Vector2.right) * speed * Time.deltaTime;
            pRenderer.flipX = true;
        }
        else
        {
            transform.position += transform.TransformDirection(Vector2.left) * speed * Time.deltaTime;
            pRenderer.flipX = false;
        }

        if(wanderTimer >= finishtime)
        {
            wanderTimer = 0;
        }
    }

}
