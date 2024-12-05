using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleScript : MonoBehaviour
{
    public Transform playerPosition;
    public ParticleSystem playerParticles;
    // Start is called before the first frame update
   

    // Update is called once per frame
   
   public void playerDiesParticles(){
    transform.position = playerPosition.position;
        playerParticles.Play();
   }
}
