using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class Builder : TransformSave
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
    public override string SaveID
    {
        get => base.SaveID; // Access the inherited SaveID property directly
        set => base.SaveID = value;
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
    public override JsonData SavedData
    {
        get
        {
            // Use TransformSave to get saved data
            return base.SavedData;
        }
    }

    // public override string SaveID { get => transformSave.SaveID; set => transformSave.SaveID = value; }s


    // Implementing LoadFromData from ISaveable
    public override void LoadFromData(JsonData data)
    {

        base.LoadFromData(data);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(enemy);
        //Debug.Log("hello");
        score += builder.getScore();
        //Debug.Log(score);
    }
}