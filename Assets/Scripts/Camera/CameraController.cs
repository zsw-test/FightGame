using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public float timer=2f;
    public GameObject CMV;
    public float speed=16f;
    public float timertick =2f;
    private bool p1showdown;
    private bool p2showdown;
    public static CameraController instance;
    public string Winner="";
    // Start is called before the first frame update
    void Start()
    {
        CMV.SetActive(false);
        // StartCoroutine(Wait1());
        instance = this;
       
       // StartCoroutine(StartLock());
    }
   //IEnumerator Wait1()
   // {

   //     transform.position = Vector3.MoveTowards(transform.position, new Vector3(p1.position.x, p1.position.y, -10f), speed * Time.deltaTime);
   //     GetComponent<Camera>().orthographicSize = 3;
   //     //角色一展示动画
   //     yield return new WaitForSeconds(2);
        
   // }
   // IEnumerator Wait2()
   // {
   //     transform.position = Vector3.MoveTowards(transform.position, new Vector3(p2.position.x, p2.position.y, -10f), speed * Time.deltaTime);
   //     GetComponent<Camera>().orthographicSize = 3;
   //     //角色二展示动画
   //     yield return new WaitForSeconds(2);
   //     CMV.SetActive(true);
   //     GameManager.instance.Startcountdown = true;
   //     GameManager.instance.StartText.enabled = true;
   // }
    // Update is called once per frame
    void LateUpdate()
    {
        if (p1showdown == false)
        {
            //相机移动到p1
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(p1.position.x, p1.position.y, -10f), speed * Time.deltaTime);

            //如果相机移动到了p1
            if (Mathf.Approximately(transform.position.x, p1.position.x) && Mathf.Approximately(transform.position.y, p1.position.y))
            {
                //p1展示动画
                if (timer > 0 && p1showdown == false)
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        p1showdown = true;
                        timer = 2f;

                    }
                }
            }
        }
        else if(p1showdown==true&&p2showdown==false)
        {

            //相机移动到p2
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(p2.position.x, p2.position.y, -10f), speed * Time.deltaTime);
            //如果相机移动到了p2
            if (Mathf.Approximately(transform.position.x, p2.position.x) && Mathf.Approximately(transform.position.y, p2.position.y))
            {
                //p2展示动画
                if (timer > 0 && p2showdown == false)
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        p2showdown = true;
                        timer = 3f;
                        //p1、p2都show完了  开始设置倒计时
                        CMV.SetActive(true);
                        GameManager.instance.Startcountdown = true;
                        GameManager.instance.StartText.enabled = true;
                    }
                }
            }
        }
        if(!Winner.Equals(""))
        {
            if(Winner.Equals("P1"))
            {
                CMV.SetActive(false);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(p1.position.x, p1.position.y, -10f), speed * Time.deltaTime);
                if (timer > 0)
                {
                    GameManager.instance.StartText.enabled = true;
                    GameManager.instance.StartText.text = Winner + "获胜！";
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        timer = 3f;
                        if (GameManager.instance.GameEnd)
                            SenceManager.instance.ChangeSence(SenceManager.instance.EndSence);
                        else
                        {
                            CMV.SetActive(true);
                            SenceManager.instance.ChangeSence(SenceManager.instance.FightSence);
                        }
                    }
                }
            }
            else if(Winner.Equals("P2"))
            {
                CMV.SetActive(false);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(p2.position.x, p2.position.y, -10f), speed * Time.deltaTime);
                if (timer > 0)
                {
                    GameManager.instance.StartText.enabled = true;
                    GameManager.instance.StartText.text = Winner + "获胜！";
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        timer = 3f;
                        if (GameManager.instance.GameEnd)
                            SenceManager.instance.ChangeSence(SenceManager.instance.EndSence);
                        else
                        {
                            CMV.SetActive(true);
                            SenceManager.instance.ChangeSence(SenceManager.instance.FightSence);
                        }
                    }
                }
            }else if(Winner.Equals("None"))
            {
                if (timer > 0)
                {
                    GameManager.instance.StartText.enabled = true;
                    GameManager.instance.StartText.text = "平局";
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        timer = 2f;
                        SenceManager.instance.ChangeSence(SenceManager.instance.FightSence);
                    }
                }
            }
        }
        //if(p1showdown&&p2showdown)
        //{
        //    CMV.SetActive(true);
        //    GameManager.instance.Startcountdown = true;
        //    GameManager.instance.StartText.enabled = true;
        //}

        //transform.position += new Vector3(p1.position.x, p1.position.y, -5f);




        //for (float i = 0; i < timer; i += Time.deltaTime)
        //{
        //    transform.position = new Vector3(p2.position.x, p2.position.y, -5f);
        //}
        //CinemachineBrain.gameObject.SetActive(true);
    }
    public void WinLockPlayer(string p, int nextsence)
    {
        StartCoroutine(WinLock(p,nextsence));
       
    }
  

    public IEnumerator WinLock(string p,int nextsence)
    {
        CMV.SetActive(false);
        if(p.Equals("P1"))
        {
            transform.position = new Vector3(p1.position.x, p1.position.y, -10f) ;
        }
        else if(p.Equals("P2"))
        {

            transform.position = new Vector3(p2.position.x, p2.position.y, -10f);
        }
        else
        {
            Debug.LogError("??没有此p --from cameracontroller");
        }
       
        GameManager.instance.StartText.enabled = true;
        GameManager.instance.StartText.text = p + "获胜！";
        yield return new WaitForSeconds(3f);
        //CMV.SetActive(true);
        SenceManager.instance.ChangeSence(nextsence);
    }
    

  

     
}
