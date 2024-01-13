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
        Debug.Log("Entered into " + _animBoolName);
    }
    
    public virtual void Update()
    {
        Debug.Log("Updated in " + _animBoolName);
    }
    
    public virtual void Exit()
    {
        Debug.Log("Exited from " + _animBoolName);
    }

}
