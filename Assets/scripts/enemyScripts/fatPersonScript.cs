using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fatPersonScript : MonoBehaviour
{ 
   
    [SerializeField] private float moveSpeed;
    [SerializeField] private float speed;
    [SerializeField] private Sprite[] SpritePic;
    private Transform player;
   

    // Start is called before the first frame update
    void Start()
    {
       
        GetComponent<SpriteRenderer>().sprite = SpritePic[Random.Range(0,SpritePic.Length)];
        // Automatically find the player object with the "Player" tag in the scene
      
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                player = playerObject.transform;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move left at a constant speed
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Move towards the player, but not affecting the leftward movement
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