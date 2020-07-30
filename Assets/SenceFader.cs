using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceFader : MonoBehaviour
{
    public Animator anim;
    int faderid;
    // Start is called before the first frame update
    void Start()
    {
       anim =gameObject.GetComponent<Animator>();
        faderid = Animator.StringToHash("Fade");
    }

    public void FadeOut()
    {
        anim.SetTrigger(faderid);
    }
    // Update is called once per frame

}
