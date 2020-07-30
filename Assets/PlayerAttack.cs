using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D attackperson)
    {
       
            if (attackperson.tag == "Player2" || attackperson.tag == "Player1")
            {
                attackperson.GetComponent<PlayerAttribute>().GetHurt(gameObject.GetComponentInParent<PlayerAttribute>().MyAttackDamage());
                Debug.Log(attackperson.tag);
                //如果处于防御状态  触发攻击护盾特效
                if (attackperson.GetComponent<PlayerAttribute>().Defence) attackperson.GetComponent<PlayerController>().ishurtShiled = true;
                else attackperson.GetComponent<PlayerController>().ishurt = true;
            }
        
    }
}
