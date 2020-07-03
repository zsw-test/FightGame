using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public float timer=2f;
    public GameObject CMV;
    public float speed=4f;
    public float timertick =2f;
    private bool p1showdown;
    private bool p2showdown;
    // Start is called before the first frame update
    void Start()
    {
        CMV.SetActive(false);
       // StartCoroutine(Wait1());
       
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
      
        if (p1showdown ==false)
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
                        speed *= 2;
                    }
                }
            }
        }
        else 
        {
            //两倍速度移动到p2
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
                        timer = 2f;
                        //p1、p2都show完了  开始设置倒计时
                        CMV.SetActive(true);
                        GameManager.instance.Startcountdown = true;
                        GameManager.instance.StartText.enabled = true;
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

        if (GetComponent<Camera>().orthographicSize < 2.7f)
        {
            GetComponent<Camera>().orthographicSize = 2.7f;
        }
        
      
        //for (float i = 0; i < timer; i += Time.deltaTime)
        //{
        //    transform.position = new Vector3(p2.position.x, p2.position.y, -5f);
        //}
        //CinemachineBrain.gameObject.SetActive(true);
    }
}
