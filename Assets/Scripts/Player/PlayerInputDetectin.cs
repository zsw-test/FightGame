using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerAttribute attr;
    public float speed = 5f;
    public float JumpForce = 30f;
    public int dashSpeed = 30;
    public float dashTime = 0.2f;
    public bool isGround, isJump, isDashing, defence, death, isskill1, isattack, isbreakout, ishurt, moveable = true;
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

    // Start is called before the first frame update
    void Start()
    {
        attr = GetComponent<PlayerAttribute>();
    }

    // Update is called once per frame
    void Update()
    {
        //按键检测-- > 状态设置
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
        if (Input.GetKeyDown(KeyCode.I) && isGround)
        {
            isskill1 = true;
            moveable = false;
        }
        if (Input.GetKeyDown(KeyCode.J) && isGround)
        {
            //attack();
            if (!isattack)
                hitCount++;
            isattack = true;
            moveable = false;

        }
        if (Input.GetKeyDown(KeyCode.O) && atr.CurrentEnergy == 3 && isbreakout == false)
        {
            atr.Breakout = true;
            isbreakout = true;
            GetComponentInChildren<ParticleSystem>().Play();

        }
    }
}
