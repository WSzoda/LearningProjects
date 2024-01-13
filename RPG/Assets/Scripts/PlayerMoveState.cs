using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{

    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            StateMachine.ChangeState(Player.PlayerIdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}