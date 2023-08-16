using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceNeedleController : MonoBehaviour
{
    public GameObject iceNeedle;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.2f);
        iceNeedle.SetActive(true);
        yield break;
    }
}
