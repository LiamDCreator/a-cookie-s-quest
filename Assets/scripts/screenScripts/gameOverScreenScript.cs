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
        DisplayCurrentScore();
        DisplayHighScore();
    }

    void Update()
    {
        currentScoreRef = playerScoreScript.currentScore;
    }

    public void DisplayCurrentScore()
    {
        if (playerScoreScript != null)
        {
            scoreText.text = "Score: " + currentScoreRef.ToString();
        }
    }

    public void DisplayHighScore()
    {
        // Get the high score from PlayerPrefs, defaulting to 0 if it doesn't exist
        highScore = PlayerPrefs.GetInt("highscore", 0);

        // If the current score is higher than the high score, update it
        if (currentScoreRef > highScore)
        {
            highScore = currentScoreRef;
            PlayerPrefs.SetInt("highscore", highScore);
            PlayerPrefs.Save(); // Save the updated high score immediately
        }

        // Display the high score
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}