using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookieAnimatie : MonoBehaviour
{
    public float movespeed;
    public GameObject tapSign;
    public GameObject bottonTapSign;
    public Vector3 upOrDown = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           transform.Translate(upOrDown * movespeed * Time.deltaTime);
        if(transform.position.y >= 1.8){
            upOrDown = Vector3.down;
        }
         if(transform.position.y <= -2.5){
            upOrDown = Vector3.up;
        }
         if(transform.position.y >= 1.5){
        tapSign.SetActive(true);
        } else {
        tapSign.SetActive(false);

        }
         if(transform.position.y <= -2.2){
        bottonTapSign.SetActive(true);
        } else {
        bottonTapSign.SetActive(false);

        }
          if(Input.GetKeyDown(KeyCode.Space) || IsScreenTapped()){
         tapSign.SetActive(false);
        bottonTapSign.SetActive(false);
        gameObject.SetActive(false);

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