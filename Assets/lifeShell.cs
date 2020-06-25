using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeShell : MonoBehaviour
{
    public int points;
    public Transform place;
    public GameObject effect;
    private AudioSource coin;
    private GameObject soundHolder;
    private void Start()
    {
        soundHolder = GameObject.Find("collectableSound");
        coin = soundHolder.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Score.lives += 1;
            HUD.lifeCounter += 1;
            var pEfffect = Instantiate(effect, place.position, Quaternion.identity);
            Destroy(pEfffect, 1f);
            Destroy(gameObject);
            coin.Play();
        }
    }
}
