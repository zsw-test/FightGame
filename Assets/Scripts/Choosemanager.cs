using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choosemanager : MonoBehaviour
{
    public Sprite[] Characters;
    public Image P1;
    public Image P2;

    public bool IsChange1 = false;
    public bool IsChange2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsChange1 == true)
        {
            if (P1.sprite == Characters[0])
            {
                P1.sprite = Characters[1];
                IsChange1 = false;
            }
            else
            {
                P1.sprite = Characters[0];
                IsChange1 = false;
            }
        }

        if (IsChange2 == true)
        {
            if (P2.sprite == Characters[0])
            {
                P2.sprite = Characters[1];
                IsChange2 = false;
            }
            else
            {
                P2.sprite = Characters[0];
                IsChange2 = false;
            }
        }
    }

    public void Change1()
    {
        IsChange1 = true;
    }

    public void Change2()
    {
        IsChange2 = true;
    }
}
