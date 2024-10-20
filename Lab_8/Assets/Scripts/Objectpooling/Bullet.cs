using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public float speed = 5f;
    private float maxdDistance = 10f;
    private Vector3 initialPosition;
    public System.Action<Bullet> OnDeactivated;

    private void OnEnable()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if ( Vector3.Distance(initialPosition, transform.position) >= maxdDistance)
        {
            DeactivateBullet();
        } 
    }

    private void DeactivateBullet()
    {
        
       if (gameObject.activeSelf)
        {
            BulletPool.Instance.ReleaseBullet(this);
        }
        
    }
   private void OnTriggerEnter(Collider other) 
   {
    if(other.gameObject.CompareTag("enemy"))
    {   

        Debug.Log("enemy");
       DeactivateBullet();
    }
    
   }

}
