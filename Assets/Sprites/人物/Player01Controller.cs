using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01Controller : MonoBehaviour
{
    public float speed = 5f;
    public float JumpForce = 30f;
    public int dashSpeed = 30;
    public float dashTime = 0.2f;
    public bool isGround, isJump, isDashing, defence, death,isskill1,isattack;
    public int hitCount = 0;
    private Rigidbody2D rb;
    private BoxCollider2D BodyCollider;
    private Animator anim;
    public bool jumpPressed;
    public int jumpCount;
    private float horizontalMove;
    private float dashTimeLeft = 0;
    private AnimatorStateInfo stateInfo;

    public Transform groundCheck;
    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BodyCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //按键检测-->状态设置
        if (Input.GetKeyDown(KeyCode.K) && jumpCount > 0)
        {
            jumpPressed = true;
        }
        if (Input.GetKey(KeyCode.A)) horizontalMove = -1;
        else if (Input.GetKey(KeyCode.D)) horizontalMove = 1;
        else horizontalMove = 0;
        if (Input.GetKey(KeyCode.S))
        {
            jumpPressed = false;
            defence = true;
        }
        else defence = false;
        if (Input.GetKeyDown(KeyCode.L) && isGround)
        {

            if (dashTimeLeft <= 0)
            {
                isDashing = true;
                dashTimeLeft = dashTime;
            }
        }
        if(Input.GetKeyDown(KeyCode.I)&&isGround)
        {
            isskill1 = true;
        }
        if (Input.GetKeyDown(KeyCode.J)&&isGround)
        {
            //attack();
            if (!isattack)
                hitCount++;
            isattack = true;
            
            
        }
       

    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.3f, ground);

        GroundMovement();
        Dash();
        Jump();

        SwitchAnim();
    }
    void attack()
    {
        

        //if (hitCount == 0)
        //{
        //    hitCount = 1;
        //    anim.SetInteger("attack", hitCount);
        //}
        //else if (stateInfo.IsName("Atk1") && hitCount == 1 && stateInfo.normalizedTime < 0.8f)
        //{
        //    hitCount = 2;
        //    anim.SetInteger("attack", hitCount);
        //}
        //else if (stateInfo.IsName("Atk2") && hitCount == 2 && stateInfo.normalizedTime < 0.8f)
        //{
        //    hitCount = 3;
        //    anim.SetInteger("attack", hitCount);
        //}
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

        anim.SetFloat("running", Mathf.Abs(rb.velocity.x));

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
            //防御动画
            anim.SetBool("defence", true);
        }
        else
        {
            anim.SetBool("defence", false);
        }
        if(isskill1)
        {
            anim.SetBool("skill1", true);
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Skill1")&&anim.GetCurrentAnimatorStateInfo(0).normalizedTime>1f)
            {
                anim.SetBool("skill1", false);
                isskill1 = false;
            }
            
        }
        if(isattack)
        {
            anim.SetInteger("attack", hitCount);
            
            anim.SetBool("isattack", true);
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Atk1") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {
                
                anim.SetBool("isattack", false);
                isattack = false;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Atk3") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {

                anim.SetBool("isattack", false);
                isattack = false;
                hitCount = hitCount % 3;
            }
            
        }
    }
    void GroundMovement()
    {
        // horizontalMove = Input.GetAxisRaw("Horizontal");//只返回-1，0，1

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if (horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }

    }
    void Dash()
    {
        if (isDashing)
        {
            if (dashTimeLeft >= 0)
            {
                if (isGround)
                {
                    rb.velocity = new Vector2(gameObject.transform.localScale.x * dashSpeed, 0);
                    dashTimeLeft -= Time.deltaTime;
                    //  ShadowPool.instance.outPool();
                    Debug.Log(dashTimeLeft);
                    BodyCollider.enabled = false;//dash的时候设置自己的碰撞体不能被碰到

                }
            }
            else
            {
                BodyCollider.enabled = true;
                isDashing = false;
            }
        }
    }
}
