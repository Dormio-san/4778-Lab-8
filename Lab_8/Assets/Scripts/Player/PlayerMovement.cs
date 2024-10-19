using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 4.5f;
    private void Update()
    {
        transform.Translate(InputManager.instance.moveInput.x * Time.deltaTime * speed, 0, 0);
    }
}