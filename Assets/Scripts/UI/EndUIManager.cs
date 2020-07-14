using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUIManager : MonoBehaviour
{
    public Transform bg;
    public Transform text;
    public Image EndText;
    public Image BackGround;
    // Start is called before the first frame update
    void Start()
    {
        bg.transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f);
        text.transform.DOLocalMove(new Vector3(0, -100, 0), 2f);
        EndText.sprite = Resources.Load(SenceManager.instance.winnerName+"endtext", typeof(Sprite)) as Sprite;
        BackGround.sprite = Resources.Load(SenceManager.instance.winnerName + "endbg", typeof(Sprite)) as Sprite;
        SoundManager.instance.WinAudio();



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
