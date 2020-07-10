using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContiuneTickScript : MonoBehaviour
{
    public Text TickText;
    public float Timer=0.8f;
    public float preHurtTime = 0f;
    public int TickNum = 0;
    // Start is called before the first frame update
    void Awake()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
       if(Time.time-preHurtTime>Timer)
        {
            TickNum=0;
            TickText.enabled = false;
           
        }
    }
    
    public void ContinueTick()
    {
            TickNum++;
        
        TickText.text = TickNum + "连击";
            TickText.enabled = true;
            preHurtTime = Time.time;
    }
}
