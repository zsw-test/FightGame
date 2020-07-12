using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))                  //按ESC按键进行暂停
        {
            SoundManager.instance.ButtonAudio();
            if(pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }


        }

    }

    public void PauseGame()                                //暂停按钮 弹出暂停菜单
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()                                   //返回按钮 退出暂停菜单
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void renew()                                    //重新开始游戏  回到开始菜单
    {
        SenceManager.instance.ChangeSence(0);
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void QuitGame()                                 //退出游戏  整体退出
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
