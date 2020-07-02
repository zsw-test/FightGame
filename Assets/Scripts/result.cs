using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class result : MonoBehaviour
{
    public void Show()
    {
        GameManager.instance.WhoWin();
    }
}
