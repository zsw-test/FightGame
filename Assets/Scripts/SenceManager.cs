﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SenceManager : MonoBehaviour
{

    public static SenceManager instance;
    public int player1wincount;
    public int player2wincount;
    public string player1name;
    public string player2name;
    public int wincount = 1;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }
    public void clear()
    {
        player1wincount = 0;
        player2wincount = 0;
        player1name = "";
        player2name = "";
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeSence(string name)
    {
        SceneManager.LoadScene(name);
       
    }

    public void ChangeSence(int num)
    {
        SceneManager.LoadScene(num);

    }
}
