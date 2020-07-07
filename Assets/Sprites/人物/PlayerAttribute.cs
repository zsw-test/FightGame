using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    public int Blood = 200;        //血量
    public float Energy = 3f;          //能量
    public int CurrentBlood = 200;    //当前血量
    public float CurrentEnergy = 3;   //当前能量
    public int AttackDamage = 10;  //普攻伤害
    public int SkillDamage = 50;    //技能伤害
    public bool Breakout = false;    //是否爆气
    public int BreakoutTime = 15;   //爆气时间
    public float BreakoutAddition = 1.5f;   //爆气加成
    public float DefenceRate = 0.1f;        //物理防御  基础防御，可以减少一定的伤害 减免比例
    public bool Death = false;
    public bool Defence = false;
    

    //void Attack1(GameObject player)         //普通攻击
    //{
        
    //    Debug.Log("damage:" + damage);
    //    player.GetComponent<PlayerAttribute>().GetHurt(damage);
    //}
    public int MyAttackDamage()
    {
        int damage = Breakout ? (int)(AttackDamage * BreakoutAddition) :AttackDamage;
        Debug.Log(damage);
        return damage;
    }
    void Skill1()       //技能攻击1
    {

    }

    public void GetHurt(int damage)
    {

        //防御减免扣血
        damage = Defence ? (int)(damage * DefenceRate) :damage;
        CurrentBlood -= damage;
        AscentEnerge(damage * 0.02f);
        if (CurrentBlood <= 0)
        {
            CurrentBlood = 0;
            //游戏结束-----
            Death = true;
        }
    }

    public void AscentEnerge(float energe)
    {
        CurrentEnergy += energe;
        if (CurrentEnergy >= 3f)
            CurrentEnergy = 3f;
    }
}

