using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //メンバー
    protected string Name;
    protected int lv;
    protected int atk;
    protected int def;

    //コンストラクタ
    public Character(){
    }
    public Character(string name, int lv, int atk, int def){
        this.Name = name;
        this.lv = lv;
        this.atk = atk;
        this.def = def;
    }
}

public abstract class BattleCharacter : Character{
    //メンバー
    protected int hp_max;
    protected int hp;
    public Animator animator;

    //コンストラクタ
    public BattleCharacter(int lv):base(){
        this.lv = lv;
    }
    public BattleCharacter(string name, int lv, int hp_max, int hp, int atk, int def):base(name, lv, atk, def)
    {
        this.hp_max = hp_max;
        this.hp = hp;
    }

    //メソッド(外部からアクセス可能)
    public abstract int Attack();
    public abstract int HitReaction(int damage, int element);

    //メソッド(外部からアクセス不可)
    protected bool HitDamage(int damage, float elem){
        this.hp -= (int)(damage * elem);
        return this.hp < 0;
    }
}
