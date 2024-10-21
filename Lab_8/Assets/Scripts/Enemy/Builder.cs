using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    public GameObject enemy;

    Text text;
    int score;
    EnemyBuilder builder;
    Shop shop;
    // Start is called before the first frame update
    void Start()
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
        enemy.transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(enemy);
        Debug.Log("hello");
        score += builder.getScore();
        Debug.Log(score);

        



    }
}
