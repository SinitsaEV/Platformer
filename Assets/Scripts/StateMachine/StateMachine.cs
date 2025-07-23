using System.Collections.Generic;
using UnityEngine;

public class StateMachine : IStateMachine
{
    private readonly Dictionary<string, IState> _states = new Dictionary<string, IState>();
    private IState _currentState;

    public void ChangeState<TNextState>() where TNextState : IState
    {
        if (_currentState == null)
            return;

        _currentState.Exit();
        _currentState = _states[typeof(TNextState).Name];
        _currentState.Enter();
    }

    public virtual void Run()
    {
        if (_currentState == null)
            return;

        _currentState.Enter();
    }

    public void SetFirstState<TFirstState>() where TFirstState : IState
    {
        _currentState = _states[typeof(TFirstState).Name];
    }

    public virtual void Stop()
    {
        _currentState.Exit();
    }

    public virtual void Update()
    {
        if (_currentState == null)
            return;

        _currentState.Update();
    }

    public void AddState<TNextState>(IState state) where TNextState : IState
    {
        if (state == null)
            return;

        _states[typeof(TNextState).Name] = state;
    }
}
