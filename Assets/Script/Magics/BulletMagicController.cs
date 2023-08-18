using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMagicController : MonoBehaviour
{
    public GameObject iceNeedle;
    public float delay;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        iceNeedle.SetActive(true);
        yield break;
    }
}
