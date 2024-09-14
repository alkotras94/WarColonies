using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitStateMachine : MonoBehaviour
{
    [SerializeField] private ManagementTransition _managementTransition;

    private List<State> _states;
    private State _currentState;

    public void Initialize(Movement movement, Health health)
    {
        if (movement == null)
            throw new NullReferenceException();

        if(health == null)
            throw new NullReferenceException();

        _states = new List<State>()
        {
            new WaitingState(),
            new MoveState(movement, this),
            new AttackState(health),
            new CollectionResourcesState(_managementTransition)
        };
    }

    public void Wait()
    {
        ChangeState<WaitingState>(null);
    }

    public void Move(Hit hitData)
    {
        ChangeState<MoveState>(hitData);
    }

    public void AttackState(Hit hitData)
    {
        ChangeState<AttackState>(hitData);
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

