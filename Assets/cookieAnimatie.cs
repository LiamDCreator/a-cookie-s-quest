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
        if(transform.position.y >= 2.2){
            upOrDown = Vector3.down;
        }
         if(transform.position.y <= -2.5){
            upOrDown = Vector3.up;
        }
         if(transform.position.y >= 1.9){
        tapSign.SetActive(true);
        } else {
        tapSign.SetActive(false);

        }
         if(transform.position.y <= -2.2){
        bottonTapSign.SetActive(true);
        } else {
        bottonTapSign.SetActive(false);

        }
    }
}
