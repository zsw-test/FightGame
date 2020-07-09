using System.Collections;
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
    public int wincount = 2;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

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
    public void SetPlayer1(string name)
    {
        instance.player1name = name;
    }
    public void SetPlayer2(string name)
    {
        instance.player2name = name;
    }
    public void checkplayer()
    {
        
        if (!instance.player1name.Equals("") && !instance.player2name.Equals(""))
        {
            ChangeSence(2);
            SoundManager.instance.GuidAudio();
        }
    }
    public void ChangeSence(string name)
    {
        SceneManager.LoadScene(name);
       
    }

    public void ChangeSence(int num)
    {
        if (num == 0||num==1)
        {
            instance.clear();
        }
        SceneManager.LoadScene(num);
        

    }
}
