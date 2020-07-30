using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class StartUIManager : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject explainMenu;
    public GameObject[] curs;
    int curindex = 0;
    public Slider s1;
    public Slider s2;
    public Slider s3;
    public Toggle t1;
    public Toggle t2;
    public Toggle t3;
    public Toggle t4;
    // Start is called before the first frame update
    void Start()
    {
        optionMenuHide();
        s1.onValueChanged.AddListener(SetSenceVolume);
        s2.onValueChanged.AddListener(SetButtonVolume);
        s3.onValueChanged.AddListener(SetPlayerVolume);
        t1.onValueChanged.AddListener(muteSence);
        t2.onValueChanged.AddListener(muteButton);
        t3.onValueChanged.AddListener(mutePlayer);
        t4.onValueChanged.AddListener(muteAll);
    }

    public void UIbuttonOnStart(Transform transform)
    {
        transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.3f);
    }
    public void UIbuttonOnExit(Transform transform)
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            UIbuttonOnExit(curs[curindex].transform);
            curindex--;
            if (curindex < 0) curindex = curs.Length - 1;
            UIbuttonOnStart(curs[curindex].transform);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            UIbuttonOnExit(curs[curindex].transform);
            curindex++;
            curindex %= curs.Length;
            UIbuttonOnStart(curs[curindex].transform);

        }
     
    }
    public void explainMenuShow()
    {
        explainMenu.gameObject.transform.DOLocalMoveY(0, 0.3f);
    }
    public void explainMenuHide()
    {
        explainMenu.gameObject.transform.DOLocalMoveY(1000, 0.3f);
    }
    public void optionMenuShow()
    {
        optionMenu.gameObject.transform.DOLocalMoveX(0, 0.3f);
    }
    public void optionMenuHide()
    {
        optionMenu.gameObject.transform.DOLocalMoveX(1000, 0.3f);
    }
    public void SetSenceVolume(float arg0)
    {
        SoundManager.instance.SetSenceVolume(s1.value);
    }
    public void SetButtonVolume(float arg0)
    {
        SoundManager.instance.SetButtonVolume(s2.value);
    }
    public void SetPlayerVolume(float arg0)
    {
        SoundManager.instance.SetPlayerVolume(s3.value);
    }
    public void muteSence(bool arg)
    {
        if(arg)
        SoundManager.instance.SetSenceVolume(0);
        else
        {
         SoundManager.instance.SetSenceVolume(s1.value);
        }
    }
    public void muteButton(bool arg)
    {
        if(arg)
        SoundManager.instance.SetButtonVolume(0);
        else
        {
            SoundManager.instance.SetButtonVolume(s1.value);
        }
    }
    public void mutePlayer(bool arg)
    {
        if(arg)
        SoundManager.instance.SetPlayerVolume(0);
        else
        {
            SoundManager.instance.SetPlayerVolume(s1.value);
        }
    }
    public void muteAll(bool arg)
    {
        if (arg)
        {
            mutePlayer(true);
            muteSence(true);
            muteButton(true);
        }
        else
        {
            mutePlayer(false);
            muteSence(false);
            muteButton(false);
        }
    }
}
