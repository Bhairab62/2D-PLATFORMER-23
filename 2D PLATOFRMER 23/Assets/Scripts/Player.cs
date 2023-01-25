using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator an;

    public float Speed;
    public float JumpForce;
    private float movement;
    private bool IsGround = true;
    private bool FacingRight = true;

    public float DashSpeed;
    private float DashTime;
    public float StartDashTime;
    // Start is called before the first frame update
    void Start()
    {
        DashTime = StartDashTime;
        rb = gameObject.GetComponent<Rigidbody2D>();
        an = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        PlayerFlip();PlayerRunAnimation();
        movement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            int RandomJumpAnim = Random.Range(0, 2);
            if (RandomJumpAnim == 0)
            {
                an.SetTrigger("jump");
            }
            else if (RandomJumpAnim == 1)
            {
                an.SetTrigger("roll");
            }
            Jump();
            IsGround = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Block();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (DashTime ==StartDashTime)
            {
                an.SetTrigger("dash");
                transform.position+= transform.right*DashSpeed;
            }
            else
            {
                DashTime -= Time.deltaTime;
                rb.velocity = Vector2.zero;
            }
        }

    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(movement, 0f, 0f) * Speed * Time.fixedDeltaTime;
    }
    void Jump()
    {
        rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            IsGround = true;
        }
    }
    void Attack()
    {
        Debug.Log("Attack!!");
        int RandomAttack = Random.Range(0, 3);
        if (RandomAttack == 0)
        {
            an.SetTrigger("attack1");
        }else if (RandomAttack == 1)
        {
            an.SetTrigger("attack2");
        }else if (RandomAttack == 2)
        {
            an.SetTrigger("attack3");
        }
    }
    void PlayerRunAnimation()
    {
        if (Mathf.Abs(movement) < .1f)
        {
            an.SetFloat("run", 0f);
        }
        else if (Mathf.Abs(movement) > .1f)
        {
            an.SetFloat("run", 1f);
        }
    }
    void PlayerFlip()
    {
        if (movement < 0f && FacingRight)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            FacingRight = false;
        }
        else if (movement > 0f && !FacingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            FacingRight = true;
        }
    }
    void Block()
    {
        Debug.Log("Block!!");
        an.SetTrigger("block");
    }
}
