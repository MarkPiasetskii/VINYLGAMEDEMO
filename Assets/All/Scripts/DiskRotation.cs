using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskRotation : MonoBehaviour
{
    public float amplitude = 0.1f;
    private bool isMoving = false;
    private float initialY;
    private Vector3 storedPosition;
    private float lastCollisionTime; // Added variable to store the time of the last collision

    public float moveSpeed = 1f;
    public GameObject Light;
    public GameObject LightAround;

    void Start()
    {
        initialY = transform.position.y;
        lastCollisionTime = -1f; // Initialize to a negative value to ensure the first collision is always considered
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check collision with the player and the time between collisions
        if (collision.gameObject.CompareTag("Player") && (Time.time - lastCollisionTime >= 0.5f))
        {
            // Toggle the movement state
            isMoving = !isMoving;

            if (isMoving && !Mathf.Approximately(storedPosition.magnitude, 0))
            {
                // If moving is starting and there is a stored position, use it
                transform.position = storedPosition;
            }
            else
            {
                // If not moving or there is no stored position, store the current position
                storedPosition = transform.position;
            }

            // Update the time of the last collision
            lastCollisionTime = Time.time;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            // Smooth movement up and down based on coordinates within the amplitude
            float newY = initialY + Mathf.PingPong(Time.time * moveSpeed, amplitude * 2) - amplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            float rotationAngle = 0.3f;
            transform.Rotate(new Vector3(0f, 0f, rotationAngle));

            Light.transform.RotateAround(LightAround.transform.position, Vector3.up, 200f * Time.deltaTime);
        }
    }
}
