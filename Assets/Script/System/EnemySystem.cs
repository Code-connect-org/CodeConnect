using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    //メンバー
    private int id;
    private int spd;
    private float grow;

    //コンストラクタ
    public Enemy(int id) : base(Enemies[id].name, Enemies[id].hp, Enemies[id].atk, Enemies[id].def, Enemies[id].EXP)
    {
        this.id = id;
        this.spd = Enemies[id].spd;
        this.grow = Enemies[id].grow;
    }
}
public class BattleEnemy : BattleCharacter
{
    //メンバー
    private int id;
    private List<int> original = new List<int>();
    private int spd;
    private int EXP;
    private int frame;
    private int frame_origin;

    //コンストラクタ
    public BattleEnemy(int id, int lv, string kind){
        this.id = id;
        this.lv = lv;
        this.name = Enemies[id].name;
        this.name += kind;
        this.original.Add(Enemies[id].hp);
        this.original.Add(Enemies[id].atk);
        this.original.Add(Enemies[id].def);
        this.original.Add(Enemies[id].spd);
        this.original.Add(Enemies[id].frame);
        this.original.Add(Enemies[id].EXP);
        this.grow = Enemies[id].grow;
        CalculateStatus(original[0], original[1], original[2], original[3], original[5]);
        this.hp = this.hp_max;
        this.frame = CalculateFrame(original[4]);
    }

    //メソッド(外部からアクセス可能)
    public int Attack();
    public int HitReaction();

    //メソッド(外部からアクセス不可)
    private void CalculateStatus(int hitpoint, int attack, int defence, int speed, int experience) {
        this.hp_max = (int)(hitpoint * (1 + this.lv * this.grow));
        this.atk = (int)(attack * (1 + this.lv * this.grow));
        this.def = (int)(defence * (1 + this.lv * this.grow));
        this.spd = (int)(speed * (1 + this.lv * this.grow));
        this.EXP = (int)(experience * (1 + this.lv * this.grow * 5));
    }
    private void CalculateFrame(int temp_frame){
        this.frame = (int)(Mathf.Exp(Mathf.Sqrt(this.spd + 12) / -5) * temp_frame * 2);
    }
}
