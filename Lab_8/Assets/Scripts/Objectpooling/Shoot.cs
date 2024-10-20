using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;


    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.attackInput)
        {
            Shootbullets(); 
        }
    }
    private void Shootbullets()
    {

        Bullet bullet = BulletPool.Instance.GetBullet();
        if(bullet !=null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
           
        }
        
        
    }
}
