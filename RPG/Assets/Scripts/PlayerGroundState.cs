using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{

    protected PlayerGroundState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (!Player.IsGroundDetected())
        {
            StateMachine.ChangeState(Player.AirState);
        }

        if (Input.GetButtonDown("Jump") && Player.IsGroundDetected())
        {
            StateMachine.ChangeState(Player.JumpState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
