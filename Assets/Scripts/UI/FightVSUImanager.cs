using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FightVSUImanager : MonoBehaviour
{
    public Image P1vs;
    public Image P2vs;
    public Image VS;
    public Sprite[] VSsprites;
    // Start is called before the first frame update
    void Start()
    {
        string p1name = SenceManager.instance.player1name.Replace("P1", "");
        string p2name = SenceManager.instance.player2name.Replace("P2", "");
        if (p1name.Equals("苏利耶"))
        {
            P1vs.sprite = VSsprites[0];
            P1vs.transform.localScale = new Vector2(-1, 1);
        }
        else if (p1name.Equals("玛尔斯"))
        {
            P1vs.sprite = VSsprites[1];
        }
        if (p2name.Equals("苏利耶"))
        {
            P2vs.sprite = VSsprites[0];

        }
        else if (p2name.Equals("玛尔斯"))
        {
            P2vs.sprite = VSsprites[1];
            P2vs.transform.localScale = new Vector2(-1, 1);
        }

        StartCoroutine(nextSence());
        
    }
     IEnumerator nextSence()
    {
        P1vs.transform.DOLocalMoveX(-450, 0.2f);
        P2vs.transform.DOLocalMoveX(450, 0.2f);
        VS.transform.DOLocalMoveY(0, 0.3f);
        yield return new WaitForSeconds(3f);
        SenceManager.instance.ChangeSence(4);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
