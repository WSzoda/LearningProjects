using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private enum AnimationState {Idle, Running, Jumping, Falling}

    private AnimationState _state = AnimationState.Idle;
    
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveForce;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;

    private float _dirX;
    private static readonly int State = Animator.StringToHash("state");

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(moveForce * _dirX, _rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        AnimationState state = AnimationState.Idle;
        if (_dirX > 0)
        {
            state = AnimationState.Running;
            _spriteRenderer.flipX = false;
        }
        else if (_dirX < 0)
        {
            state = AnimationState.Running;
            _spriteRenderer.flipX = true;
        }
        if (_rb.velocity.y > .1f)
        {
            state = AnimationState.Jumping;
        }
        else if (_rb.velocity.y < -0.1f)
        {
            state = AnimationState.Falling;
        }

        _state = state;
        _animator.SetInteger(State,(int)_state);
    }
}
