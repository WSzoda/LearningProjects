using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.ChangeVelocity(Rb.velocity.x, Player.jumpForce);
    }

    public override void Update()
    {
        base.Update();
        StateMachine.ChangeState(Player.AirState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
