using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float speed=5f;
    public float JumpForce = 10f;
    public int dashSpeed = 30;
    public float dashTime = 0.2f;
    public bool isGround, isJump, isDashing,defence,death;
    private Rigidbody2D rb;
    private BoxCollider2D BodyCollider;
    private Animator anim;
    public bool jumpPressed;
    public int jumpCount;
    private float horizontalMove;
    private float dashTimeLeft=0;
     

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
        if (Input.GetKeyDown(KeyCode.L)&&isGround)
        {

            if(dashTimeLeft<=0)
            {
                isDashing = true;
                dashTimeLeft = dashTime;
            }
        }
        
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
        if (jumpPressed && isGround )  //一段跳
        {
           
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJump = true;
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && isJump  ) //二段跳
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            jumpCount--;
            jumpPressed = false;
        }
    }


    void SwitchAnim()//动画切换
    {

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
        if(defence)
        {
            //防御动画
            anim.SetBool("crouching", true);
        }
        else
        {
            anim.SetBool("crouching", false);
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
                if(isGround)
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
