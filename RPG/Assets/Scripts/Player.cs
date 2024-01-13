using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine;

    public PlayerState PlayerIdleState;
    public PlayerState PlayerMoveState;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        
        PlayerIdleState = new PlayerIdleState(this, StateMachine, "Idle");
        PlayerMoveState = new PlayerMoveState(this, StateMachine, "Move");
    }

    private void Start()
    {
        StateMachine.Initialize(PlayerIdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.Update();
        
    }
}
