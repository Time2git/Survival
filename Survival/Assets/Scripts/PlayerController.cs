using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    GameObject player;
    private PlayerMotor motor;
    Animator animator;
    System.Random rand = new System.Random();

    void Start() {
        motor = GetComponent<PlayerMotor>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        if((zMov == 0) && (xMov == 0))
        {
            animator.SetBool("Run", false);
            animator.SetBool("RunBack", false);
        }
        if(zMov >= 0.1f)
        {
            animator.SetBool("Run", true);
            animator.SetBool("RunBack", false);
        }

        if (zMov <= -0.1f)
        {
            animator.SetBool("RunBack", true);
            animator.SetBool("Run", false);
        }


        Vector3 movHor = transform.right * xMov;
        Vector3 movVer = transform.forward * zMov;
        Vector3 velocity = (movHor + movVer).normalized * speed;

        motor.Move(velocity);
    }
}
