﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightUIManager : MonoBehaviour
{
    float timer = 1f;
    public GameObject[] p1wincounts;
    public GameObject[] p2wincounts;
    public GameObject fader;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //if(m_alpha>0)
        //{
        //    m_alpha -= 0.5f*Time.deltaTime;
        //    timer -= 0.5f;
        //    Color cur = bg.color;

        //    cur.a = m_alpha;
        //    bg.color = cur;
        //}
           
       for(int i=0;i<SenceManager.instance.player1wincount;++i)
        {
            p1wincounts[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < SenceManager.instance.player2wincount; ++i)
        {
            p2wincounts[3-i-1].gameObject.SetActive(true);
        }
     

    }
}
