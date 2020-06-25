using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadZone : MonoBehaviour
{
    private GameObject character;
    private Controller control;
    public void Start()
    {
       character = GameObject.Find("STW");
       control = character.GetComponent<Controller>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            control.Die();
        }
    }
}
