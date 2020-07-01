using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool flag = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))                  //按ESC按键进行暂停
        {
            if (!flag)
            {
                PauseGame();
                flag = true;
            }
            else
            {
                Resume();
                flag = false;
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
        SceneManager.LoadScene(0);
    }

    public void QuitGame()                                 //退出游戏  整体退出
    {
        Application.Quit();
    }

}
