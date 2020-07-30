using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ChooseMapManager : MonoBehaviour
{
    //Unity object
    public GameObject[] Maps;
    public SpriteRenderer bg;
    public GameObject[] fxs;
    public static string[] Mapnames = { "First","Second"};
    public static string[] RoundTime = { "60", "90", "∞" };
    public static string[] WinRound = { "三局两胜", "五局三胜"};
    public GameObject[] curs;
    public Text MapnameText;
    public Text RoundTimeText;
    public Text WinRoundText;
    public Button[] Buttons;
    [SerializeField]
    private int mapnameindex=0;
    [SerializeField]
    private int roundTimeindex = 0;
    [SerializeField]
    private int winRoundindex = 0;
    [SerializeField]
    private int curindex = 0;
    // Start is called before the first frame update
    void Start()
    {

        UIbuttonOnStart(curs[curindex].transform);
        Buttons[0].onClick.AddListener(
            delegate (){ pre(ref mapnameindex, Mapnames,MapnameText);}
            );
        Buttons[1].onClick.AddListener(
            delegate () { next(ref mapnameindex, Mapnames, MapnameText); }
            );
        Buttons[2].onClick.AddListener(
            delegate () { pre(ref roundTimeindex, RoundTime, RoundTimeText); }
            );
        Buttons[3].onClick.AddListener(
            delegate () { next(ref roundTimeindex, RoundTime, RoundTimeText); }
            );
        Buttons[4].onClick.AddListener(
            delegate () { pre(ref winRoundindex, WinRound, WinRoundText); }
            );
        Buttons[5].onClick.AddListener(
            delegate () { next(ref winRoundindex, WinRound, WinRoundText); }
            );
        Buttons[6].onClick.AddListener(Confrim);
        MapnameText.text = Mapnames[mapnameindex];
        RoundTimeText.text = RoundTime[roundTimeindex];
        WinRoundText.text = WinRound[winRoundindex];
        bg.sprite = Maps[mapnameindex].GetComponent<Image>().sprite;
        fxs[mapnameindex].SetActive(true);
    }
   public void  UIbuttonOnStart(Transform transform)
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
       if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))
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
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (curindex)
            {
                case 0:
                    {
                        StartCoroutine(hideMap(Maps[mapnameindex]));
                        pre(ref mapnameindex, Mapnames, MapnameText);
                        StartCoroutine(showMap(Maps[mapnameindex]));
                        break;

                    }
                case 1: pre(ref roundTimeindex, RoundTime, RoundTimeText); break;
                case 2: pre(ref winRoundindex, WinRound, WinRoundText); break;
                case 3: break;
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (curindex)
            {
                case 0:
                    StartCoroutine(hideMap(Maps[mapnameindex]));
                    next(ref mapnameindex, Mapnames, MapnameText);
                    StartCoroutine(showMap(Maps[mapnameindex]));
                    break;
                case 1: next(ref roundTimeindex, RoundTime, RoundTimeText); break;
                case 2: next(ref winRoundindex, WinRound, WinRoundText); break;
                case 3: break;
            }

        }
        if((Input.GetKeyDown(KeyCode.J)||Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Keypad1))&&curindex==3)
        {
            Confrim();
        }
    }
    public void pre(ref int index,string[] names,Text text)
    {
        index--;
        if (index < 0) index = names.Length - 1;
        text.text = names[index];
        Debug.Log(index);
    }
    public void next(ref int index, string[] names,Text text)
    {
        index++;
        index %= names.Length;
        text.text = names[index];
        Debug.Log(index);
    }
    
    IEnumerator  showMap(GameObject t)
    {
        t.SetActive(true);
        fxs[mapnameindex].SetActive(true);
        bg.sprite = Maps[mapnameindex].GetComponent<Image>().sprite;
        t.transform.DOScale(new Vector3(1, 1, 1), 0.1f);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator  hideMap(GameObject t)
    {
        t.transform.DOScale(new Vector3(0, 0, 0), 0.1f);
        fxs[mapnameindex].SetActive(false);
        bg.sprite = Maps[mapnameindex].GetComponent<Image>().sprite;
        yield return new WaitForSeconds(0.1f);
        t.SetActive(false);
    }
    public void Confrim()
    {
        SenceManager.instance.ChangeSence(3);
        SenceManager.instance.FightSence += mapnameindex;
        SenceManager.instance.Rountime = RoundTime[roundTimeindex];
        SenceManager.instance.wincount = 2 + winRoundindex;
        
    }
}
