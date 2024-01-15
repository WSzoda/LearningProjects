using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Move info")] 
    public float moveSpeed = 8f;
    public float jumpForce = 12f;

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
    #endregion


    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        
        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
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
    }

    public void ChangeVelocity(float xVelocity, float yVelocity)
    {
        Rb.velocity = new Vector2(xVelocity, yVelocity);
    }

    private void OnDrawGizmos()
    {
        var positionGroundCheck = groundCheck.position;
        Gizmos.DrawLine(positionGroundCheck, new Vector2(positionGroundCheck.x, positionGroundCheck.y - groundCheckDistance));
        var positionWallCheck = wallCheck.position;
        Gizmos.DrawLine(positionWallCheck, new Vector2(positionWallCheck.x + wallCheckDistance, positionWallCheck.y));
    }

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsTerrain);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, whatIsTerrain);
}
