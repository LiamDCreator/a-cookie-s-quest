using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
   
     [SerializeField] private float moveSpeed;
    [SerializeField] private float speed;
    [SerializeField] private Sprite[] SpritePic;
    private Transform player;
    

   
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = SpritePic[Random.Range(0,SpritePic.Length)];
       
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        
    }
    void Update()
    {
   
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (player != null)
        {
            Vector3 targetPosition = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, targetPosition.y, targetPosition.z);
        }
         if(transform.position.x < -15){
            Destroy(gameObject);
        }
    }
}