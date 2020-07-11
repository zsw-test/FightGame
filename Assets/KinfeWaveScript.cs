using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinfeWaveScript : MonoBehaviour
{
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-transform.localScale.x,0)* speed *Time.deltaTime);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("???");
        if(collision.tag.Equals("Player1"))
        {
            collision.GetComponent<PlayerAttribute>().GetHurt(GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerAttribute>().MySkillDamage()); ;
            Debug.Log(collision.tag);
            collision.GetComponent<Player01Controller>().ishurt = true;
            Destroy(gameObject);
        }
        else if(collision.tag.Equals("Player2"))
        {
            collision.GetComponent<PlayerAttribute>().GetHurt(GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerAttribute>().MySkillDamage());
            Debug.Log(collision.tag);
            collision.GetComponent<Player02Controller>().ishurt = true;
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
