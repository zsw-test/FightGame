using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void JumpAudio()
    {
        if (gameObject.tag.Equals("Player1"))
        {
            SoundManager.instance.Jump1Audio();
        }
        else if (gameObject.tag.Equals("Player2"))
        {
            SoundManager.instance.Jump2Audio();
        }
    }
    public void HitAudio()
    {
        if(gameObject.tag.Equals("Player1"))
        {
            SoundManager.instance.Hit1Audio();
        }
        else if( gameObject.tag.Equals("Player2"))
        {
            SoundManager.instance.Hit2Audio();
        }
    }
    public void SkillAudio()
    {
        if (gameObject.tag.Equals("Player1"))
        {
            SoundManager.instance.Skill1Audio();
        }
        else if (gameObject.tag.Equals("Player2"))
        {
            SoundManager.instance.Skill2Audio();
        }
    }
    public void WaklAudio()
    {
        if (gameObject.tag.Equals("Player1"))
        {
            SoundManager.instance.Walk1Audio();
        }
        else if (gameObject.tag.Equals("Player2"))
        {
            SoundManager.instance.Walk2Audio();
        }
    }
    public void HurtAudio()
    {
        if (gameObject.tag.Equals("Player1"))
        {
            SoundManager.instance.Hurt1Audio();
        }
        else if (gameObject.tag.Equals("Player2"))
        {
            SoundManager.instance.Hurt2Audio();
        }
    }
   
}
