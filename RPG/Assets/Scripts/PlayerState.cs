using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine StateMachine;
    protected Player Player;

    private string _animBoolName;

    protected PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        StateMachine = stateMachine;
        Player = player;
        _animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        Player.Anim.SetBool(_animBoolName, true);
    }
    
    public virtual void Update()
    {
        Debug.Log("Updated in " + _animBoolName);
    }
    
    public virtual void Exit()
    {
        Player.Anim.SetBool(_animBoolName, false);
    }

}
