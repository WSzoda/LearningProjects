using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    private static readonly int YVelocity = Animator.StringToHash("yVelocity");

    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        Player.Anim.SetFloat(YVelocity, Rb.velocity.y);

        if (Player.IsGroundDetected())
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
