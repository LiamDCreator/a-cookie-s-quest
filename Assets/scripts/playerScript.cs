using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public float movespeed;
    private bool movingUP = true;
    public AudioSource playerDiesSound;
    public AudioSource changeDirectionSound;
    public gameOverScreenScript gameOverScreenScript;
    public Canvas gameOverScreen;
    public Vector3 upOrDown = Vector3.up;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
           transform.Translate(upOrDown * movespeed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            upOrDown = Vector3.down;
            if(movingUP == false){
                changeDirectionSound.Play();}
                movingUP = true;

           }

            if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            upOrDown = Vector3.up;
            if(movingUP == true){
                changeDirectionSound.Play();
            }
            movingUP = false;
           }
        
        
        if(Input.GetKeyDown(KeyCode.Space)){
            if(upOrDown == Vector3.down){
                upOrDown = Vector3.up;
                movingUP = false;
                changeDirectionSound.Play();
            } else if(upOrDown == Vector3.up){
                upOrDown = Vector3.down;
                changeDirectionSound.Play();
        movingUP = true;
            }
           }
           
              if (transform.position.y > 5 || transform.position.y < -5){

        Destroy(gameObject);
         gameOver();
                
              }
    }
    void OnCollisionEnter2D(Collision2D collision){
        playerDiesSound.Play();
        Destroy(gameObject);
        
        gameOver();
    }
    void gameOver(){
        gameOverScreen.gameObject.SetActive(true);
         gameOverScreenScript.DisplayCurrentScore();
         gameOverScreenScript.DisplayHighScore();
    }
}
