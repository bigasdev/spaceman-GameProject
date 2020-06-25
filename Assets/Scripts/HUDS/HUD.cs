using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject smg;
    public GameObject[] life;
    public static int lifeCounter;

    private void Start()
    {
        life[0].SetActive(true);
    }

    private void Update()
    {
        if(Shoot.sWeapon == true)
        {
            smg.SetActive(true);
        }
        else
        {
            smg.SetActive(false);
        }
        
        life[lifeCounter].SetActive(true);

    }
}
