using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapController : MonoBehaviour
{
    public Transform t1;
    public Transform t2;
    public float speed = 100f;
    public float timer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>0)
        {
            timer -= Time.deltaTime;
            t1.position += new Vector3(t1.position.x, speed*Time.deltaTime, t1.position.z);
        }if(timer<0)
        {
            timer = 2f;
            speed = -speed;
        }
      //  t1.position += new Vector3(t1.position.x, Mathf.Sin(Time.deltaTime), t1.position.z);
        //t2.position += new Vector3(t2.position.x, Mathf.Sin(Time.deltaTime), t2.position.z);
    }
}
