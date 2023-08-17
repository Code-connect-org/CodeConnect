using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //メンバー
    public EnemyDataSO data_origin;

    //コンストラクタ
    public Enemy(EnemyDataSO _data)
    {
        this.data_origin = _data;
    }
}
public class BattleEnemy : BattleCharacter
{
    //メンバー
    private float[] weakness;
    private int spd;
    private int EXP;
    private int frame;

    //コンストラクタ
    public BattleEnemy(EnemyData _data, int lv, string kind):base(lv){
        this.Name = _data.Name;
        this.Name += kind;
        this.lv = lv;
        this.weakness = new float[] { 2, 2, 2, 2 };
        CalculateStatus(_data.hp, _data.atk, _data.def, _data.spd, _data.grow, _data.EXP);
        CalculateFrame(_data.frame);
        this.hp = this.hp_max;
        this.animator = Instantiate((GameObject)Resources.Load("Enemys/"+_data.Name),new Vector3(-3,0,0),Quaternion.identity).GetComponent<Animator>();
        this.animator.gameObject.name = this.Name;
    }

    //メソッド(外部からアクセス可能)
    public override int Attack(){
        int atk_final = this.atk * 2;
        animator.Play("Enemy Attack 1");
        return atk_final;
    }
    public override int HitReaction(int damage, int element){
        if (HitDamage(damage, weakness[element])){
            return 0;
        }
        animator.Play("Enemy Hit");
        return this.hp;
    }

    //メソッド(外部からアクセス不可)
    private void CalculateStatus(int hitpoint, int attack, int defence, int speed, float grows, int experience) {
        this.hp_max = (int)(hitpoint * (1 + this.lv * grows));
        this.atk = (int)(attack * (1 + this.lv * grows));
        this.def = (int)(defence * (1 + this.lv * grows));
        this.spd = (int)(speed * (1 + this.lv * grows));
        this.EXP = (int)(experience * (1 + this.lv * grows * 5));
    }
    private void CalculateFrame(int temp_frame){
        this.frame = (int)(Mathf.Exp(Mathf.Sqrt(this.spd + 12) / -5) * temp_frame * 2);
    }
}
