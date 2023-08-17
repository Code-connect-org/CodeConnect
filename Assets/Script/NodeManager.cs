using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Timeline;

public class NodeManager : MonoBehaviour
{
    public List<NodeData> nodeDatas = new List<NodeData>();
    private List<Node> nodes = new List<Node>();
    public GameObject nodePrefab;
    public Animator plAnimator;
    // Start is called before the first frame update
    void Start()
    {
        InitializeNodes();
    }
    public void InitializeNodes(){
        for(int i =0;i < transform.childCount;i ++){
            Destroy(transform.GetChild(i).gameObject);
        }
        nodes = new List<Node>();
        for(int i = 0;i < nodeDatas.Count;i++){
            nodes.Add(Instantiate(nodePrefab,transform).GetComponent<Node>());
            nodes[i].nodeData = nodeDatas[i];
        }
    }
    public IEnumerator Attack(){
        InitializeNodes();
        foreach(Node node in nodes){
            plAnimator.Play(node.nodeData.name);
            Destroy(Instantiate((GameObject)Resources.Load(node.nodeData.name),plAnimator.transform.position,Quaternion.identity),node.nodeData.frame * 0.1f);
            yield return StartCoroutine(node.AttackStart());
        }
        yield break;
    }
}
[System.Serializable]
public class NodeData
{
    public string name;
    public string code;//内部のコードのフレーバー部分
    public int element;//0〜4の数値が入る
    public int power; //100で攻撃そのまま程度
    public int ap; //プレイヤーの基本値は100なので、20程度を想定
    public int frame;
    public int id;
    public int skill_id;//特殊効果枠
    public int heat;//オーバーヒートゲージの増加量
    public float fail;
}