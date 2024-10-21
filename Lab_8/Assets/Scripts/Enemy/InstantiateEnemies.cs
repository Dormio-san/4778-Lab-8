using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    private void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemy1, new Vector3(1 * i, 1, 0), Quaternion.identity);
        }
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemy2, new Vector3(1 * i, 2, 0), Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        if (enemy1.transform.position.x > 7)
        {
            Instantiate(enemy1, new Vector3(1, 1, 0), Quaternion.identity);
        }
        if (enemy2.transform.position.x > 7)
        {
            Instantiate(enemy1, new Vector3(1, 1, 0), Quaternion.identity);
        }
    }
}