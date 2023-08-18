using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public BattleEnemy enemy;
    public PlayerManager playerManager;
    public bool Rigid;
    public int attackFrame;
    private void Start() {
        enemy = gameObject.GetComponent<BattleEnemy>();
    }
    public IEnumerator AttackRoutineStart(){
        yield return new WaitForSeconds(0.1f * (int)Random.Range(0,20));
        if(!Rigid)enemy.Attack();
        yield return new WaitForSeconds(0.1f * (int)Random.Range(attackFrame,attackFrame+10));
        if(!Rigid)playerManager.gameManager.ChangeEnemy();
        yield break;
    }
    public void UnLockRigidity(){
        Rigid = false;
    }
    public void Attack(int DMG){
        playerManager.HitReaction(DMG,1);
    }
}