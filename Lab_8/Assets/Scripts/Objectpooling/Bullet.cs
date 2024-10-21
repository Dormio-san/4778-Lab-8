using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    private float maxdDistance = 10f;
    public System.Action<Bullet> OnDeactivated;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y >= maxdDistance)
        {
            DeactivateBullet();
        }
    }

    private void DeactivateBullet()
    {
        if (gameObject.activeSelf)
        {
            BulletPool.instance.ReleaseBullet(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyBuilder enemy = other.gameObject.GetComponent<EnemyBuilder>();

        if (enemy != null)
        {
            Debug.Log("enemy");
            DeactivateBullet();
        }
    }
}