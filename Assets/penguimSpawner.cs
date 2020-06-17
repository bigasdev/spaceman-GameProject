using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguimSpawner : MonoBehaviour
{
    public GameObject penguim;
    public Transform[] spots;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(penguim, spots[0].position, spots[0].rotation);
            Instantiate(penguim, spots[1].position, spots[1].rotation);
            Destroy(gameObject);

        } 
    }
}
