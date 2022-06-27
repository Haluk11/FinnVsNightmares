using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //player handling
    public float MovementSpeed = 1;
    public float JumpForce = 3;


    private Rigidbody2D rigidbody2D_;

    const float groundCheckRadius = 0.2f;

    [SerializeField]
    Transform groundCheckCollider;

    [SerializeField]
    LayerMask yerLayer;

    public Animator animator;

    public bool facingRight = true;

    bool jump;

    [SerializeField]
    bool isGrounded;

    float horizontalValue;
    private HealthBar healthbar;
    public bool isDead;
    public float timeInAir = 0f;

    [SerializeField]
    public float deathTimer = .5f;

    void Start()
    {
        rigidbody2D_ = GetComponent<Rigidbody2D>();
        healthbar = GetComponent<HealthBar>();
    }

   
    void Update()
    {
        //character -x- ekseninde

        if(isDead) return;

        horizontalValue = Input.GetAxis("Horizontal");

        //character zıplama -y-

        if(Input.GetButtonDown("Vertical"))
        {
            animator.SetBool("isJumping",true);
            jump = true;
        }
        else if (Input.GetButtonUp("Vertical"))
            jump = false;
        }

    void FixedUpdate()
    {
        groundCheck();
        move(horizontalValue, jump);
    }

    void groundCheck()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position,groundCheckRadius,yerLayer);
        if(colliders.Length>0)
            isGrounded = true;

        // grounded sa animator isJumping bool'unu false yap
        animator.SetBool("isJumping",!isGrounded);
    }

    void move(float dir,bool jumpkek)
    {
        
        if(isGrounded && jumpkek)
        {
            isGrounded = false;
            jumpkek = false;
            rigidbody2D_.AddForce(new Vector3(0,JumpForce), ForceMode2D.Impulse);
        }


        float xVal = dir * MovementSpeed * Time.fixedDeltaTime * 50;
        Vector2 targetVelocity = new Vector2(xVal,rigidbody2D_.velocity.y);
        rigidbody2D_.velocity = targetVelocity;
        
        // face LEFT
        if(facingRight && dir <0){
            transform.localScale = new Vector3(-1,1,1);
            facingRight = false;
        }
        // face RIGHT
        else if (!facingRight && dir >0){
            transform.localScale = new Vector3(1,1,1);
            facingRight = true;
        }

        animator.SetFloat("xVelocity", Mathf.Abs(rigidbody2D_.velocity.x));
    }

    public void Die()
    {
        isDead = true;
        FindObjectOfType<Level>().Restart();
    }
}
