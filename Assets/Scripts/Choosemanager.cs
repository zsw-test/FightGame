using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choosemanager : MonoBehaviour
{
    public List<Sprite> Player1s;
    public List<Sprite> Player2s;
    public Image P1;
    public Image P2;
    public Text p1text;
    public Text p2text;
    public int P1ChooseIndex = 0;
    public int P2ChooseIndex = 0;
    public Button b1;
    public Button b2;
    // Start is called before the first frame update
    void Start()
    {
        p1text.text = Player1s[P1ChooseIndex].name;
        p2text.text = Player2s[P2ChooseIndex].name;
        b1.onClick.AddListener(DisableB1);
        b2.onClick.AddListener(DisableB2);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            prePlayer1();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            nextPlayer1();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            prePlayer2();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            nextPlayer2();
        }
    }
    public void prePlayer1()
    {
        P1ChooseIndex--;
        if (P1ChooseIndex <0) P1ChooseIndex = Player1s.Count-1;
        P1.sprite = Player1s[P1ChooseIndex];
        Debug.Log(Player1s[P1ChooseIndex].name);
        p1text.text = Player1s[P1ChooseIndex].name;
    }
    public void prePlayer2()
    {
        P2ChooseIndex--;
        if (P2ChooseIndex < 0) P2ChooseIndex = Player2s.Count-1;
        P2.sprite = Player2s[P2ChooseIndex];

        Debug.Log(Player2s[P2ChooseIndex].name);
        p2text.text = Player2s[P2ChooseIndex].name;
    }
    public void nextPlayer1()
    {
        P1ChooseIndex++;
        if (P1ChooseIndex >= Player1s.Count) P1ChooseIndex = 0;
        P1.sprite = Player1s[P1ChooseIndex];
        Debug.Log(Player1s[P1ChooseIndex].name);
        p1text.text = Player1s[P1ChooseIndex].name;
    }

    public void nextPlayer2()
    {
        P2ChooseIndex++;
        if (P2ChooseIndex >= Player2s.Count) P2ChooseIndex = 0;
        P2.sprite = Player2s[P2ChooseIndex];
        
        Debug.Log(Player2s[P2ChooseIndex].name);
        p2text.text = Player2s[P2ChooseIndex].name;
    }
    public void SetPlayer1()
    {
        SenceManager.instance.SetPlayer1(Player1s[P1ChooseIndex].name+"P1");
        SenceManager.instance.checkplayer();
    }
    public void SetPlayer2()
    {
        SenceManager.instance.SetPlayer2(Player2s[P2ChooseIndex].name+"P2");
        SenceManager.instance.checkplayer();
    }
    public void checkPlayers()
    {
        SenceManager.instance.checkplayer();
    }
    public void DisableB1()
    {
       
        b1.interactable = false;
    }
    public void DisableB2()
    {
        b2.interactable = false;
    }
}
