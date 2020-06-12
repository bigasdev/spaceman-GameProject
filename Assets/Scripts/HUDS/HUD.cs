using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject smg;

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
    }
}
