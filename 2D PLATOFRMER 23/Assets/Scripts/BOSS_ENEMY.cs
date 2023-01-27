using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_ENEMY : StateMachineBehaviour
{
    Rigidbody2D rb;
    Transform player;
    //GameObject enemy;

    public float AwakeRange;
    public float AttackRange;
    public float Speed;
    public float AttackPoint;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb = animator.gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(rb.position, player.position) <= AwakeRange)
        {
            Vector2 TargetPos = new Vector2(player.position.x,rb.position.y);
            animator.SetTrigger("awake");
            if (Vector2.Distance(rb.position, player.position) <= AttackRange)
            {
                animator.SetBool("move", true);
                Vector2 Target = Vector2.MoveTowards(rb.position, TargetPos, Speed * Time.deltaTime);
                rb.MovePosition(Target);

                if (Vector2.Distance(rb.position, player.position) <= AttackPoint)
                {
                    Vector2 newTarget= Vector2.MoveTowards(rb.position, TargetPos,- Speed * Time.deltaTime);
                    rb.MovePosition(newTarget);
                    animator.SetTrigger("shoot");
                }
                else
                {
                    Debug.Log("!!!");
                }
            }
            else if (Vector2.Distance(rb.position, player.position) > AttackRange)
            {
                animator.SetBool("move", false);
            }
        }
        else
        {
            animator.SetTrigger("sleep");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("awake");
    }
}
