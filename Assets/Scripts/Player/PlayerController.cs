using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float RunSpeed = 10f;
    public float JumpForce = 20f;
    [Header("dash参数")]
    public int dashSpeed = 30;
    public float dashTime = 0.2f;
    public float LastDashTime = 0;
    public float dashCdtime = 2f;
    public float dashTimeLeft = 0;

    [Header("skill2参数")]
    public float Skill2Cdtime = 3f;
    public float LastSkill2time = 0;

    //public float DefenceSpeed = 2f;
    public float CurSpeed = 0;

    [Header("人物状态")]
    public bool isGround, isJump, isDashing, defence, death, isskill1, isskill2, isattack, isbreakout, ishurt, ishurtShiled , istetanic,moveable = true, attackable = true;
    public int hitCount = 0;
    protected Rigidbody2D rb;
    protected CapsuleCollider2D BodyCollider;
    protected Animator anim;
    protected PlayerAttribute atr;
    public bool jumpPressed;
    public int jumpCount;
    protected float horizontalMove;
    
    [Header("人物碰撞设置")]
    private AnimatorStateInfo stateInfo;
    public Transform groundCheck;
    public Transform AttackPoint;
    public GameObject AttackCollider;
    
    public LayerMask ground;
    public LayerMask PlayerAnother;
    public GameObject breakout;
    public float breakouttimertick = 10f;
    public GameObject shield;
    public GameObject Wave;

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
    public virtual void Player1InputGet()
    {

        if (defence && isGround && Input.GetKeyDown(KeyCode.K))
        {
            BodyCollider.isTrigger = true;

        }
        if (!isGround&&!isDashing)
        {
            BodyCollider.isTrigger = false;
        }

        if (attackable)
        {
            //按键检测-->状态设置
            if (Input.GetKeyDown(KeyCode.K) && jumpCount > 0&&moveable)
            {
                jumpPressed = true;

            }
            if (Input.GetKey(KeyCode.A))
            {

                horizontalMove = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {

                horizontalMove = 1;
            }
            else horizontalMove = 0;

            if (Input.GetKey(KeyCode.S) && !ishurt && !istetanic)
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
            if (Input.GetKeyDown(KeyCode.L) && isGround && !defence)
            {
                //如果第一次释放  就可以直接用
                if (LastDashTime == 0)
                {
                    dashTimeLeft = dashTime;
                    isDashing = true;
                    LastDashTime = Time.time;
                    GetComponent<PlayerUIController>().CdImage1.fillAmount = 1;
                }
                //如果不是第一次 那么要过了cd的时间才可以用dash
                if (Time.time >= LastDashTime + dashCdtime)
                {
                    dashTimeLeft = dashTime;
                    isDashing = true;
                    LastDashTime = Time.time;
                    GetComponent<PlayerUIController>().CdImage1.fillAmount = 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.I) && isGround)
            {

                isskill1 = true;
                moveable = false;
               
            }
            if (Input.GetKeyDown(KeyCode.U) && isGround)
            {

               
                //如果第一次释放  就可以直接用
                if (LastSkill2time == 0)
                {
                    isskill2 = true;
                    moveable = false;
                    LastSkill2time = Time.time;
                    //设置UI的覆盖度为1
                    GetComponent<PlayerUIController>().CdImage2.fillAmount = 1;
                }
                //如果不是第一次 那么要过了cd的时间才可以用dash
                if (Time.time >= LastSkill2time + Skill2Cdtime)
                {
                    isskill2 = true;
                    moveable = false;
                    LastSkill2time = Time.time;
                    GetComponent<PlayerUIController>().CdImage2.fillAmount = 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.J) && isGround)
            {

                //attack();
                if (!isattack)
                    hitCount++;
                isattack = true;

            }
            if (Input.GetKeyDown(KeyCode.O) && atr.CurrentEnergy == 3.0f && isbreakout == false)
            {
                atr.Breakout = true;
                isbreakout = true;
                atr.CurrentEnergy -= 3.0f;
                atr.BreakOut(breakout.GetComponent<SpriteRenderer>().sprite, 10);
                SoundManager.instance.Energy1Audio();
            }

        }
        atr.Defence = defence;
        RunSpeed = atr.RunSpeed;
    }
    public virtual void Player2InputGet()
    {
        if (defence && isGround && (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)))
        {
            BodyCollider.isTrigger = true;

        }
        if (!isGround && !isDashing)
        {
            BodyCollider.isTrigger = false;
        }
        if (attackable)
        {
            //按键检测-->状态设置
            if ((Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) && jumpCount > 0 && moveable)
            {
                jumpPressed = true;
            }
            if (Input.GetKey(KeyCode.LeftArrow)) horizontalMove = -1;
            else if (Input.GetKey(KeyCode.RightArrow)) horizontalMove = 1;
            else horizontalMove = 0;
            if (Input.GetKey(KeyCode.DownArrow) && !ishurt && !istetanic)
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
            if ((Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) && isGround && !defence)
            {

                //如果第一次释放  就可以直接用
                if (LastDashTime == 0)
                {
                    dashTimeLeft = dashTime;
                    isDashing = true;
                    LastDashTime = Time.time;
                    GetComponent<PlayerUIController>().CdImage1.fillAmount = 1;
                }
                //如果不是第一次 那么要过了cd的时间才可以用dash
                if (Time.time >= LastDashTime + dashCdtime)
                {
                    dashTimeLeft = dashTime;
                    isDashing = true;
                    LastDashTime = Time.time;
                    GetComponent<PlayerUIController>().CdImage1.fillAmount = 1;
                }
            }
            if ((Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) && isGround)
            {
                isskill1 = true;
                moveable = false;
            }
            if ((Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) && isGround)
            {
                //如果第一次释放  就可以直接用
                if (LastSkill2time == 0)
                {
                    isskill2 = true;
                    moveable = false;
                    LastSkill2time = Time.time;
                    //设置UI的覆盖度为1
                    GetComponent<PlayerUIController>().CdImage2.fillAmount = 1;
                }
                //如果不是第一次 那么要过了cd的时间才可以用dash
                if (Time.time >= LastSkill2time + Skill2Cdtime)
                {
                    isskill2 = true;
                    moveable = false;
                    LastSkill2time = Time.time;
                    GetComponent<PlayerUIController>().CdImage2.fillAmount = 1;
                }
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
                atr.Breakout = true;
                isbreakout = true;
                atr.CurrentEnergy -= 3.0f;
                atr.BreakOut(breakout.GetComponent<SpriteRenderer>().sprite, 10);
                SoundManager.instance.Energy1Audio();
                
            }
        }

        atr.Defence = defence;
        RunSpeed = atr.RunSpeed;
    }

    void Update()
    {
      
        


        if (gameObject.tag.Equals("Player1"))
        {
            Player1InputGet();
        }else if(gameObject.tag.Equals("Player2"))
        {
            Player2InputGet();
        }
        //游戏性状态处理
        if (atr.Dazzle)
        {
            horizontalMove = -horizontalMove;
        }

    }
    IEnumerator StartShiled()
    {
        shield.SetActive(true);
        SoundManager.instance.Defence1Audio();
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

    void ShotWave()
    {

        Transform temp = Instantiate(Wave, AttackPoint.transform.position, Quaternion.identity).GetComponent<Transform>();
        temp.localScale = new Vector3(-transform.localScale.x * Mathf.Abs(temp.localScale.x), temp.localScale.y, temp.localScale.z);


        //Instantiate(KnifeWave, AttackPoint.position, transform.rotation);
    }
    void SwitchAnim()//动画切换
    {
        


        //爆气动画处理
        if (isbreakout)
        {

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


        //防御的条件应该是可以移动 且没有被击打  被击打的了不能移动 所以 防御的时候肯定可以移动
        if (defence)
        {
            //防御动画  并且设置属性里的防御为true
            anim.SetBool("defence", true);
            //防御的时候打我是不会受伤的
            if (ishurtShiled)
            {
                StartCoroutine(StartShiled());
                ishurtShiled = false;
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

            //int prehitcount = hitCount;
            //if(prehitcount < 3)
            //{
            //    if(ContinueAtkTimeTick>0)
            //    {
            //        ContinueAtkTimeTick -= Time.deltaTime;
            //        if(ContinueAtkTimeTick<=0)
            //        {
            //            if(hitCount==prehitcount)
            //            {
            //                hitCount = 0;
            //            }
            //        }
            //    }
            //}
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

        ////受伤动画
        //if (ishurt&&!defence)
        //{
        //    anim.SetBool("hurt", true);
        //    moveable = false;
        //    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        //    {
        //        anim.SetBool("hurt", false);
        //        ishurt = false;
        //        moveable = true;
        //    }
        //}

        ////受伤动画  这样写可以受伤的时候继续受伤  不会一直显示受伤动画
        //if (ishurt && !defence && !anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
        //{
        //    anim.SetBool("hurt", true);
        //    moveable = false;
        //    ishurt = false;
        //}
        //// 如果受伤的过程中再受伤  就将受伤的状态改为false  
        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f && ishurt)
        //{
        //    anim.SetBool("hurt", false);
        //    moveable = true;
        //}
        ////如果受伤的动画结束了  就可以移动了 并且将受伤改为false
        //if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        //{
        //    anim.SetBool("hurt", false);
        //    moveable = true;
        //}


        //受伤和僵直状态 不能移动 不能防御  不能攻击和技能
        if(ishurt&&!defence)
        {
            anim.SetBool("hurt", true);
            moveable = false;
            attackable = false;


            jumpPressed = false;

        }
        //如果受伤状态结束  进入到僵直状态  如果在僵直状态受到伤害  在进入到受伤状态 否则进入到Idle状态
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
        {
            anim.SetBool("hurt", false);
            ishurt = false;
            
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Tetanic"))
        {
            Debug.Log("Tetanic" + anim.GetCurrentAnimatorStateInfo(0).normalizedTime+moveable);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hurt"))
        {
            Debug.Log("Hurt" + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }

        //如果当前处于僵直状态  啥都不能干
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Tetanic") &&anim.GetCurrentAnimatorStateInfo(0).normalizedTime<0.95f)
        {
            jumpPressed = false;
            moveable = false;
            istetanic = true;
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Tetanic") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >0.95f)
        {
            moveable = true;
            attackable = true;
            istetanic = false;
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
        if (isDashing&&!ishurt&&!istetanic)
        {
            moveable = false;
            if (dashTimeLeft > 0)
            {
                var attackperson = Physics2D.OverlapCircle(AttackPoint.position, 1f);

                if (attackperson != null && (attackperson.gameObject.layer==8))//说明前面有墙 不可以穿过
                {
                    Debug.Log(attackperson.gameObject.name);
                        dashTimeLeft = 0;

                }
                else
                {
                    rb.velocity = new Vector2(gameObject.transform.localScale.x * dashSpeed, 0f);
                    dashTimeLeft -= Time.deltaTime;
                    ShadowPool.instance.outPool(gameObject.tag);
                    BodyCollider.isTrigger = true;//dash的时候设置自己的碰撞体不能被碰到
                    rb.gravityScale = 0;
                }

            }
            else
            {
                //dash结束设置
                BodyCollider.isTrigger = false;
                isDashing = false;
                rb.gravityScale = 6;
                moveable = true;
            }
        }
        
    }
    public void Attack()
    {

        var attackperson = Physics2D.OverlapCircle(AttackPoint.position, 1f, PlayerAnother);
        if (attackperson != null)
        {

            if (attackperson.tag == "Player2"|| attackperson.tag == "Player1")
            {
                attackperson.GetComponent<PlayerAttribute>().GetHurt(atr.MyAttackDamage());
                Debug.Log(attackperson.tag);
                //如果处于防御状态  触发攻击护盾特效
                if(attackperson.GetComponent<PlayerAttribute>().Defence) attackperson.GetComponent<PlayerController>().ishurtShiled = true;
                else attackperson.GetComponent<PlayerController>().ishurt = true;
            }
        }
    }

}
