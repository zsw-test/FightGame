using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player1;
    public GameObject player2;
    public Text text;
    public int timer = 3;
    private float timertick = 1;
    public bool CountDown=false;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        text.enabled = false;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(CountDown)
        {
            StartCountDown();
            text.enabled = true;
        }
        
        
    }
  
   public void StartCountDown()
    {
       if(timer>0)
        {
            
            timertick -= Time.deltaTime;
            if(timertick<=0)
            {
                timertick = 1;
                timer--;
                text.text = timer.ToString();
            }
        }else
        {
            text.text = "开始";
            timertick -= Time.deltaTime;
            if(timertick<=0)
            {
                text.enabled = false;
            }
        }
    }

}
