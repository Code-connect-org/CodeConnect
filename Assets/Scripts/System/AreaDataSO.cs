using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AreaDataSO", menuName = "SO/AreaData", order = 1)]
public class AreaDataSO : ScriptableObject
{
    public List<AreaData> areaDatas = new List<AreaData>();
}

[System.Serializable]
public class AreaData
{
    [SerializeField] private int id;
    [SerializeField] private string Name;
    [SerializeField] private int lv;
    [SerializeField] private int[] enemy;
    [SerializeField] private int[] lv_min;
    [SerializeField] private int[] lv_max;
    [SerializeField] private string description;
}

// public class InitialAreaData : MonoBehaviour
// {
//     void start(){
//         Areas = new AreaData[]
//         {
//             new AreaData{
//                 id = 0,
//                 name = "Unknown",
//                 lv = 0,
//                 enemy = new int[] { 0 },
//                 description = "Unknown"
//             },
//             new AreaData{
//                 id = 1,
//                 name = "forest",
//                 lv = 1,
//                 enemy = new int[] { 1 },
//                 description = "Feels so good. BreeeeeEEEEEZE."
//             },
//             new AreaData{
//                 id = 2,
//                 name = "cave",
//                 lv = 3,
//                 enemy = new int[] { 1 },
//                 description = "Aren't you Scared? ...Boo! Huh, it looks bad..."
//             }
//         };
//     }
// }