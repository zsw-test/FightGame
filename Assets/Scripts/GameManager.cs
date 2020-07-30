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
    public GameObject fader;

    public Text StartText;
    public Text FightText;
    public int StartTimer = 4;
    public int FightTimer = 60;
    private float timertick = 1;
    public bool Startcountdown=false;//开始倒计时
    public bool Fightcountdown = false;
    public bool EndRound = false; //这一句是否结束
    public bool EndRoundExecute = false; //结束判断是否执行过
    public bool GameEnd = false;
    public GameObject player1;
    public GameObject player2;
    public GameObject[] players;
    public GameObject result;
    private string playerPath = "";
    public Transform SwapPoint1;
    public Transform SwapPoint2;
    public GameObject p1Obstacle;
    public GameObject p2Obstacle;

    //局数的控制交给SenceManager  因为 这个gamemanager已经和场景里的物体关联了  
    //public int WinCount = 2; //胜利的局数
    //public int player1wincount=0;
    //public int player2wincount=0;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        if (SenceManager.instance.Rountime.Equals("∞"))
            FightText.text = "∞";
        else  FightTimer = int.Parse(SenceManager.instance.Rountime);
        

        cameracontroller =GameObject.Find("Camera").GetComponent<CameraController>();
        StartText.enabled = false;
        var total = SenceManager.instance.player1wincount + 1 + SenceManager.instance.player2wincount;
        string RoundName = "第" + total + "局";
        StartText.text = RoundName.ToString();
        GameObject p1 = Resources.Load(playerPath + SenceManager.instance.player1name, typeof(GameObject)) as GameObject;
        GameObject p2 = Resources.Load(playerPath + SenceManager.instance.player2name, typeof(GameObject))as GameObject;
        Debug.Log(playerPath + SenceManager.instance.player1name);
        Debug.Log(p1.name);
        Instantiate(p1, SwapPoint1);
        Instantiate(p2, SwapPoint2);
        //设置角色不能进行攻击
        SwapPoint1.GetComponentInChildren<PlayerController>().attackable = false;
        SwapPoint2.GetComponentInChildren<PlayerController>().attackable = false;
        SwapPoint1.GetComponentInChildren<PlayerController>().moveable = false;
        SwapPoint2.GetComponentInChildren<PlayerController>().moveable = false;

    }


    // Update is called once per frame
    void Update()
    {
  
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
                SwapPoint1.GetComponentInChildren<PlayerAttribute>().Win = true;
                //playershow and reload sence

                if (SenceManager.instance.player1wincount == SenceManager.instance.wincount)
                {

                    //跳转到胜利场景
                    GameEnd = true;
                    SenceManager.instance.winnerName = SenceManager.instance.player1name.Replace("P1", "");
                    
                    cameracontroller.Winner = "P1";
                    
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
                SwapPoint2.GetComponentInChildren<PlayerAttribute>().Win = true;
                //playershow and reload sence
                //result.SetActive(true);
                if (SenceManager.instance.player2wincount == SenceManager.instance.wincount)
                {
                    GameEnd = true;
                    SenceManager.instance.winnerName = SenceManager.instance.player2name.Replace("P2", "");
                    cameracontroller.Winner = "P2";
                    
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
                SenceManager.instance.ChangeSence(SenceManager.instance.FightSence);
                
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

            //或者设置障碍物不让角色移动  现在可以将障碍物移除
            p1Obstacle.SetActive(false);
            p2Obstacle.SetActive(false);
            //然后角色可以移动了


            SwapPoint1.GetComponentInChildren<PlayerController>().attackable = true;
            SwapPoint2.GetComponentInChildren<PlayerController>().attackable = true;
            SwapPoint1.GetComponentInChildren<PlayerController>().moveable = true;
            SwapPoint2.GetComponentInChildren<PlayerController>().moveable = true;
            if (timertick<=0)
            {
                StartText.enabled = false;
                Startcountdown = false;
                //战斗倒计时
                if(!SenceManager.instance.Rountime.Equals("∞")) //如果 是无穷时间就不用战斗倒计时了
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
