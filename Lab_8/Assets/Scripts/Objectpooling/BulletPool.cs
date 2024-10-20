using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
     [SerializeField] private Bullet bulletPrefab;
     [SerializeField] private int bulletamount = 10;
     public static BulletPool Instance { get; private set; }
     private ObjectPool<Bullet> pool;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
            return;
        }
        
        
        // Initialize the object pool 7 parameter constructer(1. function <t>, 2. get, 3. release, 4. release "destroy", 5. collection check, 6. pool size, 7 max pool size)
        pool = new ObjectPool<Bullet>(  
        createFunc: () =>  // 1. Create a new bullet instance
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false); 
            return bullet; // Returns the created bullet
        },
        actionOnGet: bullet => bullet.gameObject.SetActive(true), // 2. When we "get" the bullet, activate it                                  
        actionOnRelease: bullet => bullet.gameObject.SetActive(false), // 3. When we "release" the bullet, deactivate it
        actionOnDestroy: null,                     // 4. No action when the bullet is destroyed
        collectionCheck: false,                     // 5. Enable collection checks
        defaultCapacity: bulletamount,                       // 6. Initial pool size
        maxSize: 100                               // 7. Maximum pool size 
        );
        PreloadBullets();
 
    }

 private void PreloadBullets()
    {
        for (int i = 0; i < bulletamount; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab);// Get a bullet from the pool
         
            pool.Release(bullet); // Immediately release it back to make it inactive
        }
    }
    // Method to get a bullet from the pool
    public Bullet GetBullet()
    {  
       return pool.Get();
    }

    // Method to release a bullet back to the pool
    public void ReleaseBullet(Bullet bullet)
    {
        if (bullet != null)
        {
            pool.Release(bullet); // Only release if not null
            
        }
       
    }
   
}
