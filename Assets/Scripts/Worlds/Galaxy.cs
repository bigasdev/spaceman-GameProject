using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Galaxy : MonoBehaviour
{
    private bool onPlayer = false;

    public Transform tFollowTarget;
    public CinemachineVirtualCamera vcam;

    public GameObject ship;

    public Movement mv;

    private void Update()
    {
        if (onPlayer == true && Input.GetKeyDown(KeyCode.E))
        {
            Cam();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            onPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onPlayer = false;
    }

    public void Cam()
    {
        tFollowTarget = ship.transform;
        vcam.LookAt = tFollowTarget;
        vcam.Follow = tFollowTarget;

        mv.enabled = true;

    }
}
