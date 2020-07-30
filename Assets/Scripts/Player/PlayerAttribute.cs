using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour
{
    public int RunSpeed = 10;
    public int Blood = 300;        //血量
    public int CurrentBlood = 300;    //当前血量
    public int SkillGroove = 3;     //大招能量槽
    public float Energy = 3f;          //能量
    public float CurrentEnergy = 3;   //当前能量
    public int CurSkillGroove = 3;   //当前大招能量槽
    public int AttackDamage = 10;  //普攻伤害
    public int SkillDamage = 30;    //技能伤害
    public bool Breakout = false;    //是否爆气
    public int BreakoutTime = 15;   //爆气时间
    public float BreakoutAddition = 1.5f;   //爆气加成
    public float DefenceRate = 0.1f;        //物理防御  基础防御，可以减少一定的伤害 减免比例
    public bool Death = false;
    public bool Defence = false;
    public bool Win = false;

    public bool Dazzle, SpeedUp, SpeedDown;

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
    public int MySkillDamage()
    {
        int damage = Breakout ? (int)(SkillDamage * BreakoutAddition) : SkillDamage;
        Debug.Log(damage);
        return damage;
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

 
    public void AddBlood(Sprite sprite,int blood,int addtime)
    {
        StartCoroutine(addBlood(sprite, blood, addtime));
    }
    public void AddEnergy(Sprite sprite, int blood, int addtime)
    {
        StartCoroutine(addEnergy(sprite, blood, addtime));
    }
    public void AddSkillGroove(Sprite sprite, int blood, int addtime)
    {
        StartCoroutine(addSkillGroove(sprite, blood, addtime));
    }

    public void speedup(Sprite sprite, int addspeed,int addtime)
    {
        StartCoroutine(Speedup(sprite, addspeed, addtime));
    }
    public void speeddown(Sprite sprite,int addspeed,int addtime)
    {
        StartCoroutine(Speeddown(sprite,addspeed, addtime));
    }
    public void dazzle(Sprite sprite, int addtime)
    {
        StartCoroutine(IEdazzle(sprite,addtime));
    }
    public void BreakOut(Sprite sprite, int addtime)
    {
        StartCoroutine(breakOut(sprite, addtime));
    }
    IEnumerator breakOut(Sprite sprite,int addtime)
    {
        int atrindex = gameObject.GetComponent<PlayerUIController>().AtrCdAction(sprite, addtime);
        yield return new WaitForSeconds(addtime);
        gameObject.GetComponent<PlayerUIController>().AtrCdDone(atrindex);

    }
    IEnumerator addEnergy(Sprite sprite, int addnum, int addtime)
    {
        int atrindex = gameObject.GetComponent<PlayerUIController>().AtrCdAction(sprite, addtime);
        CurrentEnergy += addnum;
        if (CurrentEnergy > Energy) CurrentEnergy = Energy;
        yield return new WaitForSeconds(addtime);
        gameObject.GetComponent<PlayerUIController>().AtrCdDone(atrindex);

    }
    IEnumerator addBlood(Sprite sprite, int addnum, int addtime)
    {
        int atrindex = gameObject.GetComponent<PlayerUIController>().AtrCdAction(sprite, addtime);
        CurrentBlood += addnum;
        if (CurrentBlood > Blood) CurrentBlood = Blood;
        yield return new WaitForSeconds(addtime);
        gameObject.GetComponent<PlayerUIController>().AtrCdDone(atrindex);
    }
    IEnumerator addSkillGroove(Sprite sprite, int addnum, int addtime)
    {
        int atrindex = gameObject.GetComponent<PlayerUIController>().AtrCdAction(sprite, addtime);
        CurSkillGroove += addnum;
        if (CurSkillGroove > SkillGroove) CurSkillGroove = SkillGroove;
        yield return new WaitForSeconds(addtime);
        gameObject.GetComponent<PlayerUIController>().AtrCdDone(atrindex);
    }
    IEnumerator Speedup(Sprite sprite, int addspeed, int addtime)
    {
            int atrindex = gameObject.GetComponent<PlayerUIController>().AtrCdAction(sprite, addtime);
            SpeedUp = true;
            RunSpeed+=addspeed;
            yield return new WaitForSeconds(addtime);
            gameObject.GetComponent<PlayerUIController>().AtrCdDone(atrindex);
            SpeedUp = false;
            RunSpeed -= addspeed;
    }
    IEnumerator Speeddown(Sprite sprite,int addspeed, int addtime)
    {
            int index  = gameObject.GetComponent<PlayerUIController>().AtrCdAction(sprite, addtime);
            SpeedDown = true;
            RunSpeed += addspeed;
    
        yield return new WaitForSeconds(addtime);

        gameObject.GetComponent<PlayerUIController>().AtrCdDone(index);
            SpeedDown = false;
            RunSpeed -= addspeed;
    }
    IEnumerator IEdazzle(Sprite sprite, int addtime)
    {
        int index = gameObject.GetComponent<PlayerUIController>().AtrCdAction(sprite, addtime);
        Dazzle = true;
    
        yield return new WaitForSeconds(addtime);
       
        gameObject.GetComponent<PlayerUIController>().AtrCdDone(index);
        Dazzle = false;
    }
}

