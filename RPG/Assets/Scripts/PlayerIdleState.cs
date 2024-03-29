using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{

    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        if (xInput != 0)
        {
            StateMachine.ChangeState(Player.MoveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
