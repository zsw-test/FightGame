using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choosemanager : MonoBehaviour
{
    public List<GameObject> Player1s;
    public List<GameObject> Player2s;
    public Image P1;
    public Image P2;
    public Text p1text;
    public Text p2text;
    public int P1ChooseIndex = 0;
    public int P2ChooseIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        p1text.text = Player1s[P1ChooseIndex].name;
        p2text.text = Player2s[P2ChooseIndex].name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextPlayer1()
    {
        P1ChooseIndex++;
        if (P1ChooseIndex >= Player1s.Count) P1ChooseIndex = 0;
        P1.sprite = Player1s[P1ChooseIndex].GetComponent<SpriteRenderer>().sprite;
        Debug.Log(Player1s[P1ChooseIndex].name);
        p1text.text = Player1s[P1ChooseIndex].name;
    }

    public void nextPlayer2()
    {
        P2ChooseIndex++;
        if (P2ChooseIndex >= Player2s.Count) P2ChooseIndex = 0;
        P2.sprite = Player2s[P2ChooseIndex].GetComponent<SpriteRenderer>().sprite;
        
        Debug.Log(Player2s[P2ChooseIndex].name);
        p2text.text = Player2s[P2ChooseIndex].name;
    }
    public void SetPlayer1()
    {
        SenceManager.instance.SetPlayer1(Player1s[P1ChooseIndex].name);
        SenceManager.instance.checkplayer();
    }
    public void SetPlayer2()
    {
        SenceManager.instance.SetPlayer2(Player2s[P2ChooseIndex].name);
        SenceManager.instance.checkplayer();
    }
    public void checkPlayers()
    {
        SenceManager.instance.checkplayer();
    }
   
}
