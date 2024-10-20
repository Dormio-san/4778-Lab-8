using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    private float maxdDistance = 10f;
    private Vector3 initialPosition;
    public System.Action<Bullet> OnDeactivated;

    // This method causes an issue with bullets where they seem to spawn, but then disappear instantly.
    // With the method commented out, the bullets spawn and move as expected.
    //private void OnEnable()
    //{
    //    initialPosition = transform.position;
    //}

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (Vector3.Distance(initialPosition, transform.position) >= maxdDistance)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("enemy");
            DeactivateBullet();
        }
    }
}