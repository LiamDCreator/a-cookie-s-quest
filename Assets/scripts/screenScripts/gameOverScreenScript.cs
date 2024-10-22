using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScreenScript : MonoBehaviour
{
     public Button restartGameButton;
    public Text scoreText; // Add a Text reference to display the score
    private playerScore playerScoreScript; // Reference to playerScore script
    public int currentScoreRef;

    void Start()
    {
        Button btn = restartGameButton.GetComponent<Button>();
        btn.onClick.AddListener(restartGame);

        // Find the playerScore script in the scene
        playerScoreScript = FindObjectOfType<playerScore>();
        
        // Display the current score when the game over screen is shown
       
    }
    void Update(){
       currentScoreRef = playerScoreScript.currentScore;
       
    }

    public void DisplayCurrentScore()
    {
        if (playerScoreScript != null)
        {
            scoreText.text = "Score: " + currentScoreRef.ToString();
        }
    }

    void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}