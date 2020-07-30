using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetech : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)  //如果是墙
        {
            gameObject.GetComponentInParent<PlayerController>().dashTimeLeft = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)  //如果是墙
        {
            gameObject.GetComponentInParent<PlayerController>().dashTimeLeft = 0;
        }
    }
}
