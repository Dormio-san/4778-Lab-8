using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularEnemy : EnemyBuilder
{

    public RegularEnemy()
    {
        enemyType = new Enemy();
    }
    // Start is called before the first frame update
    public override void BuildSpeed()
    {
        enemyType.speed = 2.0f;

    }

    //The number of points of the object
    public override void BuildPoints()
    {
        enemyType.size = 50;
    }
}
