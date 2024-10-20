using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;

    // Update is called once per frame
    private void Update()
    {
        if (InputManager.instance.attackInput)
        {
            Shootbullets();
        }
    }

    private void Shootbullets()
    {
        Bullet bullet = BulletPool.instance.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
        }
    }
}