using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldChooser : MonoBehaviour
{
    public Animator anim;
    private bool onPlayer = false;

    public int world;


     
    private void Update()
    {      
        
        if(onPlayer == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(world);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ship" && anim.GetBool("active"))
        {
            onPlayer = true;
            anim.SetBool("onChoose", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onPlayer = false;
        anim.SetBool("onChoose", false);
    }
}
