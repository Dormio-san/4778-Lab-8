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

    public abstract void BuildSpeed();
    public abstract void BuildSize();
    
}
