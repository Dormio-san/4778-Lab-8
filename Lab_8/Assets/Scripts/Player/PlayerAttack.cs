using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    /// Below is just testing code for the attack. This will be changed to use object pooling.
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletSpawn;

    private void Update()
    {
        if (InputManager.instance.attackInput)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
    }
}
