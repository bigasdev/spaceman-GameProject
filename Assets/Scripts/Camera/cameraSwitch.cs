using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            vcam.LookAt = null;
            vcam.Follow = null;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            vcam.LookAt = player;
            vcam.Follow = player;
        }
    }

}
