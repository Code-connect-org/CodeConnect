using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class PostProcessingTest : AssetPostprocessor
{
  static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
  {
    foreach (string str in importedAssets)
    {
      if (str.IndexOf("/EnemyData.csv") != -1)
      {
        Debug.Log("Enemy CSV File has detected.");

        // Assetのフォルダ内での相対パスを取得
        string relativePath = "Assets" + str.Replace(Application.dataPath, "");

        // ScriptableObjectのアセットを作成
        string assetfile = relativePath.Replace(".csv", ".asset");
        EnemyDataSO cd = AssetDatabase.LoadAssetAtPath<EnemyDataSO>(assetfile);
        if (cd == null)
        {
            cd = ScriptableObject.CreateInstance<EnemyDataSO>();
            AssetDatabase.CreateAsset(cd, assetfile);
        }

        // CSVデータをデシリアライズして設定
        TextAsset textasset = AssetDatabase.LoadAssetAtPath<TextAsset>(relativePath);
        cd.enemyDatas = new List<EnemyData>(CSVSerializer.Deserialize<EnemyData>(textasset.text));

        // アセットを保存
        EditorUtility.SetDirty(cd);
        AssetDatabase.SaveAssets();
      }
      else if (str.IndexOf("/AreaData.csv") != -1)
      {
        Debug.Log("Area CSV File has detected.");

        // Assetのフォルダ内での相対パスを取得
        string relativePath = "Assets" + str.Replace(Application.dataPath, "");

        // ScriptableObjectのアセットを作成
        string assetfile = relativePath.Replace(".csv", ".asset");
        AreaDataSO cd = AssetDatabase.LoadAssetAtPath<AreaDataSO>(assetfile);
        if (cd == null)
        {
            cd = ScriptableObject.CreateInstance<AreaDataSO>();
            AssetDatabase.CreateAsset(cd, assetfile);
        }

        // CSVデータをデシリアライズして設定
        TextAsset textasset = AssetDatabase.LoadAssetAtPath<TextAsset>(relativePath);
        cd.areaDatas = new List<AreaData>(CSVSerializer.Deserialize<AreaData>(textasset.text));

        // アセットを保存
        EditorUtility.SetDirty(cd);
        AssetDatabase.SaveAssets();
      }
    }
  }
}
#endif