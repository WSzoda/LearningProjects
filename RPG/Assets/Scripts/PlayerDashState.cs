using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = Player.dashDuration;
    }

    public override void Update()
    {
        base.Update();
        Rb.velocity = new Vector2(Player.dashSpeed * Player.PlayerDir, 0);
        
        if (stateTimer < 0)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        Rb.velocity = new Vector2(0, Rb.velocity.y);
    }
}
