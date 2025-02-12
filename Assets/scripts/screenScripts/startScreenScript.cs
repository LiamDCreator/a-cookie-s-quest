using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class startScreenScript : MonoBehaviour
{
    private spawnScript spawnScript;
    private playerScript playerScript;
    public Canvas startScreen;
   
    public GraphicRaycaster uiRaycaster;

    // Start is called before the first frame update
    void Start()
    {
        spawnScript = FindObjectOfType<spawnScript>();
        playerScript = FindObjectOfType<playerScript>();

    }

    // Update is called once per frame
    void Update()
    {
           if(Input.GetKeyDown(KeyCode.Space) ||  IsScreenTapped()  ){
         startScreen.gameObject.SetActive(false);
        playerScript.movespeed = 4;
        spawnScript.hasGameStarted = true;

           }
    }
   
  private bool IsScreenTapped()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && !IsTouchOverUI(touch))
            {
                return true;
            }
        }
        return false;
    }
 private bool IsTouchOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = touch.position
        };

        List<RaycastResult> results = new List<RaycastResult>();
        uiRaycaster.Raycast(eventData, results);
        return results.Count > 0;
    }
}
