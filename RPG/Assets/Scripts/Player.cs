using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{

    [Header("Move info")] 
    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    [SerializeField] private float dashCooldown;
    private float _dashUsageTimer;
    public float dashDuration;
    public float dashSpeed;
    
    public bool IsFacingRight { get; private set; } = true;
    public int PlayerDir { get; private set; } = 1;

    [Header("Collision Checks")] 
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [Space]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [Space]
    [SerializeField] private LayerMask whatIsTerrain;

    
    
    #region Components
        public Animator Anim { get; private set; }
        public Rigidbody2D Rb { get; private set; }
    #endregion
    #region States
        public PlayerStateMachine StateMachine { get; private set; }

        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerAirState AirState { get; private set; }
        public PlayerDashState DashState { get; private set; }
    #endregion


    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        
        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
        DashState = new PlayerDashState(this, StateMachine, "Dash");
    }

    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.Update();
        CheckDashInput();
    }


    private void CheckDashInput()
    {
        _dashUsageTimer -= Time.deltaTime;
        
        if (Input.GetKeyDown("left shift") && _dashUsageTimer < 0)
        {
            _dashUsageTimer = dashCooldown;
            StateMachine.ChangeState(DashState);
        }
    }

    public void ChangeVelocity(float xVelocity, float yVelocity)
    {
        FlipController(xVelocity);
        Rb.velocity = new Vector2(xVelocity, yVelocity);
    }

    private void OnDrawGizmos()
    {
        var positionGroundCheck = groundCheck.position;
        Gizmos.DrawLine(positionGroundCheck, new Vector2(positionGroundCheck.x, positionGroundCheck.y - groundCheckDistance));
        var positionWallCheck = wallCheck.position;
        Gizmos.DrawLine(positionWallCheck, new Vector2(positionWallCheck.x + wallCheckDistance * PlayerDir, positionWallCheck.y));
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        PlayerDir *= -1;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float x)
    {
        if (x < 0 && IsFacingRight)
        {
            Flip();
        }
        if (x > 0 && !IsFacingRight)
        {
            Flip();
        }
    }
    

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsTerrain);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, whatIsTerrain);
}
