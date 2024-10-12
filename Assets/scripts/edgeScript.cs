using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class edgeScript : MonoBehaviour
{
    
   private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "object" tag
        if (collision.gameObject.CompareTag("object"))
        {
            // Ignore collision with the object
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }}