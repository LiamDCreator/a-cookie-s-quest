using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
   
    public float moveSpeed;
    private Vector3 moveDirection = Vector3.up;
    private bool movingUp = true;

   
    public AudioSource playerDiesSound;
    public AudioSource playerDiesWallSound;
    public AudioSource playerDiesWaterSound;
    public AudioSource changeDirectionSound;

   
    public gameOverScreenScript gameOverScreenScript;
    public Canvas gameOverScreen;

       public ParticleSystem playerParticles;
    public Transform particle;

    private void Update()
    {
        MovePlayer();
        HandleInput();
        CheckBounds();
    }

    private void MovePlayer()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            ChangeDirection(Vector3.up, false);

        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            ChangeDirection(Vector3.down, true);

        else if (Input.GetKeyDown(KeyCode.Space) || IsScreenTapped())
        {
            if (moveDirection == Vector3.up)
                ChangeDirection(Vector3.down, true);
            else
                ChangeDirection(Vector3.up, false);
        }
    }

    private void ChangeDirection(Vector3 newDirection, bool toUp)
    {
        if (moveDirection != newDirection)
        {
            moveDirection = newDirection;
            movingUp = toUp;
            changeDirectionSound.volume = Random.Range(0.8f, 1f);
            changeDirectionSound.Play();
        }
    }

    private void CheckBounds()
    {
        if (transform.position.y > 5f || transform.position.y < -5f)
        {
            HandleDeath(playerDiesWaterSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource soundToPlay = collision.gameObject.CompareTag("wall") 
                                  ? playerDiesWallSound 
                                  : playerDiesSound;

        HandleDeath(soundToPlay);
    }

    private void HandleDeath(AudioSource deathSound)
    {
        PlayParticles();
        deathSound.Play();
        Destroy(gameObject);
        TriggerGameOver();
    }

    private void TriggerGameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        gameOverScreenScript.Displayscores();
    }

    private void PlayParticles()
    {
        playerParticles.Play();
        particle.position = transform.position;
    }

    private bool IsScreenTapped()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            return true;
        return false;
    }
}
