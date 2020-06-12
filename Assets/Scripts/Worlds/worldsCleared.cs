using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldsCleared : MonoBehaviour
{
    public static bool w1Cleared = false;
    public static bool w2Cleared = false;
    public static bool w3Cleared = false;
    public static bool w4Cleared = false;

    public Animator[] w1;
    public Animator[] w2;
    public Animator[] w3;
    public Animator w4;

    private void Update()
    {
       if(w1Cleared == true)
        {
            w1[0].SetBool("active", true);
            w1[1].SetBool("active", true);
        }
        if (w2Cleared == true)
        {
            w2[0].SetBool("active", true);
            w2[1].SetBool("active", true);
        }
        if (w3Cleared == true)
        {
            w3[0].SetBool("active", true);
            w3[1].SetBool("active", true);
        }
        if (w4Cleared == true)
        {
            w4.SetBool("active", true);
        }
    }
}
