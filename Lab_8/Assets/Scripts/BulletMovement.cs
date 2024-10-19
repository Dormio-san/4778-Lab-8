using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float bulletSpeed = 10f;

    private float destroyCoordinate = 10f;

    private void Update()
    {
        // Move the bullet upwards.
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);

        // Check to see if the boundary has left the screen.
        BoundaryCheck();
    }

    private void BoundaryCheck()
    {
        // Destroy the bullet if it goes past the destroy coordinate.
        if (transform.position.y > destroyCoordinate)
        {
            Destroy(gameObject);
        }
    }
}