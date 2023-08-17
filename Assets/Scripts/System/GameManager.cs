using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public EnemyDataSO Enemies; // EnemyData 配列をInspectorで設定
    List<BattleEnemy> enemys = new List<BattleEnemy>();
    private void Start() {
        CreateEnemy();
    }

    private void CreateEnemy()
    {
        for(int i = 0;i < Enemies.enemyDatas.Count;i++){
            Kind kind= (Kind)i;
            enemys.Add(new BattleEnemy(Enemies.enemyDatas[i], 1, kind.ToString()));
        }
        
        // ...
    }
    enum Kind{
        A,
        B,
        C,
        D
    }
    
    // ...
}