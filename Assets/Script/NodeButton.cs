using TMPro;
using UnityEngine;

public class NodeButton : ButtonBaseEX {
    public NodeManager nodeManager;
    public NodeData nodeData;
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI subText;
    public override void OnStart() {
        mainText.text = nodeData.name;
        subText.text = nodeData.fail + "%";
    }
    public override void OnClickDown()
    {
        nodeManager.nodeDatas.Add(nodeData);
        nodeManager.InitializeNodes();
    }
}