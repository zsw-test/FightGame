using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyManager : MonoBehaviour
{
    public GameObject[] properties;
    public Transform[] swapoints;
  
    public Dictionary<Transform, bool> isswap = new Dictionary<Transform, bool>();
    public float swaptime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var e in swapoints)
        {
            isswap.Add(e, false);
        }
        
        for(int i=0;i<swapoints.Length;++i)
        {
            
            int randomindex = Random.Range(0, properties.Length);
            swap(swapoints[i], properties[randomindex]);
            isswap[swapoints[i]] = false;
        }
    }

    public void swap(Transform t,GameObject property)
    {

        Instantiate(property, t.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
