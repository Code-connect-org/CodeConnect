using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData
{
    public int id;
    public string name;
    public int[] area;      // 配列の宣言と要素数指定
    public int[] lv_min;    // 配列の宣言と要素数指定
    public int[] lv_max;    // 配列の宣言と要素数指定
    public string[] element; // 配列の宣言と要素数指定
    public float[] weakness = new float[4]; // 要素数を指定して配列を初期化
    public string[] effect; // 配列の宣言と要素数指定
    public float[] resist = new float[7];   // 要素数を指定して配列を初期化
    public float[] work = new float[6];     // 要素数を指定して配列を初期化
    public int hp;
    public int atk;
    public int def;
    public int spd;
    public int frame;
    public int EXP;
    public float grow;
    public string description;
}

public class InitialEnemyData : MonoBehaviour
{
    void start(){
        Enemies = new EnemyData[]
        {
            new EnemyData{
                id = 0,
                name = "Unknown",
                area = new int[] { 0 },
                lv_min = new int[] { 1 },
                lv_max = new int[] { 1 },
                element = new string[] { "none" },
                weakness = new float[] { 0, 0, 0, 0 },
                effect = new string[] { "none" },
                resist = new float[] { 0, 0, 0, 0, 0, 0, 0 },
                work = new float[] { 0, 0, 0, 0, 0, 0 },
                hp = 1,
                atk = 0,
                def = 0,
                spd = 0,
                frame = 1,
                EXP = 0,
                grow = 0,
                description = "Unknown."
            },

            new EnemyData{
                id = 1,
                name = "Slime",
                area = new int[] { 1, 2 },
                lv_min = new int[] { 1, 3 },
                lv_max = new int[] { 3, 5 },
                element = new string[] { "none" },
                weakness = new float[] { 2, 2, 2, 2 },
                effect = new string[] { "poison", "venom" },
                resist = new float[] { 0, 0, 1, 1, 0, 1, 0.3 },
                work = new float[] { 0, 0, 0.5, 1, 0, 1 },
                hp = 20,
                atk = 3,
                def = 5,
                spd = 5,
                frame = 60,
                EXP = 10,
                grow = 0.1,
                description = "The Slime. Sticky, and Weakest."
            }
        };
    }
}