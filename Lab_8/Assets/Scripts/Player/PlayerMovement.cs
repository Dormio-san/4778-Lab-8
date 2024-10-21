using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4.5f;
    private float screenBoundary = 9f;

    private void Update()
    {
        // Only move on the x at the set speed.
        transform.Translate(InputManager.instance.moveInput.x * Time.deltaTime * speed, 0, 0);

        // Check if the player is outside the boundary.
        BoundaryChecks();
    }

    // If the player is outside the boundary, set the player's position to the opposite boundary.
    private void BoundaryChecks()
    {
        if (transform.position.x > screenBoundary)
        {
            transform.position = new Vector3(-screenBoundary, transform.position.y, 0);
        }
        else if (transform.position.x < -screenBoundary)
        {
            transform.position = new Vector3(screenBoundary, transform.position.y, 0);
        }
    }
}