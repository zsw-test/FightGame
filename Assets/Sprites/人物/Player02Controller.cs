using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02Controller : MonoBehaviour
{
    public float RunSpeed = 10f;
    public float JumpForce = 20f;
    public int dashSpeed = 30;
    public float dashTime = 0.2f;
    //public float DefenceSpeed = 2f;
    public float CurSpeed = 0;
    public bool isGround, isJump, isDashing, defence, death, isskill1,isskill2, isattack, isbreakout, ishurt, moveable = true,attackable = true;
    public int hitCount = 0;
    private Rigidbody2D rb;
    private CapsuleCollider2D BodyCollider;
    private Animator anim;
    private PlayerAttribute atr;
    public bool jumpPressed;
    public int jumpCount;
    private float horizontalMove;
    private float dashTimeLeft = 0;
    private AnimatorStateInfo stateInfo;
    private float ContinueAtkTime = 0.5f;//连击时间间隔
    private float ContinueAtkTimeTick = 0.5f;
    public Transform groundCheck;
    public Transform AttackPoint;
    public LayerMask ground;
    public LayerMask Player2;
    public GameObject breakout;
    public float breakouttimertick = 10f;
    public GameObject shield;
    public GameObject KnifeWave;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BodyCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        atr = GetComponent<PlayerAttribute>();
        breakout.gameObject.SetActive(false);
        shield.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //按键检测-->状态设置
        if ((Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.Keypad2)) && jumpCount > 0)
        {
            jumpPressed = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) horizontalMove = -1;
        else if (Input.GetKey(KeyCode.RightArrow)) horizontalMove = 1;
        else horizontalMove = 0;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            jumpPressed = false;
            defence = true;
            CurSpeed = 0;
        }
        else
        {
            defence = false;
            CurSpeed = RunSpeed;
        }
        if(attackable)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) && isGround&&!defence)
            {

                if (dashTimeLeft <= 0)
                {
                    isDashing = true;
                    dashTimeLeft = dashTime;
                }
            }
            if ((Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) && isGround)
            {
                isskill1 = true;
                moveable = false;
            }
            if ((Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) && isGround)
            {
                isskill2 = true;
                moveable = false;
            }
            if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) && isGround)
            {
                //attack();
                if (!isattack)
                    hitCount++;
                isattack = true;
                moveable = false;

            }
            if ((Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) && atr.CurrentEnergy == 3.0f && isbreakout == false)
            {
                SoundManager.instance.Energy1Audio();
                atr.Breakout = true;
                isbreakout = true;
                atr.CurrentEnergy -= 3.0f;
            }
        }
       
        atr.Defence = defence;

    }
    void ShotKinfeWave()
    {

        Transform temp = Instantiate(KnifeWave, new Vector3(AttackPoint.position.x, AttackPoint.position.y, AttackPoint.position.z), Quaternion.identity).GetComponent<Transform>();
        temp.localScale = new Vector3(-transform.localScale.x*Math.Abs(temp.localScale.x), temp.localScale.y, temp.localScale.z);
        //Instantiate(KnifeWave, AttackPoint.position, transform.rotation);
    }
    IEnumerator StartShiled()
    {
        shield.SetActive(true);
        SoundManager.instance.Defence2Audio();
        yield return new WaitForSeconds(0.5f);
        shield.SetActive(false);
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);

        GroundMovement();
        Dash();
        Jump();

        SwitchAnim();
    }
   

    void Jump()//跳跃
    {
        if (isGround)
        {
            jumpCount = 2;//可跳跃数量
            isJump = false;
        }
        if (jumpPressed && isGround)  //一段跳
        {

           
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJump = true;
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump) //二段跳
        {
            
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }

  
    void SwitchAnim()//动画切换
    {
        //stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        //if (stateInfo.IsName("Atk1"))
        //    Debug.Log(stateInfo.normalizedTime);
        //if (stateInfo.IsName("Atk2"))
        //    Debug.Log(stateInfo.normalizedTime);
        //if (stateInfo.IsName("Atk3"))
        //    Debug.Log(stateInfo.normalizedTime);
        //if (stateInfo.IsName("Atk1") && stateInfo.normalizedTime > 0.7f)
        //{

        //    hitCount = 0;   //将hitCount重置为0，即Idle状态
        //    anim.SetInteger("attack", hitCount);
        //   // isattack = false;
        //}
        //if (stateInfo.IsName("Atk2") && stateInfo.normalizedTime > 0.7f)
        //{
        //    hitCount = 0;   //将hitCount重置为0，即Idle状态
        //    anim.SetInteger("attack", hitCount);
        //  //  isattack = false;
        //}
        //if (stateInfo.IsName("Atk3") && stateInfo.normalizedTime > 0.7f )
        //{
        //    hitCount = 0;   //将hitCount重置为0，即Idle状态
        //    anim.SetInteger("attack", hitCount);
        //   // isattack = false;
        //}


        //if (isattack)
        //{

        //}
        //爆气动画处理
        if (isbreakout)
        {

            //if (GetComponentInChildren<ParticleSystem>().isStopped)
            //  {
            //      isbreakout = false;
            //      atr.Breakout = false;
            //      GetComponent<SpriteRenderer>().color = Color.white;
            //  }
            //  else
            //  {
            //      if(breakouttimertick > 0)
            //      {
            //          GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);
            //          breakouttimertick -= Time.deltaTime;
            //      }else if (breakouttimertick <= 0)
            //      {
            //          breakouttimertick -= Time.deltaTime;
            //          GetComponent<SpriteRenderer>().color = Color.white;
            //          if (breakouttimertick < -0.2f) breakouttimertick = 0.2f;
            //      }
            //  }
            if (breakouttimertick > 0)
            {
                breakout.gameObject.SetActive(true);
                breakouttimertick -= Time.deltaTime;
                if (breakouttimertick <= 0)
                {
                    breakouttimertick = 10f;
                    breakout.gameObject.SetActive(false);
                    isbreakout = false;
                    atr.Breakout = false;
                }
            }

        }
        //跑步动画
        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));

        //跳跃动画
        if (isGround)
        {
            anim.SetBool("falling", false);
        }
        else if (!isGround && rb.velocity.y > 0)
        {

            anim.SetBool("jumping", true);

        }
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }


        if (defence)
        {
            //防御动画  并且设置属性里的防御为true
            anim.SetBool("defence", true);
            //防御的时候打我是不会受伤的
            if (ishurt)
            {
                StartCoroutine(StartShiled());
                ishurt = false;
            }

        }
        else
        {
            anim.SetBool("defence", false);
        }

        //技能动画
        if (isskill1)
        {
            anim.SetBool("skill1", true);

            moveable = false;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Skill1") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {
              
                anim.SetBool("skill1", false);
                isskill1 = false;
                moveable = true;
            }

        }
        if (isskill2)
        {
            anim.SetBool("skill2", true);
            //发射knifeWave
            moveable = false;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Skill2") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {
                anim.SetBool("skill2", false);
                isskill2 = false;
                moveable = true;
            }
        }
        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("Atk3"))
        //    Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);

        //攻击动画
        if (isattack)
        {
            anim.SetInteger("attack", hitCount);
            moveable = false;
            anim.SetBool("isattack", true);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Atk1") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {

                anim.SetBool("isattack", false);
                isattack = false;
                moveable = true;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Atk3") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {

                anim.SetBool("isattack", false);
                isattack = false;
                moveable = true;
                hitCount = hitCount % 3;
            }

        }

        //受伤动画 
        if (ishurt && !defence&&!anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
        {
            anim.SetBool("hurt", true);
            moveable = false;
            ishurt = false;
        }
        // 如果受伤的过程中再受伤  就将受伤的状态改为false  
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f&&ishurt)
        {
            anim.SetBool("hurt", false);
            moveable = true;
        }
        //如果受伤的动画结束了  就可以移动了 并且将受伤改为false
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime>1f)
        {
            anim.SetBool("hurt", false);
            moveable = true;
        }



        if (atr.Death)
        {
            anim.SetBool("death", true);
            moveable = false;
        }
    }
    //移动
    void GroundMovement()
    {
        // horizontalMove = Input.GetAxisRaw("Horizontal");//只返回-1，0，1
        if (moveable)
        {
            rb.velocity = new Vector2(horizontalMove * CurSpeed, rb.velocity.y);

            if (horizontalMove != 0)
            {
                //转变方向
                transform.localScale = new Vector3(horizontalMove, 1, 1);
            }
        }
        else rb.velocity = new Vector2(0f, 0f);



    }
    //冲刺
    void Dash()
    {
        if (isDashing)
        {
            moveable = false;
            if (dashTimeLeft >= 0)
            {
                if (isGround)
                {
                    rb.velocity = new Vector2(gameObject.transform.localScale.x * dashSpeed, 0f);
                    dashTimeLeft -= Time.deltaTime;
                    ShadowPool.instance.outPool(gameObject.tag);
                    Debug.Log(dashTimeLeft);
                    BodyCollider.isTrigger = true;//dash的时候设置自己的碰撞体不能被碰到
                    rb.gravityScale = 0;

                }
                else
                {
                    //如果不在地上了
                    BodyCollider.isTrigger = false;
                    isDashing = false;
                    rb.gravityScale = 6;
                }
            }
            else
            {
                BodyCollider.isTrigger = false;
                isDashing = false;
                rb.gravityScale = 6;
            }
        }
        else
        {
            moveable = true;
        }
    }
    public void Attack()
    {

        var attackperson = Physics2D.OverlapCircle(AttackPoint.position, 1f, Player2);
        if (attackperson != null)
        {

            if (attackperson.tag == "Player1")
            {
                attackperson.GetComponent<PlayerAttribute>().GetHurt(atr.MyAttackDamage());
                Debug.Log(attackperson.tag);
                attackperson.GetComponent<Player01Controller>().ishurt = true;
            }
        }
    }


}
