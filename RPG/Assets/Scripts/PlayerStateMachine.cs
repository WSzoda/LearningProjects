using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{ 
    public PlayerState CurrentState { get; private set;  }

    public void Initialize(PlayerState startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState state)
    {
        CurrentState.Exit();
        CurrentState = state;
        CurrentState.Enter();
    }
}
