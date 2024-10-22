using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startScreenScript : MonoBehaviour
{
    private spawnScript spawnScript;
    private playerScript playerScript;
    public Canvas startScreen;
    // Start is called before the first frame update
    void Start()
    {
        spawnScript = FindObjectOfType<spawnScript>();
        playerScript = FindObjectOfType<playerScript>();

    }

    // Update is called once per frame
    void Update()
    {
           if(Input.GetKeyDown(KeyCode.Space)){
         startScreen.gameObject.SetActive(false);
        playerScript.movespeed = 4;
        spawnScript.hasGameStarted = true;
           }
    }
}
