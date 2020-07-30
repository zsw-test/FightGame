using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlood : MonoBehaviour,BaseProperty
{
    public int addblood = 50;
    public int addtime = 1;
    public Sprite sprite;
    public void Attach(GameObject player)
    {
        player.GetComponent<PlayerAttribute>().AddBlood(sprite, addblood, addtime);
        Destroy(gameObject);
    }

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
        if(collision.gameObject.tag=="Player1"|| collision.gameObject.tag == "Player2")
        {
            Attach(collision.gameObject);
        }

    }
}
