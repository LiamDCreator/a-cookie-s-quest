using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOverScreenScript : MonoBehaviour
{
   
     public Button restartGameButton; 
   
    void Start()
    {
          Button btn = restartGameButton.GetComponent<Button>();
        btn.onClick.AddListener(restartGame);
        
    }

    // Update is called once per frame

    void restartGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
