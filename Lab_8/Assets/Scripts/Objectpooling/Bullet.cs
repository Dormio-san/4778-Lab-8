using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, ISubject
{
    // List of observers that are waiting for the player's state to change.
    private List<IObserver> observers = new List<IObserver>();

    public float speed = 5f;
    private float maxdDistance = 10f;
    public System.Action<Bullet> OnDeactivated;

    // The observer that is attached to this bullet.
    private IObserver playerShootObserver;

    // Attach (add) an observer to the list of observers.
    public void Attach(IObserver observer)
    {
        observers.Add(observer);

        // If the observer that attches itseslf to this bullet is the PlayerShoot, then set the playerShootObserver to this observer.
        if (observer is PlayerShoot)
        {
            playerShootObserver = observer;
        }
    }

    // Detach (remove) an observer from the list of observers.
    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        // Notify all observers and let them do their logic that depends on the player's state.
        foreach (IObserver observer in observers)
        {
            observer.OnNotify();
        }
    }

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
            // When deactivating the bullet, detach the PlayerShoot observer from this bullet as well.
            // Detaching ensures that the PlayerShoot observer is not notified multiple times when a bullet hits something.
            Detach(playerShootObserver);
            BulletPool.instance.ReleaseBullet(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the hit object has the Builder class.
        Builder enemy = other.gameObject.GetComponent<Builder>();

        if (enemy != null)
        {
            // Notify observers and deactivate the bullet.
            Notify();
            DeactivateBullet();
        }
    }
}