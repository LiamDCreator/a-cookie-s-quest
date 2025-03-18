using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject fatPerson;
    [SerializeField] private GameObject walkingPerson;
    [SerializeField] private float spawnRate = 1;
    private float timer = 3;
    [SerializeField] private float heightOffset = 4;
    public bool hasGameStarted = false;
    
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

       
        int randomIndex = Random.Range(0, 11); 
        GameObject objectToSpawn;

        if (randomIndex <= 5) {
            objectToSpawn = wall;
        } else if (randomIndex == 6 ||randomIndex == 7) {
            objectToSpawn = fatPerson;
        } else {
            objectToSpawn = walkingPerson;
        }

        Instantiate(objectToSpawn, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
