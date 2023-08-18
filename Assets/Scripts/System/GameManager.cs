using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public EnemyDataSO Enemies; // EnemyData 配列をInspectorで設定
    public List<BattleEnemy> enemys = new List<BattleEnemy>();
    public GameObject Player;
    public int enemeyAttackNum;
    private void Start() {
        CreateEnemy();
    }
    private void CreateEnemy()
    {
        for(int i = 0;i < Enemies.enemyDatas.Count;i++){
            Kind kind= (Kind)i;
            enemys.Add(Instantiate((GameObject)Resources.Load("Enemys/"+Enemies.enemyDatas[i].Name),new Vector3(-3 - i,0,0),Quaternion.identity).AddComponent<BattleEnemy>());
            enemys[i].gameObject.name = Enemies.enemyDatas[i].Name + kind.ToString();
            enemys[i].data = Enemies.enemyDatas[i];
            enemys[i].animator = enemys[i].gameObject.GetComponent<Animator>();
            enemys[i].GetComponent<EnemyController>().playerManager = Player.GetComponent<PlayerManager>();
        }
    }
    public void ChangeEnemy(){
        List<BattleEnemy> tmp = new List<BattleEnemy>(enemys);
        tmp.Add(tmp[0]);
        tmp.RemoveAt(0);
        enemys = new List<BattleEnemy>(tmp);
        for(int i = 0;i < enemys.Count;i ++){
            enemys[i].transform.position = new Vector3(-3-i,0);
        }
        if(enemeyAttackNum < Enemies.enemyDatas.Count){
            enemeyAttackNum ++;
            StartCoroutine(enemys[0].enemyController.AttackRoutineStart());
        } 
    }
    enum Kind{
        A,
        B,
        C,
        D
    }
    
    // ...
}