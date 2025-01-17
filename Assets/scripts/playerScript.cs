using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public float movespeed;
    private bool movingUP = true;
    public AudioSource playerDiesSound;
    public AudioSource playerDiesWallSound;
    public AudioSource playerDiesWaterSound;

    public AudioSource changeDirectionSound;
    public gameOverScreenScript gameOverScreenScript;
    public Canvas gameOverScreen;
    public Vector3 upOrDown = Vector3.up;
     public ParticleSystem playerParticles;
     public Transform particle;
       
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
           transform.Translate(upOrDown * movespeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            upOrDown = Vector3.down;
            if(movingUP == false){
                changeDirectionSound.volume = UnityEngine.Random.Range(0.8f,1f);
                changeDirectionSound.Play();}
                movingUP = true;

           }

            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            upOrDown = Vector3.up;
            if(movingUP == true){
                changeDirectionSound.volume = UnityEngine.Random.Range(0.8f,1f);

                changeDirectionSound.Play();
            }
            movingUP = false;
           }
        
        
        if(Input.GetKeyDown(KeyCode.Space) || IsScreenTapped()){
            if(upOrDown == Vector3.down){
                upOrDown = Vector3.up;
                movingUP = false;
                changeDirectionSound.volume = UnityEngine.Random.Range(0.8f,1f);

                changeDirectionSound.Play();
            } else if(upOrDown == Vector3.up){
                upOrDown = Vector3.down;
                changeDirectionSound.volume = UnityEngine.Random.Range(0.8f,1f);

                changeDirectionSound.Play();
        movingUP = true;
            }
           }
           
              if (transform.position.y > 5 || transform.position.y < -5){
         playParticles();
        playerDiesWaterSound.Play();
        Destroy(gameObject);
         gameOver();
                
              }
    }
    void OnCollisionEnter2D(Collision2D collision){

       if (collision.gameObject.CompareTag("wall"))
    {
        // Play the sound for hitting a wall
        playerDiesWallSound.Play();
    }
    else
    {
        // Play the sound for player death
        playerDiesSound.Play();
    }

    playParticles();
        Destroy(gameObject);
        
        gameOver();
    } 
    void gameOver(){
        gameOverScreen.gameObject.SetActive(true);
         gameOverScreenScript.DisplayCurrentScore();
         gameOverScreenScript.DisplayHighScore();
    }
    void playParticles(){
        playerParticles.Play();
        particle.transform.position = transform.position;
    }
    private bool IsScreenTapped()
{
    // Check if there's at least one touch and if it began this frame
    if (Input.touchCount > 0)
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            return true;
        }
    }
    return false;
}
}
