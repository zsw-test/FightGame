using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioClip jumpAudio, hitAudio, startAudio, guidAudio, chooseAudio, fightAudio,buttonAudio,hurtAudio,skillAudio,walkAudio,energyAudio,deathAudio,defenceAudio,winAudio;
    public List<AudioClip> WalkAudio;

    AudioSource UIbuttonSource ;  //UI按键声音
    
    AudioSource Player1Source;   //玩家1声音
    AudioSource Player2Source;   //玩家2声音
    AudioSource SenceSource;     //场景背景音乐声音
    public float PlayerVolume = 1f;
    public float ButtonVolume = 1f;
    public float SenceVolume = 0.2f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }


        UIbuttonSource = gameObject.AddComponent<AudioSource>();
        Player1Source = gameObject.AddComponent<AudioSource>();
        Player2Source = gameObject.AddComponent<AudioSource>();
        SenceSource = gameObject.AddComponent<AudioSource>();
        SenceSource.volume = SenceVolume;
        UIbuttonSource.volume = ButtonVolume;
        Player1Source.volume = PlayerVolume;
        Player2Source.volume = PlayerVolume;
    }
    public void SetSenceVolume(float value)
    {
        SenceVolume = value;
        SenceSource.volume = value;
    }
    public void SetButtonVolume(float value)
    {
        ButtonVolume = value;
        UIbuttonSource.volume = value;
    }
    public void SetPlayerVolume(float value)
    {
        PlayerVolume = value;
        Player1Source.volume = value;
        Player2Source.volume = value;
    }

    private void Start()
    {
         StartAudio();
        //ButtonAudio();
    }
    public void Defence1Audio()              //玩家1跳跃音效
    {
        instance.Player1Source.loop = false;

        instance.Player1Source.clip = instance.defenceAudio;
        instance.Player1Source.Play();
    }
    public void Defence2Audio()              //玩家1跳跃音效
    {
        instance.Player2Source.loop = false;

        instance.Player2Source.clip = instance.defenceAudio;
        instance.Player2Source.Play();
    }
    public  void Jump1Audio()              //玩家1跳跃音效
    {
        instance.Player1Source.loop = false;

        instance.Player1Source.clip = instance.jumpAudio;
        instance.Player1Source.Play();
    }

    public  void Hit1Audio()               //玩家1攻击音效
    {
        instance.Player1Source.loop = false;
        instance.Player1Source.clip = instance.hitAudio;
        instance.Player1Source.Play();
    }
    public void Hit2Audio()               //玩家2攻击音效
    {
        instance.Player2Source.loop = false;
        instance.Player2Source.clip = instance.hitAudio;
        instance.Player2Source.Play();
    }
    public  void Jump2Audio()              //玩家2跳跃音效
    {
        instance.Player2Source.loop = false;
        instance.Player2Source.clip = instance.jumpAudio;
        instance.Player2Source.Play();
    }

    

    public  void StartAudio()
    {
       
        instance.SenceSource.clip = instance.startAudio;
        instance.SenceSource.loop = true;
        instance.SenceSource.Play();
    }

    public  void GuidAudio()
    {
       
        instance.SenceSource.clip = instance.guidAudio;
        instance.SenceSource.loop = true;
        instance.SenceSource.Play();
    }

    public  void ChooseAudio()
    {
       
        instance.SenceSource.clip = instance.chooseAudio;
        instance.SenceSource.loop = true;
        instance.SenceSource.Play();
    }

    public  void FightAudio()
    {
       
        instance.SenceSource.clip = instance.fightAudio;
        instance.SenceSource.loop = true;
        instance.SenceSource.Play();
    }
    public void WinAudio()
    {
        instance.SenceSource.clip = instance.winAudio;
        instance.SenceSource.loop = true;
        instance.SenceSource.Play();
    }
    public void ButtonAudio()
    {
        instance.UIbuttonSource.loop = false;
        instance.UIbuttonSource.clip = instance.buttonAudio;
        instance.UIbuttonSource.Play();
    }

    public  void Hurt1Audio()              //玩家1受伤音效
    {
        instance.Player1Source.loop = false;
        instance.Player1Source.clip = instance.hurtAudio;
        instance.Player1Source.Play();
    }

    public  void Hurt2Audio()              //玩家2受伤音效
    {
        instance.Player2Source.loop = false;
        instance.Player2Source.clip = instance.hurtAudio;
        instance.Player2Source.Play();
    }

    public  void Skill1Audio()
    {
        instance.Player1Source.loop = false;
        instance.Player1Source.clip = instance.skillAudio;
        instance.Player1Source.Play();
    }

    public  void Skill2Audio()
    {
        instance.Player2Source.loop = false;
        instance.Player2Source.clip = instance.skillAudio;
        instance.Player2Source.Play();
    }

    //public  void Walk1Audio()
    //{
    //    instance.Player1Source.clip = instance.walkAudio;
    //    instance.Player1Source.loop = false;
    //    instance.Player1Source.Play();
    //}

    //public  void Walk2Audio()
    //{
    //    instance.Player2Source.loop = false;
    //    instance.Player2Source.clip = instance.walkAudio;
    //    instance.Player2Source.Play();
    //}

    public  void Energy1Audio()
    {
        instance.Player2Source.loop = true;
        instance.Player1Source.clip = instance.energyAudio;
        instance.Player1Source.Play();
    }
    public void Energy2Audio()
    {
        instance.Player2Source.loop = false;
        instance.Player2Source.clip = instance.energyAudio;
        instance.Player2Source.Play();
    }
    public void Death1Audio()
    {
        instance.Player1Source.loop = false;
        instance.Player1Source.clip = instance.deathAudio;
        instance.Player1Source.Play();
    }
    public void Death2Audio()
    {
        instance.Player2Source.loop = false;
        instance.Player2Source.clip = instance.deathAudio;
        instance.Player2Source.Play();
    }
    int walk1index = 0;
    int walk2index = 0;
    public void Walk1Audio()
    {
        walk1index += 1;
        walk1index %= 4;
        instance.Player1Source.loop = false;
        instance.Player1Source.clip = instance.WalkAudio[walk1index];
        instance.Player1Source.Play();
    }
    public void Walk2Audio()
    {
        walk2index += 1;
        walk2index %= 4;
        instance.Player2Source.loop = false;
        instance.Player2Source.clip = instance.WalkAudio[walk2index];
        instance.Player2Source.Play();
    }
}
