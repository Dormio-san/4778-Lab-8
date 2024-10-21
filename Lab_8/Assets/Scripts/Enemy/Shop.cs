using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop
{
    public void Construct(EnemyBuilder enemyBuild)
    {
        enemyBuild.BuildPoints();
        enemyBuild.BuildSpeed();
    }
    
}
