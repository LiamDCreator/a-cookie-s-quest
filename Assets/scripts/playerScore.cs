using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerScore : MonoBehaviour
{  
    [SerializeField] private Text playerScoreNow;
     [SerializeField] private AudioSource playerPointSound;

    public int currentScore = 0;
 
    private void OnTriggerEnter2D(Collider2D collision){
        currentScore++;
         playerScoreNow.text = currentScore.ToString();
                playerPointSound.volume = UnityEngine.Random.Range(0.8f,1f);

       playerPointSound.Play();
    }
}