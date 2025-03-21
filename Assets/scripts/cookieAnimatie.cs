using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookieAnimatie : MonoBehaviour
{
    public float moveSpeed = 4f;
    public GameObject tapSign;
    public GameObject bottomTapSign;
    
    private Vector3 moveDirection = Vector3.up;
    private const float upperLimit = 1.8f;
    private const float lowerLimit = -2.5f;
    private const float tapSignThreshold = 1.5f;
    private const float bottomTapSignThreshold = -2.2f;

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (transform.position.y >= upperLimit)
            moveDirection = Vector3.down;
        else if (transform.position.y <= lowerLimit)
            moveDirection = Vector3.up;

      
        tapSign.SetActive(transform.position.y >= tapSignThreshold);
        bottomTapSign.SetActive(transform.position.y <= bottomTapSignThreshold);

   
        if (Input.GetKeyDown(KeyCode.Space) || IsScreenTapped())
        {
            tapSign.SetActive(false);
            bottomTapSign.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private bool IsScreenTapped()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }
}