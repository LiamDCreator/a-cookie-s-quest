
using UnityEngine;

public class particleScript : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    [SerializeField] private ParticleSystem playerParticles;
   
   public void playerDiesParticles(){
    transform.position = playerPosition.position;
        playerParticles.Play();
   }
}
