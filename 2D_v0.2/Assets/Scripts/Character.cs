using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private int lives = 5;
    [SerializeField]
    private float jumpFroce = 1.0F;

    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }


    new private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;

    private bool IsGrounded = false;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {
        if (IsGrounded) State = CharState.Idle;
        if (Input.GetButton("Horizontal")) Run();
        if (IsGrounded && Input.GetButtonDown("Jump")) Jump();

    }

    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxis("Horizontal"); // return 1 or 0

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.1;
        if (IsGrounded) State = CharState.Run;
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpFroce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2F);
        IsGrounded = colliders.Length > 1;
        if (!IsGrounded) State = CharState.Jump;
    }



}

public enum CharState
{
    Idle,
    Run,
    Jump
}
