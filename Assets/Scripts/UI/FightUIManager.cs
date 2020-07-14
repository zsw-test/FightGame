using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightUIManager : MonoBehaviour
{
    public Image bg;
    float timer = 1f;
    float m_alpha ;
    public GameObject[] p1wincounts;
    public GameObject[] p2wincounts;
    public Image P1Head;
    public Image P2Head;
    // Start is called before the first frame update
    void Start()
    {
        m_alpha = bg.color.a;
        P1Head.sprite =  Resources.Load(SenceManager.instance.player1name.Replace("P1", "") + "head", typeof(Sprite)) as Sprite;
        P2Head.sprite = Resources.Load(SenceManager.instance.player2name.Replace("P2", "") + "head", typeof(Sprite)) as Sprite;
        Debug.Log(SenceManager.instance.player1name.Replace("P1","")+"head");
        Debug.Log(SenceManager.instance.player2name.Replace("P2", "")+ "head");
    }

    // Update is called once per frame
    void Update()
    {
        if(m_alpha>0)
        {
            m_alpha -= 0.5f*Time.deltaTime;
            timer -= 0.5f;
            Color cur = bg.color;

            cur.a = m_alpha;
            bg.color = cur;
        }
           
       for(int i=0;i<SenceManager.instance.player1wincount;++i)
        {
            p1wincounts[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < SenceManager.instance.player2wincount; ++i)
        {
            p2wincounts[3-i-1].gameObject.SetActive(true);
        }

    }
}
