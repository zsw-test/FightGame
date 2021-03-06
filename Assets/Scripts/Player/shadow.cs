﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow : MonoBehaviour
{
    private SpriteRenderer thisSprite;

    [Header("残影显示参数")]
    public float displayTime;
    public float alpha;
    public float Multiple;
    public float startTime;




    private void OnEnable()
    {
        if(!ShadowPool.instance.playertag.Equals(""))
        {
            thisSprite = GetComponent<SpriteRenderer>();
            GameObject player = GameObject.FindGameObjectWithTag(ShadowPool.instance.playertag);
            thisSprite.sprite = player.GetComponent<SpriteRenderer>().sprite;
            alpha = 1;
            thisSprite.flipX = true;
            transform.position = player.transform.position;
            transform.localScale = player.transform.localScale;
            transform.rotation = player.transform.rotation;
            startTime = Time.time;
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime + displayTime)
        {
            ShadowPool.instance.inPool(gameObject);//显示时间超过了  重新加入到对象池队列中
        }
        else
        {
            alpha *= Multiple;
            thisSprite.color = new Color(0.5f, 0.5f, 1, alpha);
        }

        
    }
}
