using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endMission : MonoBehaviour
{
    public GameObject mission;
    public Controller mv;

    public float timer = 3f;
    private bool ended = false;

    private void Update()
    {
        if(ended == true)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ended = true;

            mission.SetActive(true);
            mv.moveSpeed = 0f;
            worldsCleared.w1Cleared = true;
        }
    }
}
