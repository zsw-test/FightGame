using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private float speed = 0.2f;
    private  float timer = 5f;
    Transform[] CloudsTransform;
    // Start is called before the first frame update
    void Start()
    {
        CloudsTransform = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveClouds();
    }
   public void MoveClouds()
    {
        if(timer>0)
        {
            timer -= Time.deltaTime;
          
            foreach (var t in CloudsTransform)
            {
                t.position = new Vector3(t.position.x + speed * Time.deltaTime, t.position.y, t.position.z);
            }
            if (timer <= 0)
            {
                timer = 5f;
                speed = -speed;
            }
        }
        
        
    }
}
