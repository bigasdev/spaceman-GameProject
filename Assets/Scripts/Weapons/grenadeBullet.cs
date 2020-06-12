using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed;
    public Rigidbody2D rb;
    public int damage = 100;
    public GameObject bulletEffect;
    public AudioSource hitSound;
    private GameObject audioP;

    private GameObject bulletE;

    public void Start()
    {
        rb.AddForce(transform.up * bulletSpeed);
        rb.AddForce(transform.right * bulletSpeed);
        audioP = GameObject.Find("grandeEffect");
        hitSound = audioP.GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
           enemy.TakeDamage(damage);           
        }

        bulletE = Instantiate(bulletEffect, transform.position, Quaternion.identity);
        Destroy(bulletE, .75f);
        Destroy(gameObject, 0f);
        hitSound.Play();
    }
}
