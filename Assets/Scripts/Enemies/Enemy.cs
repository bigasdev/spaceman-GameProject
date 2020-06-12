using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject death;
    public Animator anim;

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("Hurt");

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
