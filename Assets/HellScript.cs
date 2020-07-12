using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellScript : MonoBehaviour
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
        if(collision.tag=="Player1")
        {
            collision.GetComponent<PlayerAttribute>().CurrentBlood = 0;
        }
        if (collision.tag == "Player2")
        {
            collision.GetComponent<PlayerAttribute>().CurrentBlood = 0;
        }
    }
}
