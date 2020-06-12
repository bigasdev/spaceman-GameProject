using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;
    public int damage = 40;
    public GameObject bulletEffect;
    public AudioSource hitSound;
    private GameObject audioP;

    private GameObject bulletE;

    public void Start()
    {
        rb.velocity = transform.right * bulletSpeed;
        audioP = GameObject.Find("hitEffect");
        hitSound = audioP.GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            hitSound.Play();
        }

        bulletE = Instantiate(bulletEffect, transform.position, Quaternion.identity);   
        Destroy(bulletE, .25f);
        Destroy(gameObject, 0f);
    }
}
