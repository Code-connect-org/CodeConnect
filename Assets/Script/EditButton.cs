using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditButton : ButtonBaseEX
{
    public GameObject NodeEditBox;
    public NodeManager nodeManager;
    public override void OnClickDown()
    {
        nodeManager.nodeDatas = new List<NodeData>();
        nodeManager.InitializeNodes();
        NodeEditBox.SetActive(true);
    }
}
