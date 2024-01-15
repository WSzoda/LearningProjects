using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine StateMachine;
    protected Player Player;
    
    protected Rigidbody2D Rb;

    private string _animBoolName;
    protected float xInput;

    protected PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        StateMachine = stateMachine;
        Player = player;
        _animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        Player.Anim.SetBool(_animBoolName, true);
        Rb = Player.Rb;
    }
    
    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }
    
    public virtual void Exit()
    {
        Player.Anim.SetBool(_animBoolName, false);
    }

}
