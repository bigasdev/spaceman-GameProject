using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int totalScore;
    public static int lives = 3;
    private void Update()
    {
        if(totalScore >= 5000)
        {
            lives += 1;
        }

        if(lives <= 0)
        {
            Debug.Log("Fim de jogo");
        }
    }

}
