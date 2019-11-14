using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    private float speed = 5f;
    public GameObject player;
    private PlayerMotor motor;
    public Transform posTarget;
    public Transform forwardDive, backDive, leftDive, rightDive;
    public float turnSpeed;
    Animator animator;

    void Start() {
        motor = GetComponent<PlayerMotor>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayAnim(horizontal, vertical);

        if (Input.GetKeyDown(KeyCode.D))
            transform.rotation *= Quaternion.Euler(0, 90, 0);

        if((horizontal != 0) || (vertical != 0))
        {
            Vector3 dir = posTarget.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
        }

        //перекат
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Dive", true);
        }

        Vector3 movHor = transform.right * horizontal;
        Vector3 movVer = transform.forward * vertical;
        Vector3 velocity = (movHor + movVer).normalized * speed;

        motor.Move(velocity);
    }

    public void PlayAnim(float horizontal, float vertical)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}
