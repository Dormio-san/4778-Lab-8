using UnityEngine;
using UnityEngine.EventSystems;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public static GameObject staticEnemy1;
    public static GameObject staticEnemy2;

    // Num of enemies to spawn in.
    private static int numeberOfEnemies = 10;

    public static bool beginSpawningEnemies = true;

    private void Awake()
    {
        staticEnemy1 = enemy1;
        staticEnemy2 = enemy2;

        if (beginSpawningEnemies)
        {
            SpawnEnemies();
        }
    }

    public static void SpawnEnemies()
    {
        for (int i = 0; i < numeberOfEnemies; i++)
        {
            GameObject spawnedEnemy1 = Instantiate(staticEnemy1, new Vector3(1 * i, Random.Range(-2.5f, 0.5f), 0), Quaternion.identity);
            spawnedEnemy1.GetComponent<Builder>().SaveID = System.Guid.NewGuid().ToString();
        }
        for (int i = 0; i < numeberOfEnemies; i++)
        {
            GameObject spawnedEnemy2 = Instantiate(staticEnemy2, new Vector3(1 * i, Random.Range(1.0f, 4.5f), 0), Quaternion.identity);
            spawnedEnemy2.GetComponent<Builder>().SaveID = System.Guid.NewGuid().ToString();
        }
    }

    //private void FixedUpdate()
    //{
    //    if (enemy1.transform.position.x > 7)
    //    {
    //        Instantiate(enemy1, new Vector3(1, 1, 0), Quaternion.identity);
    //    }
    //    if (enemy2.transform.position.x > 7)
    //    {
    //        Instantiate(enemy1, new Vector3(1, 1, 0), Quaternion.identity);
    //    }
    //}
}