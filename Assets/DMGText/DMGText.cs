using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class DMGText : MonoBehaviour
{
    public Vector2 startPos;
    Vector2 maxPos;
    void Start()
    {
        startPos = transform.position;
        maxPos = startPos + new Vector2(Random.Range(-200,200),Random.Range(-200,200));
    }
    float t = 0;
    // Update is called once per frame
    void Update()
    {
        if(t < 0.5f)transform.position = QuartOut(t,0.5f,startPos,maxPos);
        if(t > 2)Destroy(gameObject);
        t += Time.deltaTime;
    }
    public static Vector2 QuartOut(float t, float totaltime, Vector2 min, Vector2 max)
    {
        max -= min;
        t = t / totaltime - 1;
        return -max * (t * t * t * t - 1) + min;
    }
    
}
