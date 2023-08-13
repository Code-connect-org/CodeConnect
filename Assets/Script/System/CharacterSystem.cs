using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //メンバー
    private string name;
    private int hp_max;
    private int atk;
    private int def;
    private int EXP;

    //コンストラクタ
    public Character(string name, int hp_max, int atk, int def, int EXP){
        this.name = name;
        this.hp_max = hp_max;
        this.atk = atk;
        this.def = def;
        this.EXP = EXP;
    }
}

public class BattleCharacter : Character{
    //メンバー
    private int lv;
    private int hp;

    //コンストラクタ
    public BattleCharacter(string name, int lv, int hp_max, int atk, int def, int EXP):base(name, hp_max, atk, def, EXP){
        this.lv = lv;
    }

    //メソッド(外部からアクセス可能)
    public int Attack();
    public int HitReaction();

    //メソッド(外部からアクセス不可)
    private bool HitDamage(int damage, float element){
        this.hp -= (int)(damage * element);
        return this.hp < 0;
    }
}
