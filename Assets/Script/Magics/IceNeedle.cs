using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceNeedle : MonoBehaviour
{
    public float explosionDistance = 0;
    public float speed;
    public float distanceTraveled;
    public GameObject explosionPrefab;

    // Update is called once per frame
    void Update()
    {
        if(explosionDistance > distanceTraveled){
            transform.Translate(0,speed*Time.deltaTime,0);
            distanceTraveled+=speed*Time.deltaTime;
        }else {
            Destroy(Instantiate(explosionPrefab,transform.position,Quaternion.identity),1);
            Destroy(gameObject);
        }
    }
}
