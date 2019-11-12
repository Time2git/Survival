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
    public Transform posTarget;
    public float turnSpeed;

    void Start() {
        motor = GetComponent<PlayerMotor>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayAnim(horizontal, vertical);

        if((horizontal != 0) || (vertical != 0))
        {
            Vector3 dir = posTarget.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
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
