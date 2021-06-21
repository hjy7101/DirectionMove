using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMove : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        lastMoveDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero; // move = new Vector3(0, 0, 0)
        if (Input.GetKey(KeyCode.A)) move.x = -1;
        if (Input.GetKey(KeyCode.D)) move.x = 1;
        if (Input.GetKey(KeyCode.W)) move.z = 1;
        if (Input.GetKey(KeyCode.S)) move.z = -1;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            state = StateType.Attack;
            animator.Play("Attack", 1);
        }

        if (move != Vector3.zero)
        {
            move.Normalize();
            transform.Translate(move * 5 * Time.deltaTime
                , Space.World);

            //transform.forward = move; // 이코드 있으면 작동안함.
            lastMoveDirection = move;
            state = StateType.Run;
            animator.Play("Run");
        }
        else
        {
            move = lastMoveDirection;
            state = StateType.Idle;
            animator.Play("Idle");
        }

        transform.forward = Vector3.Slerp(transform.forward
            , move, roateLerp);

        //transform.forward = transform.forward; // roateLerp ==0; 오른쪽,
        //transform.forward = move; // roateLerp == 1;

        //roateLerp: 0.05
        //transform.forward : 앞쪽,100
        //move; 오른쪽(0)
        //    // 1frame : 95
        //    // 2frame : 91
        //    // 3frame : 87
        //    // 4frame : 84
        //    // 5frame : 83
        //    // 60 frame : 0
    }
    public float speed = 5;
    public float roateLerp = 0.5f;
    public Vector3 lastMoveDirection;

    public StateType state = StateType.Idle;
    public enum StateType
    {
        Idle, Run, Jump, Attack,
    }
}
