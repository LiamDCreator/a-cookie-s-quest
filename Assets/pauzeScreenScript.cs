using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pauzeScreenScript : MonoBehaviour
{
    public Button pauzeGameButton; // Reference to your button
    public Button resumeGameButton; // Reference to your button

    public Canvas pauzeScreen;


    // Start is called before the first frame update
    void Start()
    {
         Button btn = pauzeGameButton.GetComponent<Button>();
        btn.onClick.AddListener(pauzeGame);

          Button btn2 = resumeGameButton.GetComponent<Button>();
        btn2.onClick.AddListener(resumeGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void pauzeGame(){
        Time.timeScale = 0;
         pauzeScreen.gameObject.SetActive(true);

    }
    void resumeGame(){

    Time.timeScale = 1;
         pauzeScreen.gameObject.SetActive(false);

    }
}
