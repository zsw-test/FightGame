using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player01Animation : MonoBehaviour
{
    private Animator animator;
    private Animation animation;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void beaten()
    {
        animator.SetBool("Beaten", true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Death()
    {
        animator.SetBool("Death", true);
    }
    public void attack2()
    {
        animator.SetBool("Atk2-2", true);
    }
    public void attack3()
    {
        animator.SetBool("Atk2-3", true);
    }
    public void attack1()
    {
        animator.SetBool("Atk2-1",true);
    }
    public void attack1down()
    {
        animator.SetBool("Atk2-1", false);
    }
    public void attack2down()
    {
        animator.SetBool("Atk2-2", false);
    }
    public void attack3down()
    {
        animator.SetBool("Atk2-3", false);
    }
    public void Skill1()
    {
        animator.SetBool("Skill1",true);
    }
    public void Skill1down()
    {
        animator.SetBool("Skill1", false);
    }
    public void Run(bool move)
    {
        if(move)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Defence", false);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    public void Defence(bool defence)
    {
        if(defence)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Defence", true);
        }
        else
        {
            animator.SetBool("Defence", false);
        }
        
    }
    public void Idle()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Defence", false);
    }

   
}
