using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int Running = Animator.StringToHash("IsRunning");
    private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    [Header("Collisions")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundLayerMask;

    private Animator _anim;
    private Rigidbody2D _rb;
    
    private float _xInput;
    private int _facingDirection = 1;
    private bool _isFacingRight = true;
    private bool _isGrounded;
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleMovement();
        CollisionsCheck();
        
        FlipController();
        UpdateAnimationState();
    }

    private void CollisionsCheck()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayerMask);
    }


    private void HandleMovement()
    {

        _xInput = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(_xInput * moveSpeed, _rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && _isGrounded)
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
        _anim.SetBool(IsGrounded, _isGrounded);
        _anim.SetFloat(YVelocity, _rb.velocity.y);
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
