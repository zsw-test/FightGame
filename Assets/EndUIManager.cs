using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndUIManager : MonoBehaviour
{
    public Transform bg;
    public Transform text;
    public Vector3 myvalue;
    // Start is called before the first frame update
    void Start()
    {
        bg.transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f);
        text.transform.DOLocalMove(new Vector3(0, -100, 0), 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
