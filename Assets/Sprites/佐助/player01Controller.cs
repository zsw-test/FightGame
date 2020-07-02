using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum State{
    atk1,
    beaten,
    death,
    defence,
    idle,
    run,
    skill1
}


public class player01Controller : MonoBehaviour
{
    public int moveSpeed = 3;
    
    public float continueTime = 2f;
    public int clickNum = 0;
    private float lastClickedTime = 0;
    private player01Animation player01Animation;
    private Rigidbody2D m_Rigidbody2D;
    private bool move = false;
    private bool defence = false;
    private bool moveable = true;
    private Animator animator;
    private Animation animation;
    private AnimatorStateInfo stateInfo;
    public int hitCount = 0;   //0:表示idle状态。 1:表示当前正在进行attack_a。 2:attack_b。 3：attack_c。

    // Start is called before the first frame update
    void Start()
    {
        player01Animation = GetComponent<player01Animation>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeStatus();
       
    }

    private void FixedUpdate()
    {
        Move();
        
      
    }

    void Move()
    {

        if (moveable)//如果可以移动
        {
            //角色的移动
            if (Input.GetKey(KeyCode.D))
            {
                
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                transform.localScale = new Vector2(1f, 1f);
                move = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
                transform.localScale = new Vector2(-1f, 1f);
                move = true;
            }
            else
            {
                m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
                move = false;
            }
        }
       



    }
    //控制状态机的变化
    void ChangeStatus()
    {
        player01Animation.Run(move);
        player01Animation.Defence(defence);
        if (Input.GetKeyDown(KeyCode.J))
        {
            moveable = false;
            player01Animation.Skill1();
        }

        //下蹲的状态变化 
        if (Input.GetKey(KeyCode.S))
        {
            defence = true;
            moveSpeed = 1;
        }
        else
        {
            moveSpeed = 3;
            defence = false;
        }
         stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        
        Debug.Log(name);
        if (stateInfo.IsName("Atk001"))
        {
            Debug.Log(stateInfo.normalizedTime);
        }
        
        //若动画为三种状态之一并且已经播放完毕
        if (stateInfo.IsName("Atk001")  && stateInfo.normalizedTime > 1.5f)
        {
           
            hitCount = 0;   //将hitCount重置为0，即Idle状态
            animator.SetInteger("Attack", hitCount);
            // attack = false;
        }
        if (stateInfo.IsName("Atk002") && stateInfo.normalizedTime > 1.5f)
        {
            hitCount = 0;   //将hitCount重置为0，即Idle状态
            animator.SetInteger("Attack", hitCount);
            // attack = false;
        }
        if (stateInfo.IsName("Atk003") && stateInfo.normalizedTime > 1.3f)
        {
            hitCount = 0;   //将hitCount重置为0，即Idle状态
            animator.SetInteger("Attack", hitCount);
            // attack = false;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            attack();
            if (stateInfo.IsName("Atk001"))
                Debug.Log(stateInfo.normalizedTime);
        }
        //if (Time.time - lastClickedTime > continueTime)
        //{
        //    clickNum = 0;
        //}



        //if (Input.GetMouseButtonDown(0))
        //{
        //    lastClickedTime = Time.time;
        //    clickNum++;
        //    if (clickNum == 1)
        //    {
        //        GetComponent<Animator>().SetBool("AtkCombo", true);
        //    }

        //    clickNum = Mathf.Clamp(clickNum, 0, 3);
        //}

    }


    
    public void SkillDown()
    {
        moveable = true;
        player01Animation.Skill1down();
    }

    public void Atk1Down()
    {
        player01Animation.attack1down();
    }
    public void ComboCheck1()
    {
        if (clickNum > 1)
        {
            clickNum = 0;
            player01Animation.attack2();
        }
    }
    public void ComboCheck2()
    {
        if(clickNum>2) player01Animation.attack3();

    }
    public void ComboCheck(int num)
    {
        if (clickNum >= num)
        {

            GetComponent<Animator>().SetBool("AtkCombo", true);
        }
    }

    //void HandleAttack()
    //{
    //    Debug.Log(stateInfo.ToString());
    //    //若处于Idle状态，则直接打断并过渡到attack_a(攻击阶段一)
    //    if (stateInfo.IsName("佐助idle") && hitCount == 0)
    //    {
    //        hitCount = 1;
    //        animator.SetInteger("Attack", hitCount);
    //    }
    //    //如果当前动画处于attack_a(攻击阶段一)并且该动画播放进度小于80%，此时按下攻击键可过渡到攻击阶段二
    //    else if (stateInfo.IsName("Atk001") && hitCount == 1 && stateInfo.normalizedTime < 0.8f)
    //    {
    //        hitCount = 2;
    //    }
    //    //同上
    //    else if (stateInfo.IsName("Atk002") && hitCount == 2 && stateInfo.normalizedTime < 0.8f)
    //    {
    //        hitCount = 3;
    //    }
    //}
    //void GoToNextAttackAction()
    //{
    //    animator.SetInteger("Attack", hitCount);
    //}
    void attack()
    {

        if(hitCount ==0)
        {
            hitCount = 1;
            animator.SetInteger("Attack", hitCount);
        }
        else if(stateInfo.IsName("Atk001") && hitCount == 1 && stateInfo.normalizedTime > 0.9f)
           {
            hitCount = 2;
            animator.SetInteger("Attack", hitCount);
        }
        else if(stateInfo.IsName("Atk002") && hitCount == 2 && stateInfo.normalizedTime > 0.9f)
         {
            hitCount = 3;
            animator.SetInteger("Attack", hitCount);
        }
    }
}
