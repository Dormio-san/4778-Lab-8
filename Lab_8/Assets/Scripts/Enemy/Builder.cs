using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    // If enemy goes outside the boundary, spawn them at the other end.
    private float screenBoundary = 10f;

    public GameObject enemy;

    private Text text;
    private int score;
    private EnemyBuilder builder;
    private Shop shop;

    // Score of the enemy that can be accessed by other scripts.
    public int Score => builder.getScore();

    // Start is called before the first frame update
    private void Start()
    {
        if (gameObject.CompareTag("Regular Enemy"))
        {
            shop = new Shop();
            builder = new RegularEnemy();
            shop.Construct(builder);
        }
        else if (gameObject.CompareTag("Big Enemy"))
        {
            shop = new Shop();
            builder = new BigEnemy();
            shop.Construct(builder);
        }
        /*enemy = enemy.GetComponent<GameObject>();*/
    }

    private void FixedUpdate()
    {
        float speed = builder.getSpeed();
        enemy.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, 0);

        if (enemy.transform.position.x > screenBoundary)
        {
            enemy.transform.position = new Vector3(-screenBoundary + speed * Time.deltaTime, transform.position.y, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(enemy);
        //Debug.Log("hello");
        score += builder.getScore();
        //Debug.Log(score);
    }
}