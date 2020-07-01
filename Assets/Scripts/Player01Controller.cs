using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01Controller : MonoBehaviour
{
 
        private Rigidbody2D rb;
        private Collider2D coll;
        private Animator anim;


        [Header("dash参数")]
        public float dashTime;
        public float cdTime;
        public float lastTime;  //一开始等于-cdtime 为了一开始能够释放技能
        public int dashSpeed;
        private bool isdashing;
        private float dashTimeLeft;

        public float speed, jumpForce;
        private float horizontalMove;
        public Transform groundCheck;
        public LayerMask ground;

        public bool isGround, isJump, isDashing;

        bool jumpPressed;
        int jumpCount;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            coll = GetComponent<Collider2D>();
            anim = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Jump") && jumpCount > 0)
            {
                jumpPressed = true;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                if (lastTime == 0)
                {
                    lastTime = -cdTime;
                }
                if (Time.time >= lastTime + cdTime)
                {
                    dashTimeLeft = dashTime;
                    isdashing = true;
                    lastTime = Time.time;
                }
            }
        }

        private void FixedUpdate()
        {
            isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);

            GroundMovement();

            Jump();

            Dash();
            SwitchAnim();
        }

        void GroundMovement()
        {
         
        if (Input.GetKey(KeyCode.A)) horizontalMove = -1;
        else if (Input.GetKey(KeyCode.D)) horizontalMove = 1;
        else horizontalMove = 0;
            rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

            if (horizontalMove != 0)
            {
                transform.localScale = new Vector3(horizontalMove, 1, 1);
            }

        }

        void Jump()//跳跃
        {
            if (isGround)
            {
                jumpCount = 2;//可跳跃数量
                isJump = false;
            }
            if (jumpPressed && isGround)
            {
                isJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpCount--;
                jumpPressed = false;
            }
            else if (jumpPressed && jumpCount > 0 && isJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
        }

        void Dash()
        {
            if (isdashing)
            {
                if (dashTimeLeft >= 0)
                {
                    if (rb.velocity.y > 0 && !isGround)
                    {
                        rb.velocity = new Vector2(gameObject.transform.localScale.x * dashSpeed, jumpForce);
                    }
                    rb.velocity = new Vector2(gameObject.transform.localScale.x * dashSpeed, rb.velocity.y);
                    dashTimeLeft -= Time.deltaTime;
                    ShadowPool.instance.outPool();
                }
                else
                {
                    if (!isGround)
                    {
                        rb.velocity = new Vector2(gameObject.transform.localScale.x * dashSpeed, jumpForce);
                    }
                    isdashing = false;
                }
            }
        }
    }