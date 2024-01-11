using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    private Animator _anim;
    private Rigidbody2D _rb;
    private float _xInput;
    private static readonly int Running = Animator.StringToHash("IsRunning");

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleMovement();
        UpdateAnimationState();
    }

    private void HandleMovement()
    {

        _xInput = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(_xInput * moveSpeed, _rb.velocity.y);
        
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {

        _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
    }

    private void UpdateAnimationState()
    {

        bool isRunning = _xInput != 0f;

        _anim.SetBool(Running, isRunning);
    }
}
