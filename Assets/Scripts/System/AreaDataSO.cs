using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "AreaDataSO", menuName = "SO/AreaData", order = 1)]
public class AreaDataSO : ScriptableObject
{
    public List<AreaData> areaDatas = new List<AreaData>();
    public List<AreaData> GetSortedDatas()
    {
        // 各AreaDataオブジェクトに対してMatchListLengthメソッドを呼び出す
        foreach (var areaData in areaDatas)
        {
            areaData.MatchListLength();
        }

        // LINQを使用してEnemyDataの配列をidで昇順にソート
        List<AreaData> sortedList = areaDatas.OrderBy(data => data.id).ToList();
        return sortedList;
    }
}

[System.Serializable]
public class AreaData
{
    [SerializeField] public int id;
    [SerializeField] public string Name;
    [SerializeField] public int lv;
    [SerializeField] public List<int> enemy;
    [SerializeField] public List<int> lv_min;
    [SerializeField] public List<int> lv_max;
    [SerializeField] public string description;

    public void MatchListLength()
    {
        int maxLength = Mathf.Max(enemy.Count, lv_min.Count, lv_max.Count);
        while (enemy.Count < maxLength) enemy.Add(0);
        while (lv_min.Count < maxLength) lv_min.Add(0);
        while (lv_max.Count < maxLength) lv_max.Add(0);
    }
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