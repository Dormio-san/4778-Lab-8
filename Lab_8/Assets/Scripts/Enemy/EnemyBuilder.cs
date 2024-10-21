using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBuilder
{
    protected Enemy enemyType;

    public Enemy EnemyType
    {
        get { return enemyType; }
    }


    public int getScore()
    {
        return enemyType.size;
    }
    public float getSpeed()
    {
        return enemyType.speed;
    }


    //The speed of the object
    public abstract void BuildSpeed();

    //The number of points of the object
    public abstract void BuildPoints();
    
}
