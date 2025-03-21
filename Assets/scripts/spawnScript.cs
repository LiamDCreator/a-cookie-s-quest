using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject fatPerson;
    [SerializeField] private GameObject walkingPerson;
    [SerializeField] private float spawnRate = 1;
    [SerializeField] private float heightOffset = 4;
    private float timer = 3;
    
    public bool hasGameStarted = false;
     private GameObject[] spawnableObjects;
    
    private void Start(){
   spawnableObjects = new GameObject[] { wall, wall, wall, wall, fatPerson, fatPerson, walkingPerson, walkingPerson, walkingPerson };
    }
    void Update()
    {if(hasGameStarted == true){
        if(timer < spawnRate){

            timer = timer + Time.deltaTime;
        } else {
           spawnObject();
            timer = 0;
        }}
    }
    void spawnObject()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

       
      

        Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Length)], new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
