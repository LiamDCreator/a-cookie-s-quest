using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerScore : MonoBehaviour
{  
    public Text playerScoreNow;
    public int currentScore = 0;
 
    private void OnTriggerEnter2D(Collider2D collision){
        currentScore++;
       
       
    }
}