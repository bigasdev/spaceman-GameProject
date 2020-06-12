using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float timer = .45f;
    public AudioSource shootSound;
    public Transform grenadeL;
    public GameObject bullet;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= .45f && Input.GetKeyDown(KeyCode.E))
        {
            timer = 0f;
            Instantiate(bullet, grenadeL.position, grenadeL.rotation);
            shootSound.Play();
        }
    }
}
