using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject death;
    public Animator anim;
    private AudioSource dead;
    private GameObject deadHolder;
    private void Start()
    {
        deadHolder = GameObject.Find("dieSound");
        dead = deadHolder.GetComponent<AudioSource>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("Hurt");

        if(health <= 0)
        {
            Die();
            dead.Play();
        }
    }

    void Die()
    {
        Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
