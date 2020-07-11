using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class GuideSenceScript : MonoBehaviour
{
    public Text text;
    float minalpha = 0.5f;
    float cur=1f;
    int fate = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            SenceManager.instance.ChangeSence(3);
            SoundManager.instance.FightAudio();
        }
        
        //颜色渐变
        cur += (fate)*Time.deltaTime;
        text.color = new Color(text.color.r, text.color.g, text.color.b, cur);
        if(cur< minalpha)
        {
            fate = 1;
        }
        if(cur>=1)
        {
            fate = -1;
        }
        
        
        
    }
}
