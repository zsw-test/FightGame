using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CameraController cameracontroller;

    public Slider Player1Health;
    public Slider Player1Magic;
    public Slider Player2Health;
    public Slider Player2Magic;
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
    
    public GameObject result;
    public Transform SwapPoint1;
    public Transform SwapPoint2;

    //局数的控制交给SenceManager  因为 这个gamemanager已经和场景里的物体关联了  
    //public int WinCount = 2; //胜利的局数
    //public int player1wincount=0;
    //public int player2wincount=0;

    // Start is called before the first frame update
    void Start()
    {
        cameracontroller =GameObject.Find("Camera").GetComponent<CameraController>();
        StartText.enabled = false;
        var total = SenceManager.instance.player1wincount + 1 + SenceManager.instance.player2wincount;
        string RoundName = "第" + total + "局";
        StartText.text = RoundName.ToString();

        

        Instantiate(player1, SwapPoint1);
        Instantiate(player2, SwapPoint2);
        //设置角色不能移动
        //SwapPoint1.GetComponentInChildren<Player01Controller>().moveable = false;
        //SwapPoint2.GetComponentInChildren<Player02Controller>().moveable = false;


    }
    private void Awake()
    {

        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerAttrUI();
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
                    cameracontroller.Winner = "P1";
                    //winner里面会控制场景跳转
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
                    cameracontroller.Winner = "P2";
                    //winner里面会控制场景跳转
                }
               
            }
            else
            {
                SenceManager.instance.ChangeSence(3);
                
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
            //然后角色可以移动了
        
            SwapPoint1.GetComponentInChildren<Player01Controller>().moveable = true;
            SwapPoint2.GetComponentInChildren<Player02Controller>().moveable = true;

            if (timertick<=0)
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
    public void UpdatePlayerAttrUI()
    {
        Player1Health.value = (float)SwapPoint1.GetComponentInChildren<PlayerAttribute>().CurrentBlood / SwapPoint1.GetComponentInChildren<PlayerAttribute>().Blood;
        Player2Health.value = (float)SwapPoint2.GetComponentInChildren<PlayerAttribute>().CurrentBlood / SwapPoint2.GetComponentInChildren<PlayerAttribute>().Blood;
        Player1Magic.value = (float)SwapPoint1.GetComponentInChildren<PlayerAttribute>().CurrentEnergy / SwapPoint1.GetComponentInChildren<PlayerAttribute>().Energy;
        Player2Magic.value = (float)SwapPoint2.GetComponentInChildren<PlayerAttribute>().CurrentEnergy / SwapPoint2.GetComponentInChildren<PlayerAttribute>().Energy;


    }

    public void RoundEnd()
    {
        

    }

    internal void WhoWin()
    {
        throw new NotImplementedException();
    }
}
