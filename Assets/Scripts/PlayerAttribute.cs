using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    public int Blood = 200;        //血量
    public int Energy = 3;          //能量
    public int CurrentBlood = 200;    //当前血量
    public int CurrentEnergy = 3;   //当前能量
    public int AttackDamage = 10;  //普攻伤害
    public int SkillDamage = 50;    //技能伤害
    public bool Breakout = false;    //是否爆气
    public int BreakoutTime = 15;   //爆气时间
    public float BreakoutAddition = 1.5f;   //爆气加成
    public float DefenceRate = 0.9f;        //物理防御  基础防御，可以减少一定的伤害


    void Attack1(GameObject player)         //普通攻击
    {
        int damage = Breakout ? AttackDamage:(int)(AttackDamage+AttackDamage*BreakoutAddition);
        Debug.Log("damage:" + damage);
        player.GetComponent<PlayerAttribute>().GetHurt(damage);
    }
    void Skill1()       //技能攻击1
    {

    }

    public void GetHurt(int damage)
    {
        bool defence;
        //扣血

        CurrentBlood -= damage;
        if (damage < 0)
        {
            CurrentBlood = 0;
            //游戏结束-----
            
        }


    }


}

