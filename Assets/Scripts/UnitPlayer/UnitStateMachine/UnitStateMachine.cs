using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    private List<State> _states;
    private State _currentState;

    public void Initialize(Movement movement, Health health, ManagementTransition managementTransition, InitTransition initTransition)
    {
        if (movement == null)
            throw new NullReferenceException();

        if(health == null)
            throw new NullReferenceException();

        _states = new List<State>()
        {
            new InitState(initTransition),
            new WaitingState(movement,this),
            new MoveState(movement, this),
            new CollectionResourcesState(managementTransition)
        };
    }

    public void Init()
    {
        ChangeState<InitState>(null);
    }
    public void Wait()
    {
        ChangeState<WaitingState>(null);
    }

    public void Move(Hit hitData)
    {
        ChangeState<MoveState>(hitData);
    }

    public void CollectingResources(Hit hitData)
    {
        ChangeState<CollectionResourcesState>(hitData);
    }

    private void ChangeState<T>(Hit hitData) where T : State
    {

        if (_currentState != null)
        {
            _currentState.Exit();
        }  

        _currentState = _states.FirstOrDefault(state => state is T);
        _currentState.Enter(hitData);
    }
}

