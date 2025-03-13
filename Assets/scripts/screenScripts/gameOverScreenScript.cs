using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScreenScript : MonoBehaviour
{
    private playerScore playerScoreScript; // Reference to playerScore script

    public Button restartGameButton;
    public Text scoreText; // Reference to display the score
    public Text highScoreText;
    public int currentScoreRef;
    public int highScore;

    void Start()
    {
        Button btn = restartGameButton.GetComponent<Button>();
        btn.onClick.AddListener(restartGame);

        // Find the playerScore script in the scene
        playerScoreScript = FindObjectOfType<playerScore>();
              

        // Display the current and high scores when the game over screen is shown
        Displayscores();
      
    }

    
    public void Displayscores(){
          if (playerScoreScript != null)
        {
              currentScoreRef = playerScoreScript.currentScore;
            scoreText.text = "Score: " + currentScoreRef.ToString();
        }

          
        highScore = PlayerPrefs.GetInt("highscore", 0);

      
        if (currentScoreRef > highScore)
        {
            highScore = currentScoreRef;
            PlayerPrefs.SetInt("highscore", highScore);
            PlayerPrefs.Save(); 
        }

       
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    void restartGame()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}