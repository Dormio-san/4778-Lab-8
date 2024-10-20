using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : EnemyBuilder
{
    public BigEnemy()
    {
        enemyType = new Enemy();
    }
    

    //Assigns the speed of the enemy
    public override void BuildSpeed()
    {
        enemyType.speed = 5.0f;

    }

    //The number of points of the object
    public override void BuildPoints()
    {
        enemyType.size = 100;
    }
}
