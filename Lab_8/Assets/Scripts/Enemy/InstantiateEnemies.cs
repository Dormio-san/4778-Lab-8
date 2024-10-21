using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    // Num of enemies to spawn in.
    private int numeberOfEnemies = 10;

    private void Start()
    {
        for (int i = 0; i < numeberOfEnemies; i++)
        {
            Instantiate(enemy1, new Vector3(1 * i, Random.Range(-2.5f, 0.5f), 0), Quaternion.identity);
        }
        for (int i = 0; i < numeberOfEnemies; i++)
        {
            Instantiate(enemy2, new Vector3(1 * i, Random.Range(1.0f, 4.5f), 0), Quaternion.identity);
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