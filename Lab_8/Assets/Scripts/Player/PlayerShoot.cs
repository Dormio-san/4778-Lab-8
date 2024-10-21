using UnityEngine;

public class PlayerShoot : MonoBehaviour, IObserver
{
    [SerializeField] private Transform firePoint;

    // Reference to the Player script.
    private Player player => GetComponent<Player>();

    private Bullet bullet;
    private int scoreChangeValue = 10;

    public void OnNotify()
    {
        player.ChangeScore(scoreChangeValue);
    }

    public void SetScoreChangeValue(int newScoreChangeValue)
    {
        scoreChangeValue = newScoreChangeValue;
    }

    private void Update()
    {
        if (InputManager.instance.attackInput)
        {
            Shootbullets();
        }
    }

    private void Shootbullets()
    {
        // Get a bullet from the pool and "attach" this script to the bullet.
        // Attaching allows this script to be notified when the bullet hits something.
        bullet = BulletPool.instance.GetBullet();
        bullet.Attach(this);

        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
        }
    }

    // If this script is destroyed, detach it from what it's observing.
    private void OnDestroy()
    {
        player.Detach(this);
    }
}