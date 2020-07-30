using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDown : MonoBehaviour
{
    public int addSpeed = -3;
    public int addtime = 10;
    public Sprite sprite;
    public void Attach(GameObject player)
    {
        if (player.GetComponent<PlayerAttribute>().SpeedDown == false)
        {
            player.GetComponent<PlayerAttribute>().speeddown(sprite, addSpeed, addtime);
            Destroy(gameObject);
        }
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
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Attach(collision.gameObject);
        }

    }
}
