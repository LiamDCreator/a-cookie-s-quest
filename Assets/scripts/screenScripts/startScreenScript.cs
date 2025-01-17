using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startScreenScript : MonoBehaviour
{
    private spawnScript spawnScript;
    private playerScript playerScript;
    public Canvas startScreen;
    public AudioSource startGameSound;

    // Start is called before the first frame update
    void Start()
    {
        spawnScript = FindObjectOfType<spawnScript>();
        playerScript = FindObjectOfType<playerScript>();

    }

    // Update is called once per frame
    void Update()
    {
           if(Input.GetKeyDown(KeyCode.Space)  || IsScreenTapped()){
         startScreen.gameObject.SetActive(false);
        playerScript.movespeed = 4;
        spawnScript.hasGameStarted = true;

           }
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
