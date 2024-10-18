using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject wall;
    public GameObject fatPerson;
    public GameObject walkingPerson;
    public float spawnRate = 3;
    private float timer = 0;
    public float heightOffset = 4;
    // Start is called before the first frame update
    void Start()
    {
        spawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){

            timer = timer + Time.deltaTime;
        } else {
           spawnObject();
            timer = 0;
        }
    }
    void spawnObject(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

    Instantiate(wall, new Vector3(transform.position.x,Random.Range(lowestPoint,highestPoint), 0), transform.rotation);
    }
}
