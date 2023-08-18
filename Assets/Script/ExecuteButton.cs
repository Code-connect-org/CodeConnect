using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExecuteButton : ButtonBaseEX
{
    private Image image;
    private Color normalIMGColor;
    private Color normalTexColor;
    public Color onHoverImageColor;
    public Color onHoverTextColor;
    public TextMeshProUGUI textMeshPro;
    public NodeManager nodeManager;
    public override void OnStart()
    {
        image = gameObject.GetComponent<Image>();
        normalIMGColor = image.color;
        normalTexColor = textMeshPro.color;
    }
    public override void OnPointerEnter(){
        image.color = onHoverImageColor;
        textMeshPro.color = onHoverTextColor;
    }
    public override void OnPointerExit()
    {
        image.color = normalIMGColor;
        textMeshPro.color = normalTexColor;
    }
    public override void OnClickDown()
    {
        StartCoroutine(nodeManager.Attack());
    }
}
