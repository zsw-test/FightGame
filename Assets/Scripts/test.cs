using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Transform sw1;
    public Transform sw2;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject p1 = Resources.Load("苏利耶P1", typeof(GameObject)) as GameObject;
        GameObject p2 = Resources.Load("苏利耶P2", typeof(GameObject)) as GameObject;
        Instantiate(p1, sw1);
        Instantiate(p2, sw2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
