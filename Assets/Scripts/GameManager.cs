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
    public int StartTimer = 3;
    public int FightTimer = 60;
    private float timertick = 1;
    public bool Startcountdown=false;//开始倒计时
    public bool Fightcountdown = false;

    // Start is called before the first frame update
    void Start()
    {
        StartText.enabled = false;
    }
    private void Awake()
    {
       
        instance = this;
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
        
        
    }
  
    //开始倒计时
   public void StartCountDown()
    {
       if(StartTimer > 0)
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
            StartText.text = "开始";
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
        
        }
    }

}
