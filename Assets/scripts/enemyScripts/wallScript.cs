using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wallScript : MonoBehaviour
{

     [SerializeField] private float movespeed;
   
   

    // Update is called once per frame
    void Update()
    {
        
          transform.Translate(Vector3.left * movespeed * Time.deltaTime);

           if(transform.position.x < -15){
            Destroy(gameObject);
        }
    }
 
}
