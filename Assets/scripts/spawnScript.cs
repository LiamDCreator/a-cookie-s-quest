using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScript : MonoBehaviour
{
    public GameObject wall;
    public GameObject fatPerson;
    public GameObject walkingPerson;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){

            timer = timer + Time.deltaTime;
        } else {
            Instantiate(fatPerson, transform.position, transform.rotation);
            timer = 0;
        }
    }
    void spawnObject(){}
}
