using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform p1;
    public Transform p2;
    public float timer;
    public GameObject CMV;
    // Start is called before the first frame update
    void Start()
    {
        CMV.SetActive(false);
        StartCoroutine(Wait1());
       
    }
   IEnumerator Wait1()
    {
        
        transform.position = new Vector3(p1.position.x, p1.position.y, -5f);
        GetComponent<Camera>().orthographicSize = 3;
        //角色一展示动画
        yield return new WaitForSeconds(3);
        StartCoroutine(Wait2());
    }
    IEnumerator Wait2()
    {
        transform.position = new Vector3(p2.position.x, p2.position.y, -5f);
        GetComponent<Camera>().orthographicSize = 3;
        //角色二展示动画
        yield return new WaitForSeconds(3);
        CMV.SetActive(true);
        GameManager.instance.CountDown = true;
    }
    // Update is called once per frame
    void LateUpdate()
    {

     

        
      
        //for (float i = 0; i < timer; i += Time.deltaTime)
        //{
        //    transform.position = new Vector3(p2.position.x, p2.position.y, -5f);
        //}
        //CinemachineBrain.gameObject.SetActive(true);
    }
}
