using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private float timer = .45f;
    public GameObject bullet;
    public AudioSource shootSound;
    private bool pWeapon = true;
    public static bool sWeapon = false;
    public int bullets = 30;
    
    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= .45f && pWeapon == true && Input.GetButton("Fire1"))
        {
            timer = 0f;
            Instantiate(bullet, transform.position, transform.rotation);
            shootSound.Play();
        }

        if (timer >= .15f && sWeapon == true && Input.GetButton("Fire1"))
        {
            pWeapon = false;
            timer = 0f;
            Instantiate(bullet, transform.position, transform.rotation);
            shootSound.Play();
            bullets -= 1;
        }

        
        if(bullets == 0)
        {
            sWeapon = false;
            pWeapon = true;
        }

    }
}
