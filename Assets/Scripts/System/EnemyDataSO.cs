using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "SO/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    public List<EnemyData> enemyDatas = new List<EnemyData>();
}

[System.Serializable]
    public class EnemyData
    {
        [SerializeField] public int id;
        [SerializeField] public string Name;
        [SerializeField] public bool[] element = new bool[4];
        [SerializeField] public float[] weakness = new float[4];
        [SerializeField] public bool[] effect = new bool[7];
        [SerializeField] public float[] resist = new float[7];
        [SerializeField] public float[] work = new float[6];
        [SerializeField] public int hp;
        [SerializeField] public int atk;
        [SerializeField] public int def;
        [SerializeField] public int spd;
        [SerializeField] public int frame;
        [SerializeField] public int EXP;
        [SerializeField] public float grow;
        [SerializeField] public string description;
    }


// public class InitialEnemyData : MonoBehaviour
// {
//     void Start(){
//         Enemies = new EnemyData[]
//         {
//             new EnemyData{
//                 id = 0,
//                 name = "Unknown",
//                 area = new int[] { 0 },
//                 lv_min = new int[] { 1 },
//                 lv_max = new int[] { 1 },
//                 element = new string[] { "none" },
//                 weakness = new float[] { 0, 0, 0, 0 },
//                 effect = new string[] { "none" },
//                 resist = new float[] { 0, 0, 0, 0, 0, 0, 0 },
//                 work = new float[] { 0, 0, 0, 0, 0, 0 },
//                 hp = 1,
//                 atk = 0,
//                 def = 0,
//                 spd = 0,
//                 frame = 1,
//                 EXP = 0,
//                 grow = 0,
//                 description = "Unknown."
//             },

//             new EnemyData{
//                 id = 1,
//                 name = "Slime",
//                 area = new int[] { 1, 2 },
//                 lv_min = new int[] { 1, 3 },
//                 lv_max = new int[] { 3, 5 },
//                 element = new string[] { "none" },
//                 weakness = new float[] { 2, 2, 2, 2 },
//                 effect = new string[] { "poison", "venom" },
//                 resist = new float[] { 0, 0, 1, 1, 0, 1, 0.3f },
//                 work = new float[] { 0, 0, 0.5f, 1, 0, 1 },
//                 hp = 20,
//                 atk = 3,
//                 def = 5,
//                 spd = 5,
//                 frame = 60,
//                 EXP = 10,
//                 grow = 0.1f,
//                 description = "The Slime. Sticky, and Weakest."
//             }
//         };
//     }
// }