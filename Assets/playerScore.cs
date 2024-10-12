using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerScore : MonoBehaviour
{  
    public Text playerScoreNow;
    public int currentScore;
    // Start is called before the first frame update
   void start(){
    playerScoreNow.text = currentScore.ToString();
  }

    // Update is called once per frame
   
    private void OnTriggerEnter2D(Collider2D collision){
        currentScore++;
        playerScoreNow.text = currentScore.ToString();
    }
}