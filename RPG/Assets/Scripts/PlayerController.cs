using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int Running = Animator.StringToHash("IsRunning");
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");
    private static readonly int IsDashing = Animator.StringToHash("IsDashing");
    private static readonly int ComboCounter = Animator.StringToHash("ComboCounter");
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    
    private Animator _anim;
    private Rigidbody2D _rb;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    private float _dashTime;
    private float _xInput;
    private int _facingDirection = 1;
    private bool _isFacingRight = true;

    [Header("Collisions")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayerMask;
    private bool _isGrounded;

    [Header("Attacks")]
    [SerializeField] private float comboTimeWindow;
    private float _comboTimer;
    private int _comboCounter;
    private bool _isAttacking;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        CollisionsCheck();
        HandleInput();
        HandleMovement();
        
        FlipController();
        UpdateAnimationState();
    }

    private void CollisionsCheck()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask);
    }


    private void HandleMovement()
    {
        if (_isAttacking)
        {
            _rb.velocity = Vector2.zero;
        }
        else if (_dashTime > 0)
        {
            Dash();
        }
        else
        {
            Move();
        }

        _dashTime -= Time.deltaTime;
    }

    private void HandleInput()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown("left shift"))
        {
            if (_dashTime < -dashCooldown)
            {
                _dashTime = dashDuration;
            }
        }

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        _comboTimer -= Time.deltaTime;
    }

    private void Attack()
    {
        _isAttacking = true;

        if (_comboTimer < 0)
        {
            _comboCounter = 0;
        }
    }

    public void AttackStop()
    {
        _isAttacking = false;
        _comboTimer = comboTimeWindow;
        _comboCounter++;
        _comboCounter %= 3;
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_xInput * moveSpeed, _rb.velocity.y);
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
    }

    private void Dash()
    {
        _rb.velocity = new Vector2(_xInput * dashSpeed, 0);
    }
    
    private void UpdateAnimationState()
    {
        bool isRunning = _xInput != 0f;
        _anim.SetBool(Running, isRunning);
        _anim.SetBool(IsGrounded, _isGrounded);
        _anim.SetFloat(YVelocity, _rb.velocity.y);
        _anim.SetBool(IsDashing, _dashTime > 0);
        _anim.SetBool(IsAttacking, _isAttacking);
        _anim.SetInteger(ComboCounter, _comboCounter);
    }

    private void Flip()
    {
        _facingDirection = -_facingDirection;
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if (_rb.velocity.x > 0 && !_isFacingRight)
        {
            Flip();
        }
        if (_rb.velocity.x < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 position = transform.position;
        Gizmos.DrawLine(position, new Vector2(position.x, position.y - groundCheckDistance));
    }
}
