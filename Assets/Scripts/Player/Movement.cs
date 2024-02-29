using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;

    public Animator animator;
    public float walkSpeed = 5;
    Vector3 targetPositionToWalk;
    bool isWalking=false;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        GetMouse.MouseClicked += OnMouseInt;
    }
    private void OnDisable()
    {
        GetMouse.MouseClicked -= OnMouseInt;
    }

    private void OnMouseInt(string arg1, Vector3 arg2, GameObject arg3)
    {
        if(arg1=="Land")
             MoveToPosition(arg2);
    }

    public void MoveToPosition(Vector3 point)
    {
        targetPositionToWalk = point;
        targetPositionToWalk.y = transform.position.y;
        isWalking = true;
        animator.SetBool("Walk", true);
        transform.LookAt(targetPositionToWalk);
    }
    void Update()
    {
        if(isWalking)
        {
            var step = walkSpeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPositionToWalk, step);
            if (Vector3.Distance(transform.position, targetPositionToWalk) < 0.1f)
            {
                isWalking = false;
                animator.SetBool("Walk", false);
            }
        }
    }
}
