using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float moveSpeed;
    public float speed;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
{
    // Move left at a constant speed
    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

    // Move towards the player, but not affecting the leftward movement
    if (player != null)
    {
        // Move towards the player, but not affecting the leftward movement
        Vector3 targetPosition = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, targetPosition.y, targetPosition.z);
    }
}}