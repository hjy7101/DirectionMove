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
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero; // move = new Vector3(0, 0, 0)
        if (Input.GetKey(KeyCode.A)) move.x = -1;
        if (Input.GetKey(KeyCode.D)) move.x = 1;
        if (Input.GetKey(KeyCode.W)) move.z = 1;
        if (Input.GetKey(KeyCode.S)) move.z = -1;

        if (move != Vector3.zero)
        {
            move.Normalize();
            transform.Translate(move * 5 * Time.deltaTime
                , Space.World);

            transform.forward = move;
        }
    }
    public float speed = 5;
}
