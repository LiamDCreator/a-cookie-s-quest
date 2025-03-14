using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class startScreenScript : MonoBehaviour
{
    [SerializeField] private spawnScript spawnScript;
    [SerializeField] private playerScript playerScript;
    [SerializeField] private Canvas startScreen;
    [SerializeField] private GraphicRaycaster uiRaycaster;

 
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
            return touch.phase == TouchPhase.Began && !IsTouchOverUI(touch);
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
