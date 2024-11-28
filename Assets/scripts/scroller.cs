using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class scroller : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap; // Assign your Tilemap in the Inspector
    [SerializeField] private float scrollSpeedX = 1f; // Speed of scrolling on the X-axis
    [SerializeField] private float scrollSpeedY = 0f; // Speed of scrolling on the Y-axis
    [SerializeField] private float resetDistanceX = 10f; // Distance after which the Tilemap resets
    [SerializeField] private float resetDistanceY = 0f;  // Reset for the Y-axis if needed

    private Vector3 startPosition; // Initial position of the tilemap

    void Start()
    {
        // Store the initial position of the Tilemap
        startPosition = tilemap.transform.position;
    }

    void Update()
    {
        // Calculate the new position
        Vector3 offset = new Vector3(scrollSpeedX * Time.deltaTime, scrollSpeedY * Time.deltaTime, 0);
        tilemap.transform.position -= offset;

        // Check if the Tilemap has moved beyond the reset distance
        if (Mathf.Abs(tilemap.transform.position.x - startPosition.x) >= resetDistanceX)
        {
            tilemap.transform.position = new Vector3(startPosition.x, tilemap.transform.position.y, tilemap.transform.position.z);
        }

        if (Mathf.Abs(tilemap.transform.position.y - startPosition.y) >= resetDistanceY)
        {
            tilemap.transform.position = new Vector3(tilemap.transform.position.x, startPosition.y, tilemap.transform.position.z);
        }
    }
}
