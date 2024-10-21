using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4.5f;

    private void Update()
    {
        // Only move on the x at the set speed.
        transform.Translate(InputManager.instance.moveInput.x * Time.deltaTime * speed, 0, 0);
    }
}