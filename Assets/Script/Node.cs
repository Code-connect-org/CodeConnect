using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Node : MonoBehaviour
{
    public NodeData nodeData;
    [SerializeField]private TextMeshProUGUI text;
    [SerializeField]private TextMeshProUGUI subText;
    void Start()
    {
        text.text = nodeData.name;
        subText.text = nodeData.fail.ToString() + "%";
    }

    public IEnumerator AttackStart(){
        RectTransform rectTrf = gameObject.GetComponent<RectTransform>();
        text.color = Color.white;
        text.outlineWidth = 0;
        for(float t = 0;t <= 0.25f;t += Time.deltaTime){
            rectTrf.localScale = Vector3.one * (t * 0.8f + 1.0f);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f * nodeData.frame-0.25f);
        text.color = new Color(0.1f,0.1f,0.1f);
        text.outlineWidth = 1;
        for(float t = 0;t <= 0.25f;t += Time.deltaTime){
            rectTrf.localScale = Vector3.one * (t * -0.8f + 1.2f);
            yield return null;
        }
        yield break;
    }
    public IEnumerator AttackFail(){
        RectTransform rectTrf = gameObject.GetComponent<RectTransform>();
        text.color = Color.red;
        text.outlineWidth = 0;
        for(float t = 0;t <= 0.25f;t += Time.deltaTime){
            rectTrf.localScale = Vector3.one * (t * 0.8f + 1.0f);
            yield return null;
        }
        yield return new WaitForSeconds(0.1f * nodeData.frame-0.25f);
        text.color = new Color(0.1f,0.1f,0.1f);
        text.outlineWidth = 1;
        for(float t = 0;t <= 0.25f;t += Time.deltaTime){
            rectTrf.localScale = Vector3.one * (t * -0.8f + 1.2f);
            yield return null;
        }
        yield break;
    }
}

