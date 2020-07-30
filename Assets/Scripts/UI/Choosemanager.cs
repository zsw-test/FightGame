using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choosemanager : MonoBehaviour
{
    public List<Sprite> PlayerSprites;
    public List<Sprite> PlayerBGSprites;
    public List<Sprite> PlayerIcons;
    public Image P1Image;
    public Image P2Image;
    public Image P1Bg;
    public Image P2Bg;
    public Text p1text;
    public Text p2text;
    public Image P1icon;
    public Image P2icon;
    public int P1ChooseIndex = 0;
    public int P2ChooseIndex = 0;
    public Button b1;
    public Button b2;
    // Start is called before the first frame update
    void Start()
    {
        p1text.text = PlayerSprites[P1ChooseIndex].name;
        p2text.text = PlayerSprites[P2ChooseIndex].name;
        P1Image.sprite = PlayerSprites[P1ChooseIndex];
        P2Image.sprite = PlayerSprites[P2ChooseIndex];
        P1Bg.sprite = PlayerBGSprites[P1ChooseIndex];
        P2Bg.sprite = PlayerBGSprites[P2ChooseIndex];
        P1icon.sprite = PlayerIcons[P1ChooseIndex];
        P2icon.sprite = PlayerIcons[P2ChooseIndex];
        b1.onClick.AddListener(DisableB1);
        b2.onClick.AddListener(DisableB2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            SoundManager.instance.ButtonAudio();
            prePlayer1();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SoundManager.instance.ButtonAudio();
            nextPlayer1();
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            SoundManager.instance.ButtonAudio();
            SetPlayer1();
            DisableB1();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SoundManager.instance.ButtonAudio();
            prePlayer2();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            SoundManager.instance.ButtonAudio();
            nextPlayer2();
        }
        if(Input.GetKeyDown(KeyCode.Keypad1)||Input.GetKeyDown(KeyCode.Alpha1))
        {
            SoundManager.instance.ButtonAudio();
            SetPlayer2();
            DisableB2();
        }
    }
    public void prePlayer1()
    {
        P1ChooseIndex--;
        if (P1ChooseIndex <0) P1ChooseIndex = PlayerSprites.Count-1;
        P1Image.sprite = PlayerSprites[P1ChooseIndex];
        P1Bg.sprite = PlayerBGSprites[P1ChooseIndex];
        P1icon.sprite = PlayerIcons[P1ChooseIndex];
        Debug.Log(PlayerSprites[P1ChooseIndex].name);
        p1text.text = PlayerSprites[P1ChooseIndex].name;
    }
    public void prePlayer2()
    {
        P2ChooseIndex--;
        if (P2ChooseIndex < 0) P2ChooseIndex = PlayerSprites.Count-1;
        P2Image.sprite = PlayerSprites[P2ChooseIndex];
        P2Bg.sprite = PlayerBGSprites[P2ChooseIndex];
        P2icon.sprite = PlayerIcons[P2ChooseIndex];
        Debug.Log(PlayerSprites[P2ChooseIndex].name);
        p2text.text = PlayerSprites[P2ChooseIndex].name;
    }
    public void nextPlayer1()
    {
        P1ChooseIndex++;
        if (P1ChooseIndex >= PlayerSprites.Count) P1ChooseIndex = 0;
        P1Image.sprite = PlayerSprites[P1ChooseIndex];
        P1Bg.sprite = PlayerBGSprites[P1ChooseIndex];
        P1icon.sprite = PlayerIcons[P1ChooseIndex];
        Debug.Log(PlayerSprites[P1ChooseIndex].name);
        p1text.text = PlayerSprites[P1ChooseIndex].name;
    }

    public void nextPlayer2()
    {
        P2ChooseIndex++;
        if (P2ChooseIndex >= PlayerSprites.Count) P2ChooseIndex = 0;
        P2Image.sprite = PlayerSprites[P2ChooseIndex];
        P2Bg.sprite = PlayerBGSprites[P2ChooseIndex];
        P2icon.sprite = PlayerIcons[P2ChooseIndex];
        Debug.Log(PlayerSprites[P2ChooseIndex].name);
        p2text.text = PlayerSprites[P2ChooseIndex].name;
    }
    public void SetPlayer1()
    {
        SenceManager.instance.SetPlayer1(PlayerSprites[P1ChooseIndex].name+"P1");
        SenceManager.instance.checkplayer();
    }
    public void SetPlayer2()
    {
        SenceManager.instance.SetPlayer2(PlayerSprites[P2ChooseIndex].name+"P2");
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
