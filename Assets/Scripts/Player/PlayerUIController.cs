using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public struct Attrs
{
   public int index;
   public Sprite sprite;
   public int cd;

    public Attrs(int index, Sprite sprite, int cd)
    {
        this.index = index;
        this.sprite = sprite;
        this.cd = cd;
    }
}
public class PlayerUIController : MonoBehaviour
{
    public Text TickText;
    [Header("tick参数")]
    public float Timer = 0.8f;
    public float preHurtTime = 0f;
    public int TickNum = 0;

    public Image CdIcon1;
    public Image CdImage1;
    public Image CdIcon2;
    public Image CdImage2;

    public Image Head;
    public Slider health;
    public Slider energy;
    public GameObject[] attrs;
    public Image[] attrshadow;
    public List<int> atrindex = new List<int>();

    public float[] attrcds;
    public int curindex = 0;
    // Start is called before the first frame update
    void Start()
    {

        attrcds = new float[attrs.Length];
        attrshadow = new Image[attrs.Length];
       for(int i=0;i<attrs.Length;++i)
        {
            Image[] images = attrs[i].GetComponentsInChildren<Image>();
            attrshadow[i] = images[images.Length-1];
            attrshadow[i].fillAmount = 0;
            attrs[i].SetActive(false);
            
        }
        if (gameObject.tag=="Player1")
        {
            Head.sprite = Resources.Load(SenceManager.instance.player1name.Replace("P1", "") + "head", typeof(Sprite)) as Sprite;
        }else if(gameObject.tag=="Player2")
        {
            
            Head.sprite = Resources.Load(SenceManager.instance.player2name.Replace("P2", "") + "head", typeof(Sprite)) as Sprite;
        }
        else
        {
            Debug.LogError("头像错误？？？");
        }
        
    }

    public void AtrCdDone(int atr)
    {

        int cddoneindex = atrindex[atr];

        for (int i=cddoneindex;i<curindex-1;++i)
        {
            attrs[i].GetComponent<Image>().sprite = attrs[i + 1].GetComponent<Image>().sprite;
           // attrshadow[i].GetComponent<Image>().sprite = attrshadow[i + 1].GetComponent<Image>().sprite;
            attrshadow[i].GetComponent<Image>().fillAmount = attrshadow[i + 1].GetComponent<Image>().fillAmount;
            attrcds[i] = attrcds[i + 1];
        }
        for(int i=0;i<atrindex.Count;++i)
        {
            if (atrindex[i] > cddoneindex) atrindex[i]--;
        }
        //atrindex.Remove(atr);
        attrs[curindex - 1].SetActive (false);
        curindex--;
        if (curindex == 0) atrindex.Clear();
    }
    public  int AtrCdAction(Sprite sprite,int cd)
    {
        atrindex.Add(curindex);
        attrcds[curindex] = cd;
        attrs[curindex].SetActive(true);
        attrs[curindex].GetComponent<Image>().sprite = sprite;
        //attrshadow[curindex].sprite = sprite;
        attrshadow[curindex].color = new Color(0f, 0f, 0f, 0.6f);
        attrshadow[curindex].fillAmount = 0;
        curindex++;
        return atrindex.Count-1;
    }


    public void TickDetection()
    {
        if (Time.time - preHurtTime > Timer)
        {
            TickNum = 0;
            TickText.enabled = false;
        }
    }
    public void ContinueTick()
    {
        TickNum++;
        TickText.text = TickNum + "连击";
        TickText.enabled = true;
        preHurtTime = Time.time;
    }

    public void UpdateAtrcds()
    {
        for(int i=0;i<attrs.Length;++i)
        {
            if(attrs[i].activeSelf)
            {
                attrshadow[i].fillAmount += 1 / attrcds[i] * Time.deltaTime;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        TickDetection();
        UpdateAtrcds();
        CdImage1.fillAmount -= 1 / GetComponent<PlayerController>().dashCdtime * Time.deltaTime;
        CdImage2.fillAmount -= 1 / GetComponent<PlayerController>().Skill2Cdtime * Time.deltaTime;
        health.value = (float)gameObject.GetComponent<PlayerAttribute>().CurrentBlood / gameObject.GetComponent<PlayerAttribute>().Blood;
        energy.value = (float)gameObject.GetComponent<PlayerAttribute>().CurrentEnergy / gameObject.GetComponent<PlayerAttribute>().Energy;
    }

}
