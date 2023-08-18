using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public EnemyDataSO Enemies; // EnemyData 配列をInspectorで設定

    private void CreateEnemy()
    {
        BattleEnemy Slime = new BattleEnemy(Enemies.enemyDatas[1], 1, "A", true);
        
        // ...
    }

    // ...
}