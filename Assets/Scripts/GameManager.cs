using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public Text StartText;
    public Text FightText;
    public int StartTimer = 4;
    public int FightTimer = 60;
    private float timertick = 1;
    public bool Startcountdown=false;//开始倒计时
    public bool Fightcountdown = false;
    public bool EndRound = false; //这一句是否结束
    public bool EndRoundExecute = false; //结束判断是否执行过
    public GameObject player1;
    public GameObject player2;
    public int winround = 2; //胜利的局数
    public GameObject result;
    public Transform SwapPoint1;
    public Transform SwapPoint2;
    public int player1wincount=0;
    public int player2wincount=0;

    // Start is called before the first frame update
    void Start()
    {
        StartText.enabled = false;
        var total = SenceManager.instance.player1wincount + 1 + SenceManager.instance.player2wincount;
        string RoundName = "第" + total + "局";
        StartText.text = RoundName.ToString();

        Instantiate(player1, SwapPoint1);
        Instantiate(player2, SwapPoint2);
      
    }
    private void Awake()
    {
        
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(SwapPoint2.GetComponentInChildren<PlayerAttribute>().CurrentBlood );
        if(Startcountdown)
        {
            StartCountDown();
        }
        
        if(Fightcountdown)
        {
            FightCountDown();
        }
        if(SwapPoint1.GetComponentInChildren<PlayerAttribute>().CurrentBlood<=0|| SwapPoint2.GetComponentInChildren<PlayerAttribute>().CurrentBlood <= 0)
        {
            EndRound = true;
        }
        if(EndRound&&!EndRoundExecute)
        {
            EndRoundExecute = true;
            if (SwapPoint1.GetComponentInChildren<PlayerAttribute>().CurrentBlood > SwapPoint2.GetComponentInChildren<PlayerAttribute>().CurrentBlood)
            {
                //player1显示胜利  进入下一句
                //player1胜利局数++
               
                SenceManager.instance.player1wincount++;
                
                //playershow and reload sence
                
                if (SenceManager.instance.player1wincount == SenceManager.instance.wincount)
                {
                    Debug.Log("111");
                    //跳转到胜利场景
                    result.SetActive(true);
                    //SenceManager.instance.clear();
                   
                }
                else
                {
                    SenceManager.instance.ChangeSence(2);
                }
                
            }
            else if(SwapPoint1.GetComponentInChildren<PlayerAttribute>().CurrentBlood < SwapPoint2.GetComponentInChildren<PlayerAttribute>().CurrentBlood)
            {
                //player2胜利局数++
                SenceManager.instance.player2wincount++;
                
                //playershow and reload sence
                //result.SetActive(true);
                if (SenceManager.instance.player2wincount == SenceManager.instance.wincount)
                {
                    result.SetActive(true);
                    // SenceManager.instance.clear();
                    
                }
                else
                {
                    SenceManager.instance.ChangeSence(2);
                 
                }
               
            }
            else
            {
                SenceManager.instance.ChangeSence(2);
                
            }
        }

        
    }
  
    //开始倒计时
   public void StartCountDown()
    {
        
        if (StartTimer > 0)
        {
            
            timertick -= Time.deltaTime;
            if(timertick<=0)
            {
                timertick = 1;
                StartTimer--;
                StartText.text = StartTimer.ToString();
            }
        }else
        {
            StartText.text = "FIght!";
            timertick -= Time.deltaTime;
            if(timertick<=0)
            {
                StartText.enabled = false;
                Startcountdown = false;
                //战斗倒计时
                Fightcountdown = true;
            }
           
           
        }
    }
    //战斗倒计时
    public void FightCountDown()
    {
        if (FightTimer > 0)
        {

            timertick -= Time.deltaTime;
            if (timertick <= 0)
            {
                timertick = 1;
                FightTimer--;
                FightText.text = FightTimer.ToString();
            }
        }
        else
        {
            Fightcountdown = false;
            //判断胜利方
            EndRound = true;
            
        }
    }


    public void RoundEnd()
    {
        

    }

    internal void WhoWin()
    {
        throw new NotImplementedException();
    }
}
