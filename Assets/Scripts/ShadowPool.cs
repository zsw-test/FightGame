using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;
    public int count;
    public GameObject Shadowpre;

    private Queue<GameObject>  shadowspool = new Queue<GameObject>();
    private void Awake()
    {
        instance = this;
        Fullfillpool();
    }
    public void Fullfillpool()
    {
        for(int i=0;i<count;i++)
        {
            var shadow = Instantiate(Shadowpre);
            shadowspool.Enqueue(shadow);
          shadow.transform.SetParent(transform);
            shadow.SetActive(false);
        }
    }
    public void inPool(GameObject shadow)
    {
        shadow.SetActive(false);
        shadowspool.Enqueue(shadow);
    }


    public GameObject outPool()
    {
        if(shadowspool.Count==0)
        {
            Fullfillpool();
        }
        GameObject shadow = shadowspool.Dequeue();
        shadow.SetActive(true);
        return shadow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
