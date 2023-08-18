using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : ButtonBaseEX
{
    public GameObject NodeEditBox;
    public override void OnClickDown()
    {
        NodeEditBox.SetActive(false);
    }
}
